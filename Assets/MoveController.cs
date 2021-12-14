using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private void Start() {
    }

    public void Move(float speed) {
        transform.Translate(Vector3.forward * speed);
    }
}
