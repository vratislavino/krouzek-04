using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public event Action<bool> StateChanged;

    private static TimeManager instance;
    public static TimeManager Instance {
        get { 
            if(instance == null) {
                instance = new GameObject("TimeManager").AddComponent<TimeManager>();
            }
            return instance; 
        }
    }

    public float TurnInterval;

    private float time = 0;
    private bool canGo = false;

    public bool CanGo {
        get { return canGo; }
        set {
            canGo = value;
            StateChanged?.Invoke(canGo);
        }
    }

    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > TurnInterval) {
            CanGo = !canGo;
            TurnInterval = UnityEngine.Random.Range(0.5f, 2f);
            time = 0;
        }
    }
}
