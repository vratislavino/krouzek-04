using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        TimeManager.Instance.StateChanged += OnStateChanged;   
    }

    private void OnStateChanged(bool cango) {
        if (cango) {
            anim.SetTrigger("TurnGreen");
        } else {
            anim.SetTrigger("TurnRed");
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
