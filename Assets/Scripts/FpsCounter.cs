using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    public double updateInterval = 0.1;
    private double lastInterval;
    private int frames = 0;
    private double fps;
    
    private Text text;

    void Start() {
        text = GetComponent<Text>();
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }
    void Update() {
        ++frames;
        double timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval) {
            fps = frames / (timeNow - lastInterval);
            text.text = "fps: " + fps.ToString("F2");
            frames = 0;
            lastInterval = timeNow;
        }
    }
}
