using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JuanPayan.CodeSnippets
{

    [CreateAssetMenu(menuName = "References/String", fileName = "new StringReference")]
    public class StringRefence : ScriptableObject
    {

        [SerializeField] private string m_value = "new String Reference";
        public Action<string> OnValueChanged;

        public string Value
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