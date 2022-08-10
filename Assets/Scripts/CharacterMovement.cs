using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovement : MonoBehaviour
    {

        [SerializeField] Rigidbody _rigidBody;

        float _speed;
        [SerializeField] float _speedMovement;
        [SerializeField] float _sprintSpeedIncrease;

        Rigidbody rigidBody
        {
            get
            {
                if (!_rigidBody) Debug.LogWarning("component rigidBody wasn't binded, trying to locate it");
                _rigidBody = GetComponent<Rigidbody>();
                if (!_rigidBody) Debug.LogError("rigidBody doesn't exists");
                return _rigidBody;
            }
        }




        // Update is called once per frame
        void FixedUpdate()
        {
            _speed = _speedMovement;

            if (Input.GetKey(KeyCode.LeftShift)) _speed *= _sprintSpeedIncrease;
            MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        }
        private void MoveCharacter(Vector3 direction)
        {
            rigidBody.AddForce(direction * _speed, ForceMode.Impulse);

        }//Closes MoveCharacter method



    }//Closes CharacterMovement class
}//Closes NameSpace declaration