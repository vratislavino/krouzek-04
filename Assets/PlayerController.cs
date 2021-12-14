using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    bool isMoving = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override bool IsMoving() {
        return isMoving;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            moveController.Move(Time.deltaTime * 2f);
            isMoving = true;
        } else {
            isMoving = false;
        }
    }
}
