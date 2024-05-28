using UnityEditor;
using UnityEditor.SceneTemplate;
using UnityEngine;

namespace SovereignGaming.WeaponForge
{
    [System.Serializable]
    public class WorldWeapon : MonoBehaviour
    {
        public Weapon weapon;
        [HideInInspector]// This line can be commented out if you want to manually place the component locations on each receiver.
                         // When doing it this way, you must also comment out line 26 'GetComponentLocations'
        public ComponentLocations componentLocations;

        [Space(10)]

        public bool display = false;

        private void Start()
        {
            display = true;
            name = weapon.itemName;
            GetComponentLocations();
        }

        void RebuildWeapon()
        {
            PlaceMesh();
        }

        void RandomWeapon()
        {
            if (!weapon.attachedComponents.receiver)
                return;

            weapon.GetRandomComponents();

            if (EditorApplication.isPlaying)
                PlaceMesh();
        }

        void GetComponentLocations()
        {
            componentLocations.barrelLocation = transform.GetChild(0);
            componentLocations.magazineLocation = transform.GetChild(1);
            componentLocations.gripLocation = transform.GetChild(2);
            componentLocations.sightLocation = transform.GetChild(3);
            componentLocations.stockLocation = transform.GetChild(4);

            if (display)
                PlaceMesh();
        }

        public void PlaceMesh()
        {
            if (weapon.attachedComponents.barrel != null)
                PlaceComponent(weapon.attachedComponents.barrel, componentLocations.barrelLocation);
            if (weapon.attachedComponents.magazine != null)
                PlaceComponent(weapon.attachedComponents.magazine, componentLocations.magazineLocation);
            if (weapon.attachedComponents.grip != null)
                PlaceComponent(weapon.attachedComponents.grip, componentLocations.gripLocation);
            if (weapon.attachedComponents.sight != null)
                PlaceComponent(weapon.attachedComponents.sight, componentLocations.sightLocation);
            if (weapon.attachedComponents.stock != null)
                PlaceComponent(weapon.attachedComponents.stock, componentLocations.stockLocation);
        }

        void PlaceComponent(GunComponent component, Transform location)
        {
            if (location.childCount > 0)
                Destroy(location.GetChild(0).gameObject);
            GameObject newComponent;
            if (component.myComponentMesh != null)
            {
                newComponent = Instantiate(component.myComponentMesh, location);
                newComponent.name = component.name;
            }
        }

        void RenameChildren()
        {
            int childIndex = 0;

            transform.GetChild(childIndex++).name = "BarrelLocation";
            transform.GetChild(childIndex++).name = "MagazineLocation";
            transform.GetChild(childIndex++).name = "GripLocation";
            transform.GetChild(childIndex++).name = "SightLocation";
            transform.GetChild(childIndex).name = "StockLocation";
        }
        public void GenerateStats()
        {
            Debug.Log("Attempting to print stats...");
            //Assign DPS

            float ste = weapon.stats.magazineSize / weapon.stats.fireRate; 
            float ster = ste + weapon.stats.reloadTime;

            float md = weapon.stats.magazineSize * weapon.stats.damage; //Magazine Damage

            float pdops = md / ster;//Potential Damage Output Per Second

            weapon.stats.bestDPS = pdops;

            Debug.Log("Stats printed.");
        }

        public void GetWeaponName()
        {
            weapon.itemName = weapon.GetName(weapon);
        }
    }
}
