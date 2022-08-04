using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationParameters : MonoBehaviour
{
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.SetFloat("speed", 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            _animator.SetTrigger("melee");
        }
    }

    public void Damage()
    {
        Debug.Log("Damage!");
    }
}
