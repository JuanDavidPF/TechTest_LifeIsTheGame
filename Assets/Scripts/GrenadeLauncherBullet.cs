using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    public class GrenadeLauncherBullet : ProjectileHandler
    {

        [SerializeField] private float explotionForce;
        [SerializeField] private float explotionRadius;
        [SerializeField] private float explotionLift;





        protected override void OnCollisionEnter(Collision other)
        {

            if (other.relativeVelocity.magnitude > minimumColissionForce) Explotion();
        }


        private void Explotion()
        {

            foreach (Collider hit in Physics.OverlapSphere(transform.position, explotionRadius))
            {
                Rigidbody rigidBody = hit.GetComponent<Rigidbody>();
                if (rigidBody) rigidBody.AddExplosionForce(explotionForce, transform.position, explotionRadius, explotionLift);

            }


            EmitParticles();


        }//Closes Explotion metho


    }//Closes GrenadeLauncherBullet class
}//Closes namespace declaration