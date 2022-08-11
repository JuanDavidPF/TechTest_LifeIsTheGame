using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JuanPayan.CodeSnippets
{

    public class GameObjectReferenceListener : MonoBehaviour
    {
        [SerializeField] private GameObjectReference gameObjectReference;
        [SerializeField] private bool preInvoke;
        [SerializeField] private UnityEvent<GameObject> processes;

        private void OnEnable()
        {
            if (!gameObjectReference) return;
            if (preInvoke) ExecuteProcesses(gameObjectReference.Value);

            gameObjectReference.OnValueChanged += ExecuteProcesses;
        }//Closes OnEnable method

        public void ExecuteProcesses(GameObject Value)
        {
            processes?.Invoke(Value);
        }//Closes ExecuteProcesses
        private void OnDisable()
        {
            if (!gameObjectReference) return;
            gameObjectReference.OnValueChanged -= ExecuteProcesses;
        }//Closes OnDisable method

    }//Closes StringReferenceListener
}//Closes NameSpace declaration