using UnityEngine;

namespace SovereignGaming.WeaponForge
{
    [System.Serializable]
    public class WeaponStats
    {
        [Tooltip("What is the base damage of the weapon?")]
        public float damage;

        [Tooltip("How long (in seconds) does it take to reload?")]
        public float reloadTime;

        [Tooltip("How many shots per minute?")]
        public float fireRate;

        [Tooltip("Total number of shots before the magazine is empty")]
        public int magazineSize;

        public float bestDPS;
    }
}

