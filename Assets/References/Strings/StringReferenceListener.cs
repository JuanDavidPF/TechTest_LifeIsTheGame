using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JuanPayan.CodeSnippets
{

    public class StringReferenceListener : MonoBehaviour
    {
        [SerializeField] private StringRefence stringReference;
        [SerializeField] private bool preInvoke;
        [SerializeField] private UnityEvent<string> processes;

        private void OnEnable()
        {
            if (!stringReference) return;
            if (preInvoke) ExecuteProcesses(stringReference.Value);

            stringReference.OnValueChanged += ExecuteProcesses;
        }//Closes OnEnable method

        private void ExecuteProcesses(string Value)
        {
            processes?.Invoke(Value);
        }//Closes ExecuteProcesses

        private void OnDisable()
        {
            if (!stringReference) return;
            stringReference.OnValueChanged -= ExecuteProcesses;
        }//Closes OnDisable method

    }//Closes StringReferenceListener
}//Closes NameSpace declaration