using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorParameter : MonoBehaviour
{
    private Animator animator;

    public string parameterName;
    public float x = 1;
    public float y = -1;
    public float waitTime = 0f;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        //Invoke("ToggleAnimatorParameter", waitTime);
        ToggleXDirection();
        ToggleYDirection();
    }
    private void Update()
    {
        Invoke("ToggleAnimatorParameter", waitTime);
    }


    public void ToggleAnimatorParameter()
    {
        animator.SetBool(parameterName, true);
        //animator.SetTrigger("Clicked");
    }

    public void ToggleXDirection()
    {
        animator.SetFloat("X", x);
    }
    public void ToggleYDirection()
    {
        animator.SetFloat("Y", y);
    }
}
