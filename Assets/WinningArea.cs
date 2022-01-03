using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        var player = other.GetComponent<Controller>();
        if(player != null) {
            player.Win();
        }
    }
}
