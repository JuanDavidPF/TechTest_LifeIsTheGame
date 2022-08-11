using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JuanPayan
{
    public class CrossairHandler : MonoBehaviour
    {

        [SerializeField] private Image UICrossair;
        [SerializeField] private Sprite unArmedCrossair;



        public void OnNewWeapon(GameObject weaponGO)
        {
            if (!UICrossair) return;

            if (!weaponGO)
            {
                if (unArmedCrossair) UICrossair.sprite = unArmedCrossair;
                return;
            }

            Weapon weapon = weaponGO.GetComponent<Weapon>();

            if (!weapon)
            {
                if (unArmedCrossair) UICrossair.sprite = unArmedCrossair;
                return;
            }
            else if (unArmedCrossair && weapon.data && weapon.data.crossair) UICrossair.sprite = weapon.data.crossair;


        }//Closes OnNewWeapon method



    }//Closes CrossairHandler class

}//Closes namespace definition 

