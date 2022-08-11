using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan.CodeSnippets
{
    public static class LayerChanger
    {
        public static void SetLayerRecursively(this GameObject obj, int newLayer)
        {
            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }//Closes SetLayerRecursively method

    }//Closes Layer Changer class
}//Closes namespace declaration