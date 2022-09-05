using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IgnoreTargetAtBack : MonoBehaviour
{
    [SerializeField] Transform back;
    [SerializeField] Rig rigToIgnore;


    private void LateUpdate()
    {
        if (!rigToIgnore || !back) return;


        float value = Vector3.Dot((back.position - transform.position).normalized, -transform.forward);


        if (value <= 0) rigToIgnore.weight = value + .75f;






    }
}//Close IgnoreTargetBack class
