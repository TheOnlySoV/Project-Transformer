using UnityEngine;

/// <summary>
/// The blueprint for all gun attachments. It requires a component mesh. 
/// 
/// If you would like to generate a unique name for each created weapon, you can add component titles as you create them. 
/// These get appended together to create the weapon name.
/// </summary>

namespace SovereignGaming.WeaponForge
{
    public class GunComponent : ScriptableObject
    {
        public ComponentSlot slot;
        public GameObject myComponentMesh;

        public string componentTitle;
    }

    public enum ComponentSlot { Receiver, Barrel, Magazine, Grip, Sight, Stock, BarrelAttachment, Foregrip }
}