using UnityEngine;

/// <summary>
/// Attached to the magazine. 
/// You can put things in here like bullet effects and/or prefabs of the bullet object.
/// </summary>

namespace SovereignGaming.WeaponForge
{
    [CreateAssetMenu(fileName = "New Bullet", menuName = "My Assets/Bullet")]
    public class Bullet : GunComponent
    {
        public BulletType bulletType;
    }
    public enum BulletType { Heavy, Medium, Light }
}
