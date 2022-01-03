using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    bool soundOn = true;
    public bool SoundOn => soundOn;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();    
    }

    public void SwitchSound() {
        soundOn = !soundOn;
        UpdateSound();
    }

    private void UpdateSound() {
        if(soundOn) {
            text.text = "Sound On";
        } else {
            text.text = "Sound Off";
        }
    }
}
