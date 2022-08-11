using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    public class FPSCrouchControl : MonoBehaviour
    {

        [SerializeField] private Transform torso;
        [SerializeField] private Vector3 crouchPosition;
        [SerializeField] private Vector3 unCrouchPosition;


        public void Crouch()
        {
            if (!torso) return;
            torso.localPosition = crouchPosition;

        }//Closes Crouch method
        public void UnCrouch()
        {
            if (!torso) return;
            torso.localPosition = unCrouchPosition;
        }//Closes UnCrouch method


    }//Closes FPSCrouchControl class
}//Closes namespace JuanPayan