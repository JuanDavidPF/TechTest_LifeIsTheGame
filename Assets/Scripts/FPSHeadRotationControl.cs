using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    public class FPSHeadRotationControl : MonoBehaviour
    {
        public static Transform headTransform;

        [Header("Tilt Configuration")]

        [SerializeField] private bool allowTilt = true;
        [SerializeField] private float tiltSensitivity = 400f;
        [SerializeField] private Vector2 tiltRange = new Vector2(-60f, 50f);
        public static float tiltValue = 0f;


        [Space(15)]


        [Header("Pan Configuration")]

        [SerializeField] private bool allowPan = true;
        [SerializeField] private float panSensitivity = 400f;
        [SerializeField] private Vector2 panRange = new Vector2(-90f, 90f);
        public static float panValue = 0f;

        [Space(15)]
        [SerializeField] private float zMaxInclination = 15f;

        private void Awake()
        {

            headTransform = transform;
        }

        private void LateUpdate()
        {

            if (allowTilt)
            {
                float mouseY = Input.GetAxis("Mouse Y") * tiltSensitivity * Time.deltaTime;
                tiltValue = Mathf.Clamp(tiltValue - mouseY, tiltRange.x, tiltRange.y);
            }

            if (allowPan)
            {
                float mouseX = Input.GetAxis("Mouse X") * panSensitivity * Time.deltaTime;
                panValue = Mathf.Clamp(panValue + mouseX, panRange.x, panRange.y);
            }

            headTransform.localRotation = Quaternion.Euler(tiltValue, panValue, HeadZInclination());
        }//Closes Update method

        public float HeadZInclination()
        {
            float normal = panValue > 0 ? Mathf.InverseLerp(0, panRange.y, panValue) : Mathf.InverseLerp(0, panRange.x, panValue);
            return panValue > 0 ? Mathf.Lerp(0, -zMaxInclination, normal) : Mathf.Lerp(0, zMaxInclination, normal);

        }//Closes InclineHeadSideWays

    }//Closes FPSCameraTiltControl method
}//Closes JuanPayan namespace