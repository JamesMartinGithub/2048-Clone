using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerManagerScript : MonoBehaviour
{
    public boxManager script;
    public float delay;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void pauseInput() {
        script.enabled = false;
        Invoke("reEnable", delay);
    }
    private void reEnable() {
        script.enabled = true;
    }
}