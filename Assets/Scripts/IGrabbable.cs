using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuanPayan
{
    interface IGrabbable
    {

        public abstract void Drop();



        public void Grab(Transform grabSlot);

    }//Closes IGrabbable interface
}