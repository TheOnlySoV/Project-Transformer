using UnityEngine;

/// <summary>
/// Stat modifiers for a magazine component can be added here.
/// 
/// Requires a bullet to be attached.
/// </summary>

namespace SovereignGaming.WeaponForge
{
    [CreateAssetMenu(fileName = "New Magazine", menuName = "My Assets/Components/New Magazine")]
    public class Magazine : GunComponent
    {
        public Bullet bullet;
    }
}
