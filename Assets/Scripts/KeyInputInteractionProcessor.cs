using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JuanPayan.CodeSnippets
{
    public class KeyInputInteractionProcessor : MonoBehaviour
    {
        [System.Flags]
        public enum Interactions
        {
            OnKeyDown = 1 << 0,
            OnKeyHold = 1 << 1,
            OnKeyUp = 1 << 2,
        }



        [SerializeField] Interactions interaction;
        [SerializeField] private KeyCode input;

        [SerializeField] private UnityEvent keyDownProcesses;
        [SerializeField] private UnityEvent keyHoldProcesses;
        [SerializeField] private UnityEvent keyUpProcesses;

        private void Update()
        {

            if (interaction.HasFlag(Interactions.OnKeyDown) && Input.GetKeyDown(input))
            {
                keyDownProcesses?.Invoke();
            }

            if (interaction.HasFlag(Interactions.OnKeyHold) && Input.GetKey(input))
            {
                keyHoldProcesses?.Invoke();
            }

            if (interaction.HasFlag(Interactions.OnKeyUp) && Input.GetKeyUp(input))
            {
                keyUpProcesses?.Invoke();
            }

        }//Closes Update methods


    }//Closes KeyInputProcessor class
}//Closes Namespace Declaration 