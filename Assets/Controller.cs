using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public event Action<Controller> PlayerWon;

    protected MoveController moveController;
    protected new Rigidbody rigidbody;

    public ParticleSystem DeathEffect;

    public Rigidbody Rigidbody => rigidbody;

    // Start is called before the first frame update
    public virtual void Start()
    {
        moveController = GetComponent<MoveController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Win() {
        PlayerWon?.Invoke(this);
        enabled = false;
    }

    public void Die(Vector3 dollPos) {
        var p = Instantiate(DeathEffect, transform.position, transform.rotation * Quaternion.Euler(0,180,0));
        p.Emit(1);
        Destroy(p.gameObject, 1f);
        //transform.Rotate(transform.position - Vector3.up * 0.5f, 90);

        var dir = transform.position - dollPos;
        dir.Normalize();

        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.AddForce(dir*10, ForceMode.Impulse);
        //Destroy(gameObject, 1f);
        //gameObject.SetActive(false);
        enabled = false;
    }

    public virtual bool IsMoving() {
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
