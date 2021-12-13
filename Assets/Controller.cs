using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    protected MoveController moveController;

    // Start is called before the first frame update
    public virtual void Start()
    {
        moveController = GetComponent<MoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
