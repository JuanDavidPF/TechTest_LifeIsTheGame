using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockModeSetter : MonoBehaviour
{
    [SerializeField] CursorLockMode lockMode;

    public void SetIt()
    {
        Cursor.lockState = lockMode;
    }
}//Closes CursorLockModeSetter
