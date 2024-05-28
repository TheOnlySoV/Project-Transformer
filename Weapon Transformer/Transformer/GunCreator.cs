using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This method goes on anything that will drop an item. This is to create the item. What you do with it is up to you.
/// 
/// The spawn location will determine where the loot spawns from.
/// 
/// If you have another script derive from this one, you can also set a torque and force value on the rigidbody in the direction of the object
/// to "Shoot" the weapon out in a direction.
/// </summary>
/// <returns></returns>

namespace SovereignGaming.WeaponForge
{
    public class GunCreator : MonoBehaviour
    {
        public Transform spawnLocation;

        public Forge forge;

        public GameObject SpawnWeapon()
        {
            if (!spawnLocation)
                spawnLocation = transform;

            Weapon newWeapon = GetNewWeapon();

            GameObject spawnedWeapon = Instantiate(newWeapon.attachedComponents.receiver.myComponentMesh, spawnLocation);

            return spawnedWeapon;
        }

        public Weapon GetNewWeapon()
        {
            return forge.GetWeapon();
        }
    }

    public enum GunType { AssaultRifle, SubmachineGun, Pistol, Shotgun, Rifle }
}