using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    public class BlackHole : ProjectileHandler
    {

        [SerializeField] private float lifespan = 10;

        [SerializeField] private float pullForce = 100;

        private void OnEnable()
        {
            StartCoroutine(HandleLifeSpan());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        protected override void OnCollisionEnter(Collision other)
        {
            rigidbody.isKinematic = true;
            Destroy(other.gameObject);
            EmitParticles();
        }

        private void OnTriggerStay(Collider other)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (!rb) return;
            Vector3 forceDirection = transform.position - other.transform.position;
            rb.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
        }//Closes OnTriggerEnter



        private IEnumerator HandleLifeSpan()
        {
            yield return new WaitForSeconds(lifespan);
            gameObject.SetActive(false);

        }//Closes HandleLifeSpan coroutine


    }//Closes GrenadeLauncherBullet class
}//Closes namespace declaration