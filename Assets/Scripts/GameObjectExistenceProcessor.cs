using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JuanPayan.CodeSnippets
{
    public class GameObjectExistenceProcessor : MonoBehaviour
    {

        [SerializeField] UnityEvent onExistsProcesses;
        [SerializeField] UnityEvent onNonExistsProcesses;

        public void Evaluate(GameObject objectToEvaluate)
        {
            if (objectToEvaluate) onExistsProcesses?.Invoke();
            else onNonExistsProcesses?.Invoke();

        }//Closes Evaluate method

    }//Closes Update methods


}//Closes Namespace Declaration 