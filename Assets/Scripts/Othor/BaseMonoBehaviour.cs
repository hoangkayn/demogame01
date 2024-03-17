using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour
{
    private void Reset()
    {
        LoadComponent();
        ResetValue();

    }

    protected virtual void ResetValue()
    {
       
    }

    protected virtual void LoadComponent()
    {
        //to do
    }
    protected virtual void Awake()
    {
        LoadComponent();
    }
    protected virtual void Start() {

        //to do
    }


  
}
