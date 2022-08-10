using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    public class FPSHeadRotationControl : MonoBehaviour
    {

        [Header("Tilt Configuration")]
        [SerializeField] private float tiltSensitivity = 400f;
        [SerializeField] private Vector2 tiltRange = new Vector2(-60f, 50f);
        private float tiltValue = 0f;


        [Space(15)]


        [Header("Pan Configuration")]
        [SerializeField] private float panSensitivity = 400f;
        [SerializeField] private Vector2 panRange = new Vector2(-90f, 90f);
        private float panValue = 0f;

        [Space(15)]
        [SerializeField] private float zMaxInclination = 15f;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void LateUpdate()
        {
            float mouseY = Input.GetAxis("Mouse Y") * tiltSensitivity * Time.deltaTime;
            tiltValue = Mathf.Clamp(tiltValue - mouseY, tiltRange.x, tiltRange.y);


            float mouseX = Input.GetAxis("Mouse X") * panSensitivity * Time.deltaTime;
            panValue = Mathf.Clamp(panValue + mouseX, panRange.x, panRange.y);



            transform.localRotation = Quaternion.Euler(tiltValue, panValue, HeadZInclination());
        }//Closes Update method

        public float HeadZInclination()
        {
            float normal = panValue > 0 ? Mathf.InverseLerp(0, panRange.y, panValue) : Mathf.InverseLerp(0, panRange.x, panValue);
            return panValue > 0 ? Mathf.Lerp(0, -zMaxInclination, normal) : Mathf.Lerp(0, zMaxInclination, normal);

        }//Closes InclineHeadSideWays

    }//Closes FPSCameraTiltControl method
}//Closes JuanPayan namespace