using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Killer : MonoBehaviour
{
    bool shouldKill = false;
    List<Controller> players = new List<Controller>();

    // Start is called before the first frame update
    void Start()
    {
        TimeManager.Instance.StateChanged += OnStateChanged;
        players = FindObjectsOfType<Controller>().ToList();
        Debug.Log(players.Count);
    }

    private void OnStateChanged(bool canMove) {
        if(!canMove) {
            Invoke("StartKilling", 0.05f);
        } else {
            shouldKill = false;
        }
    }

    private void StartKilling() {
        shouldKill = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldKill) {
            foreach(var player in players) {
                if(player.IsMoving()) {
                    player.Die();
                }
            }
        }
    }
}
