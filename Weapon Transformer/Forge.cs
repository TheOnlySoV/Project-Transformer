using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SovereignGaming.WeaponForge
{
    [System.Serializable]
    public class Forge
    {
        public List<Receiver> receivers;

        [Header("Quality and Naming")]
        public List<QTier> qualityTiers;

        public Receiver GetReceiver()
        {
            return receivers[ChooseReceiver()];
        }

        public Barrel GetRandomBarrel(Receiver receiver = null)
        {
            if (!receiver)
                receiver = GetReceiver();

            return receiver.compatibleComponents.barrels[Random.Range(0, receiver.compatibleComponents.barrels.Count)];
        }

        public Stock GetRandomStock(Receiver receiver = null)
        {
            if (!receiver)
                receiver = GetReceiver();

            return receiver.compatibleComponents.stocks[Random.Range(0, receiver.compatibleComponents.stocks.Count)];
        }

        public Magazine GetRandomMagazine(Receiver receiver = null)
        {
            if (!receiver)
                receiver = GetReceiver();

            return receiver.compatibleComponents.magazines[Random.Range(0, receiver.compatibleComponents.magazines.Count)];
        }

        public Grip GetRandomGrip(Receiver receiver = null)
        {
            if (!receiver)
                receiver = GetReceiver();

            return receiver.compatibleComponents.grips[Random.Range(0, receiver.compatibleComponents.grips.Count)];
        }

        public Sight GetRandomSight(Receiver receiver = null)
        {
            if (!receiver)
                receiver = GetReceiver();

            return receiver.compatibleComponents.sights[Random.Range(0, receiver.compatibleComponents.sights.Count)];
        }

        public Weapon GetWeapon()
        {
            Weapon newWeapon = new Weapon();
            Receiver chosenReceiver = GetReceiver();

            newWeapon.attachedComponents = new GunComponentList();

            newWeapon.attachedComponents.receiver = chosenReceiver;

            newWeapon.attachedComponents = chosenReceiver.GetItemComponents();

            //Name the item
            newWeapon.itemName = newWeapon.GetName(newWeapon);

            return newWeapon;
        }

        int receiverRNG = 0;
        int ChooseReceiver()
        {
            receiverRNG = Random.Range(0, receivers.Count);
            return receiverRNG;
        }

        string NameQuality(WorldWeapon item, int tier)
        {
            return $"{qualityTiers[tier].qualityTitle} ";
        }
    }

    [System.Serializable]
    public class GunComponentList
    {
        //[HideInInspector]
        public Receiver receiver;
        public Barrel barrel;
        public Magazine magazine;
        public Grip grip;
        public Sight sight;
        public Stock stock;

        [Header("Optional")]
        public Barrel barrelAttachment;
        public Grip foregrip;
    }

    [System.Serializable]
    public class ComponentLocations
    {
        public Transform barrelLocation;
        public Transform magazineLocation;
        public Transform gripLocation;
        public Transform sightLocation;
        public Transform stockLocation;
    }

    [System.Serializable]
    public class QualityTiers
    {
        public List<QTier> qualityTiers;
    }

    [System.Serializable]
    public class QTier
    {
        public string qualityTitle;
        public Color tierColor;
    }
}

