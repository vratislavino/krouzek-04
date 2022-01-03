using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vrata;

public class TimeManager : MonoBehaviour
{
    public event Action<bool> StateChanged;

    private new AudioSource audio;
    public SoundController soundController;

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
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > TurnInterval) {
            CanGo = !canGo;
            TurnInterval = UnityEngine.Random.Range(0.5f, 2f);
            if(canGo && soundController.SoundOn) {
                PlaySound();
            }
            time = 0;
        }
    }

    private void PlaySound() {

        var clipLen = audio.clip.length;
        // 5s
        var ratio = TurnInterval / clipLen;
        audio.pitch = 1 / ratio;

        audio.Play();
    }
}
