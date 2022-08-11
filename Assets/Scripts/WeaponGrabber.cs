using System.Collections;
using System.Collections.Generic;
using JuanPayan.CodeSnippets;
using UnityEngine;

namespace JuanPayan
{
    public class WeaponGrabber : MonoBehaviour
    {
        [SerializeField] private GameObjectReference weaponEquipped;
        [SerializeField] private GameObjectReference objectBeingLookedAt;

        private Weapon m_Weapon;
        public Weapon weapon
        {
            get { return m_Weapon; }
            set
            {
                if (value == m_Weapon) return;

                if (m_Weapon) m_Weapon.Drop();
                if (value) value.Grab(transform);

                if (weaponEquipped) weaponEquipped.Value = value ? value.gameObject : null;
                m_Weapon = value;
            }
        }

        public void GrabWeapon()
        {
            if (!objectBeingLookedAt || !objectBeingLookedAt.Value) return;

            Weapon objectWeapon = null;

            objectBeingLookedAt.Value.TryGetComponent<Weapon>(out objectWeapon);

            if (objectWeapon) weapon = objectWeapon;

        }//Closes GrabWeapon method


        public void DropWeapon()
        {


            weapon = null;
        }//Closes GrabWeapon method


    }//Closes WeaponGrabber method
}//Closes namespace declaration