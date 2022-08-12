using System.Collections;
using System.Collections.Generic;
using JuanPayan.CodeSnippets;
using UnityEngine;


namespace JuanPayan
{
    public class WeaponShooter : MonoBehaviour
    {

        private Weapon weaponEquipped = null;

        public void UpdateWeapon(GameObject weaponGameobject)
        {
            if (!weaponGameobject)
            {
                weaponEquipped = null;
                return;
            }

            weaponEquipped = weaponGameobject.GetComponent<Weapon>();
        }//Closes UpdateWeapon method

        public void PullTrigger()
        {
            if (!weaponEquipped || !weaponEquipped.data) return;

        }//Closes PullTrigger method


        private void Update()
        {
            if (!weaponEquipped || !weaponEquipped.data) return;


            if (weaponEquipped.data.firemode == WeaponData.Firemode.automatic)
            {
                if (Input.GetMouseButton(0)) weaponEquipped.Shoot();
            }
            else if (Input.GetMouseButtonDown(0)) weaponEquipped.Shoot();
        }//Closes Update method

    }//Closes class WeaponShooter 


}//Closes namespace delcaration