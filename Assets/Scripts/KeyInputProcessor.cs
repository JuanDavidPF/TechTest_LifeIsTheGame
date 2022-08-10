using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JuanPayan.CodeSnippets
{
    public class KeyInputProcessor : MonoBehaviour
    {
        [SerializeField] private List<KeyCode> inputs = new List<KeyCode>();
        [SerializeField] private bool allowSimultaneousCalls;
        [SerializeField] private UnityEvent processes;

        private void Update()
        {
            foreach (var input in inputs)
            {
                if (Input.GetKeyDown(input))
                {
                    processes?.Invoke();
                    if (!allowSimultaneousCalls) break;
                }
            }
        }//Closes Update methods


    }//Closes KeyInputProcessor class
}//Closes Namespace Declaration 