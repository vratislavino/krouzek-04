using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
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

    public void Die() {
        var p = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        p.Emit(300);
        Destroy(p.gameObject, 1f);
        gameObject.SetActive(false);
    }

    public virtual bool IsMoving() {
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
