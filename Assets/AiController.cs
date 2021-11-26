using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    private bool canGo = false;
    private MoveController moveController;
    // Start is called before the first frame update
    void Start()
    {
        TimeManager.Instance.StateChanged += OnStateChanged;
        moveController = GetComponent<MoveController>();
    }

    private void OnStateChanged(bool canGo) {
        this.canGo = canGo; // TimeManager.Instance.CanGo;
    }

    // Update is called once per frame
    void Update()
    {
        if (canGo)
            moveController.Move(Time.deltaTime);
    }
}
