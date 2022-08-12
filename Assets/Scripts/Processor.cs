using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Processor : MonoBehaviour
{
    [System.Flags]
    public enum Trigger
    {
        Awake = 0,
        OnEnable = 1,
        Start = 2,
        Update = 3,
        OnDisable = 4,
        OnDestroy = 5,
        OnMouseEnter = 6,
        OnMouseDown = 7,
        OnMouseOver = 9,
        OnMouseHold = 10,
        OnMouseExit = 11,
        OnMouseUp = 12,

    }

    [SerializeField] private UnityEvent processes;
    [SerializeField] private Trigger trigger;


    private void Awake()
    {
        if (trigger.HasFlag(Trigger.Awake)) processes?.Invoke();
    }
    private void Start()
    {
        if (trigger.HasFlag(Trigger.Start)) processes?.Invoke();

    }

    private void Update()
    {
        if (trigger.HasFlag(Trigger.Update)) processes?.Invoke();

    }


    private void OnDisable()
    {
        if (trigger.HasFlag(Trigger.OnDisable)) processes?.Invoke();

    }
}//Closes Processor method
