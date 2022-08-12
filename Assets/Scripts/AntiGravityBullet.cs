using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    public class AntiGravityBullet : ProjectileHandler
    {
        public class GravityModifier
        {
            public AntiGravityBullet modifiedBy;
            public Rigidbody modifiedRigidBody;
            public Vector2 originalValues;


            public GravityModifier(Rigidbody modifiedRigidBody, Vector2 originalValues)
            {

                this.modifiedRigidBody = modifiedRigidBody;
                this.originalValues = originalValues;
            }


        }

        [SerializeField] private float gravDuration = 1;

        [SerializeField] private ForceMode liftMode;
        [SerializeField] private float liftForce = 00;


        [SerializeField] private ForceMode torqueMode;
        [SerializeField] private float torqueForce = 200;

        [SerializeField] private float dragAmount = 20;
        [SerializeField] private float angularDragAmount = 20;

        private static Dictionary<Rigidbody, GravityModifier> affectedElements = new Dictionary<Rigidbody, GravityModifier>();
        protected override void OnCollisionEnter(Collision other)
        {


            Rigidbody rigidBody = other.gameObject.GetComponent<Rigidbody>();
            if (!rigidBody) return;

            if (!affectedElements.ContainsKey(rigidBody)) affectedElements.Add(rigidBody, new GravityModifier(rigidBody, new Vector2(rigidBody.drag, rigidBody.angularDrag)));

            affectedElements[rigidBody].modifiedBy = this;



            StartCoroutine(RestorePhysicality(rigidBody));
            rigidBody.drag = dragAmount;
            rigidBody.angularDrag = angularDragAmount;
            rigidBody.AddTorque(new Vector3(torqueForce, torqueForce, torqueForce), torqueMode);
            rigidBody.AddForce(Vector3.up * liftForce, liftMode);


            EmitParticles();
        }


        private IEnumerator RestorePhysicality(Rigidbody rigidBody)
        {
            if (!rigidBody) yield break;
            yield return new WaitForSeconds(gravDuration);

            GravityModifier modifierInfo = null;
            affectedElements.TryGetValue(rigidBody, out modifierInfo);

            if (modifierInfo == null || modifierInfo.modifiedBy != this) yield break;

            affectedElements.Remove(rigidBody);
            rigidBody.drag = modifierInfo.originalValues.x;
            rigidBody.angularDrag = modifierInfo.originalValues.y;

        }


    }//Closes GrenadeLauncherBullet class
}//Closes namespace declaration