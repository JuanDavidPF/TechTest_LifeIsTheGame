using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "References/String", fileName = "new StringReference")]
public class StringRefence : ScriptableObject
{

    [SerializeField] private string m_value = "new String Reference";

    public string Value
    {
        get { return m_value; }
        set { m_value = value; }

    }

}//Closes StringReference Class
