using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class DanceManager : MonoBehaviour
{

    public StringRefence selectedDance
    {
        set
        {
            if (!value) return;
            if (m_selectedDance) m_selectedDance.Value = value.Value;
            if (m_animator) m_animator.Play(value.Value);
        }
    }



    [SerializeField] private Animator m_animator;

    [SerializeField] private StringRefence m_selectedDance;



    private void Awake()
    {
        if (!m_animator) m_animator = GetComponent<Animator>();
        Dance(m_selectedDance);
    }//Closes Awake method

    public void Dance(StringRefence danceID)
    {
        if (!danceID) return;
        selectedDance = danceID;
    }//Closes Dance method

}//Closes DanceManager Class
