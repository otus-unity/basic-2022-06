using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.parent.name);
        Debug.Log(transform.childCount);
        Debug.Log(transform.GetChild(0));
    }
}