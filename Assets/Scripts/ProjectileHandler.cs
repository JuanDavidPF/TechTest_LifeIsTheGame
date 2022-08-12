using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public abstract class ProjectileHandler : MonoBehaviour
    {

        [SerializeField] protected float minimumColissionForce = 0f;


        [SerializeField] protected ParticleSystem onExplosionVfx;
        [SerializeField] private int vfxPoolSize = 5;

        protected Queue<ParticleSystem> vfxPool = new Queue<ParticleSystem>();

        protected new Rigidbody rigidbody;

        protected virtual void Awake()
        {
            Physics.IgnoreLayerCollision(8, 8);
            Physics.IgnoreLayerCollision(7, 8);
            rigidbody = rigidbody ? rigidbody : GetComponent<Rigidbody>();

            if (!onExplosionVfx) return;
            for (int i = 0; i < vfxPoolSize; i++)
            {
                ParticleSystem vfx = Instantiate(onExplosionVfx, transform.position, transform.rotation);
                vfx.gameObject.SetActive(false);
                vfxPool.Enqueue(vfx);
            }
        }

        protected void EmitParticles()
        {

            ParticleSystem vfx = null;
            if (vfxPool.Count > 0) vfx = vfxPool.Dequeue();
            vfxPool.Enqueue(vfx);

            if (!vfx) return;
            vfx.gameObject.SetActive(true);
            vfx.Stop();
            vfx.gameObject.transform.position = transform.position;
            vfx.gameObject.transform.rotation = transform.rotation;
            vfx.Play();
        }

        protected abstract void OnCollisionEnter(Collision other);


    }//Closes ProjectileHandler class
}//Closes namespace declaretion