using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public GameObject DollReference;
    bool shouldKill = false;
    public List<Controller> players = new List<Controller>();

    // Start is called before the first frame update
    void Start()
    {
        TimeManager.Instance.StateChanged += OnStateChanged;
        players = FindObjectsOfType<Controller>().ToList();
        for(int i = 0; i < players.Count; i++) {
            players[i].PlayerWon += OnPlayerWon;
        }
        Debug.Log(players.Count);
    }

    private void OnPlayerWon(Controller ctrl) {
        players.Remove(ctrl);
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
            for (int i = 0; i < players.Count; i++) {
                Controller player = players[i];
                if (player.IsMoving()) {
                    player.Die(DollReference.transform.position);
                    players.Remove(player);
                }
            }
            //shouldKill = false;
        }
    }
}
