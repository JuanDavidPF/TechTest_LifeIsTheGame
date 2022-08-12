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

        public Transform nozzleTransform;

        public ParticleSystem nozzleFlash;

        private float rate;

        private Queue<Rigidbody> magazine = new Queue<Rigidbody>();

        private void Awake()
        {

            m_objectRigidBody = m_objectRigidBody ? m_objectRigidBody : GetComponent<Rigidbody>();
            originalScale = transform.localScale;

            LoadBulletsPool();
        }//Closes Awake method


        private void Update()
        {
            HandleWeaponRate();
        }


        private void HandleWeaponRate()
        {
            if (rate > 0) rate -= Time.deltaTime;
            if (rate < 0) rate = 0;
        }

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

        public void LoadBulletsPool()
        {
            if (!data || !data.bullet || !nozzleTransform) return;

            for (int i = 0; i < data.magazineSize; i++)
            {
                GameObject bullet = Instantiate(data.bullet, nozzleTransform.position, transform.rotation);
                bullet.SetActive(false);
                magazine.Enqueue(bullet.GetComponent<Rigidbody>());
            }

        }//Closes LoadBulletsPool method



        public void Shoot()
        {
            if (!data || !nozzleTransform) return;
            if (rate > 0) return;

            if (nozzleFlash) nozzleFlash.Play();
            rate = data.cooldown;


            Rigidbody bullet = magazine.Dequeue();
            magazine.Enqueue(bullet);

            bullet.velocity = Vector3.zero;
            bullet.transform.position = nozzleTransform.position;
            bullet.transform.rotation = nozzleTransform.rotation;

            bullet.gameObject.SetActive(true);
            bullet.AddForce(nozzleTransform.forward * data.firePower, ForceMode.Impulse);


        }//Closes Shoot Method




    }//Closes Pickeable class
}//Closes Weapoing class

