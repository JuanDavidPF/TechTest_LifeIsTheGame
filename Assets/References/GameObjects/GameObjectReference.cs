using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JuanPayan.CodeSnippets
{

    [CreateAssetMenu(menuName = "References/GameObject", fileName = "new GameObjectReference")]
    public class GameObjectReference : ScriptableObject
    {

        [SerializeField] private GameObject m_value;
        public Action<GameObject> OnValueChanged;

        public GameObject Value
        {
            get { return m_value; }
            set
            {
                if (value == m_value) return;
                m_value = value;
                InvokeValueEvent();
            }

        }

        public void InvokeValueEvent()
        {
            OnValueChanged?.Invoke(Value);
        }//Closes InvokeValueEvent method

    }//Closes StringReference Class

}//Closes Namespace declaration