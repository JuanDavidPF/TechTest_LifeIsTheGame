using System.Collections;
using System.Collections.Generic;
using JuanPayan.CodeSnippets;
using UnityEngine;

namespace JuanPayan
{

    [RequireComponent(typeof(Rigidbody))]

    public class Weapon : MonoBehaviour, IGrabbable
    {
        public WeaponData data;

        private Vector3 originalScale;

        private Rigidbody m_objectRigidBody;

        private void Awake()
        {
            m_objectRigidBody = m_objectRigidBody ? m_objectRigidBody : GetComponent<Rigidbody>();
            originalScale = transform.localScale;
        }//Closes Awake method


        public void Drop()
        {

            transform.SetParent(null);
            transform.localScale = originalScale;

            if (m_objectRigidBody)
            {
                m_objectRigidBody.isKinematic = false;





                m_objectRigidBody.AddForceAtPosition(transform.forward * 20, transform.position, ForceMode.Impulse);
            }

            gameObject.SetLayerRecursively(0);


        }//Closes Drop method


        public void Grab(Transform grabSlot)
        {

            if (m_objectRigidBody) m_objectRigidBody.isKinematic = true;

            transform.SetParent(grabSlot);
            transform.localScale = originalScale;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localPosition = Vector3.zero;

            gameObject.SetLayerRecursively(7);
        }//Closes Drop method


    }//Closes Pickeable class
}//Closes Weapoing class

