using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        TimeManager.Instance.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(bool canGo) {
        if(TimeManager.Instance.CanGo) {
            rend.material.color = Color.green;
        } else {
            rend.material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
