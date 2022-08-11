using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    public class FPSMovementRotationControl : MonoBehaviour
    {
        [SerializeField] private float rotationSensitivity = 400f;



        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSensitivity * Time.deltaTime;

            transform.Rotate(Vector3.up * mouseX);

        }//Closes Update Method


    }//Closes FPSMovementRotationControl method
}//Closes namespace declaration