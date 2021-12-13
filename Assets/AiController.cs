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
        this.canGo = canGo; // TimeManager.Instance.CanGo;
    }

    // Update is called once per frame
    void Update()
    {
        if (canGo)
            moveController.Move(Time.deltaTime * speedMultiplier);
    }
}
