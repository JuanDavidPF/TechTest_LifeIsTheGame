using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSMovementControl : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private float movementSpeed = 20f;
        [SerializeField] private float sprintMultiplier = 1.7f;
        [SerializeField] private float crouchMultiplier = 0.5f;

        private void Awake()
        {
            controller = controller ? controller : GetComponent<CharacterController>();
        }//Closes Awake method

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (x == 0 && z == 0) return;

            float speedMultiplier = 1;

            if (Input.GetKey(KeyCode.LeftShift)) speedMultiplier *= sprintMultiplier;
            if (Input.GetKey(KeyCode.LeftControl)) speedMultiplier *= crouchMultiplier;


            Vector3 move = transform.right * x + transform.forward * z;
            if (controller) controller.Move(move * (movementSpeed * speedMultiplier) * Time.deltaTime);

        }//Closes Update Method


    }//Closes FPSMovementRotationControl method
}//Closes namespace declaration