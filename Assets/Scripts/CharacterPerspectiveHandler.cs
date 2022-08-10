using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JuanPayan
{
    [RequireComponent(typeof(Camera))]
    public class CharacterPerspectiveHandler : MonoBehaviour
    {

        [SerializeField] private Camera m_Camera;
        private void Awake()
        {
            if (!m_Camera) m_Camera = GetComponent<Camera>();

        }//Closes Awake method

    }//Closes CharacterPerspectiveHandler class
}//Closes NameSpace declaration
