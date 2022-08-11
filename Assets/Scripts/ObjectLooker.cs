using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JuanPayan.CodeSnippets;
namespace JuanPayan
{

    public class ObjectLooker : MonoBehaviour
    {
        // [SerializeField] private Transform grabberTransform;
        // [SerializeField] private KeyCode grabKey;
        // [SerializeField] private KeyCode dropKey;
        [SerializeField] GameObjectReference objectBeingLooked;
        [SerializeField] private List<string> allowedTags = new List<string>();
        [SerializeField] private float reachDistance = 4f;
        RaycastHit grabberInformation;

        // private Grabbable grabbedObject;



        private void Update()
        {
            // TryToGrab();
            // if (Input.GetKeyDown(dropKey)) Drop();
            if (objectBeingLooked) objectBeingLooked.Value = null;

            if (Physics.Raycast(transform.position, transform.forward, out grabberInformation, reachDistance))
            {

                if (!allowedTags.Contains(grabberInformation.collider.gameObject.tag)) return;

                if (objectBeingLooked) objectBeingLooked.Value = grabberInformation.collider.gameObject as GameObject;
                // string tag = grabberInformation.collider.gameObject.tag;

                // switch (tag)
                // {
                //     case "Equippable":
                //         GetEquippable(grabberInformation.collider.gameObject);
                //         break;

                //     case "Weaponizable":
                //         GetEquippable(grabberInformation.collider.gameObject);
                //         break;
                // }

            }


        }//Closes Update method


        private void TryToGrab()
        {
            // if (!grabberTransform) return;


            if (Physics.Raycast(transform.position, transform.forward, out grabberInformation, reachDistance))
            {
                // string tag = grabberInformation.collider.gameObject.tag;

                // switch (tag)
                // {
                //     case "Equippable":
                //         GetEquippable(grabberInformation.collider.gameObject);
                //         break;

                //     case "Weaponizable":
                //         GetEquippable(grabberInformation.collider.gameObject);
                //         break;
                // }

            }

        }//Closes TryToGrab method


        private void GetEquippable(GameObject objectToEquip)
        {
            // Grabbable grabbable = grabberInformation.collider.GetComponent<Grabbable>();


            // if (Input.GetKeyDown(grabKey) && grabbable)
            // {

            //     if (grabbedObject) grabbedObject.Drop(transform);
            //     grabbedObject = grabbable;
            //     grabbable.Grab(grabberTransform);
            // }

        }//Closes GetEquipable method


        private void Drop()
        {

            // if (grabbedObject) grabbedObject.Drop(transform);
        }//Closes TryToGrab method

    }//Closes PickeablePicker class
}//Closes namespace declaration
