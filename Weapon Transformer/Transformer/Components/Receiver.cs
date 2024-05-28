using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the base building info for the weapon.
/// 
/// Call "GetItemComponents()" for the weapon to create itself randomly based on attachments.
/// The weapon script will save what gets generated and stores each component. - See the weapon script for more info on how to display the generated weapon.
/// This is non-destructive creation. These values should not be edited at runtime, but read from.
/// </summary>

namespace SovereignGaming.WeaponForge
{
    [CreateAssetMenu(fileName = "New Receiver", menuName = "My Assets/Components/New Receiver")]
    public class Receiver : GunComponent
    {
        [Header("Item Compatibility List")]
        public CompatibleComponents compatibleComponents;

        public GunComponentList GetItemComponents()// This is called to Get the components for the item
        {
            GunComponentList gunComponentList = new GunComponentList();
            gunComponentList.receiver = this;
            if (compatibleComponents.barrels.Count > 0)
                gunComponentList.barrel = GetBarrel();
            if (compatibleComponents.magazines.Count > 0)
                gunComponentList.magazine = GetMagazine();
            if (compatibleComponents.grips.Count > 0)
                gunComponentList.grip = GetGrip();
            if (compatibleComponents.sights.Count > 0)
                gunComponentList.sight = GetSight();
            if (compatibleComponents.stocks.Count > 0)
                gunComponentList.stock = GetStock();
            return gunComponentList;
        }

        public Stock GetStock()
        {
            return compatibleComponents.stocks[ComponentRNG(compatibleComponents.stocks.Count)];
        }
        public Magazine GetMagazine()
        {
            return compatibleComponents.magazines[ComponentRNG(compatibleComponents.magazines.Count)];
        }
        public Barrel GetBarrel()
        {
            return compatibleComponents.barrels[ComponentRNG(compatibleComponents.barrels.Count)];
        }
        public Grip GetGrip()
        {
            return compatibleComponents.grips[ComponentRNG(compatibleComponents.grips.Count)];
        }
        public Sight GetSight()
        {
            return compatibleComponents.sights[ComponentRNG(compatibleComponents.sights.Count)];
        }
        int ComponentRNG(int max)
        {
            return Random.Range(0, max);
        }
    }

    [System.Serializable]
    public class CompatibleComponents
    {
        public List<Barrel> barrels = new List<Barrel>();
        public List<Magazine> magazines = new List<Magazine>();
        public List<Grip> grips = new List<Grip>();
        public List<Sight> sights = new List<Sight>();
        public List<Stock> stocks = new List<Stock>();

        [Header("Optional")]
        public List<Barrel> barrelAttachments = new List<Barrel>();
        public List<Grip> foregripAttachments = new List<Grip>();
    }
}