using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JuanPayan.CodeSnippets
{
    public class ToggleProcessor : MonoBehaviour
    {
        [SerializeField] private bool toggleValue = false;
        [SerializeField] private UnityEvent OnTrueEvent;
        [SerializeField] private UnityEvent OnFalseEvent;


        public void ToggleInvoke()
        {
            toggleValue = !toggleValue;
            if (toggleValue) OnTrueEvent?.Invoke();
            else OnFalseEvent?.Invoke();


        }//Closes ToggleInvoke method

        public void SetToggleValue(bool value)
        {
            toggleValue = value;
        }//Closes SetToggleValue method



    }//Closes ToggleProcessor class
}//Closes Namespace Declaration 