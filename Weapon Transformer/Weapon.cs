
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace SovereignGaming.WeaponForge
{
    [System.Serializable]
    public class Weapon
    {
        public string itemName;

        [Space(10)]
        public WeaponStats stats;

        [Space(10)]

        public GunComponentList attachedComponents;

        public void GetRandomComponents()
        {
            //Barrel
            attachedComponents.barrel = attachedComponents.receiver.GetBarrel();

            //Stock
            attachedComponents.stock = attachedComponents.receiver.GetStock();

            //Magazine
            attachedComponents.magazine = attachedComponents.receiver.GetMagazine();

            //Sight
            attachedComponents.sight = attachedComponents.receiver.GetSight();

            //Grip
            attachedComponents.grip = attachedComponents.receiver.GetGrip();

            itemName = GetName(this);
        }

        // You can create a more in depth naming system in this method
        public string GetName(Weapon item)
        {
            string newName = string.Empty;
            List<string> names = new List<string>();

            if (item.attachedComponents.sight.componentTitle != string.Empty)
                names.Add(item.attachedComponents.sight.componentTitle); // Sight
            if (item.attachedComponents.magazine.componentTitle != string.Empty)
                names.Add(item.attachedComponents.magazine.componentTitle); // Magazine
            //if (item.attachedComponents.magazine.bullet.componentTitle != string.Empty)
            //    names.Add(item.attachedComponents.magazine.bullet.componentTitle); // Bullet
            if (item.attachedComponents.grip.componentTitle != string.Empty)
                names.Add(item.attachedComponents.grip.componentTitle); // Grip
            if (item.attachedComponents.stock.componentTitle != string.Empty)
                names.Add(item.attachedComponents.stock.componentTitle); // Stock
            if (item.attachedComponents.barrel.componentTitle != string.Empty)
                names.Add(item.attachedComponents.barrel.componentTitle); // Barrel
            if (item.attachedComponents.receiver.componentTitle != string.Empty)
                names.Add(item.attachedComponents.receiver.componentTitle); // Receiver

            foreach (string name in names)
                newName += $"{name} ";

            newName.Remove(newName.Length - 1);

            return newName;
        }
    }
}
