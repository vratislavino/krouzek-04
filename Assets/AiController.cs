using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : Controller
{
    private bool canGo = false;

    public float speedMultiplier = 1;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        speedMultiplier = Random.Range(0.9f, 1.2f);
        TimeManager.Instance.StateChanged += OnStateChanged;   
    }

    private void OnStateChanged(bool canGo) {
        
        if(!canGo) {
            if(Random.Range(0,10) < 5) {
                this.canGo = canGo;
            } else {
                Invoke("TryToStop", Random.Range(0.1f, 0.3f));
            }
        } else {
            this.canGo = canGo;
        }
        // TimeManager.Instance.CanGo;
    }
    
    private void TryToStop() {
        this.canGo = false;
    }

    public override bool IsMoving() {
        return canGo;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Capsule (2)") {
            Debug.Log(rigidbody.velocity.magnitude);
        }

        if (canGo)
            moveController.Move(Time.deltaTime * speedMultiplier);
    }
}
