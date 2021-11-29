using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public PlayerMovement playerMovemnt;
    private float startTime;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovemnt.finished == false && playerMovemnt.started)
        {
            if (playerMovemnt.isBadGrounded)
            {
                startTime = Time.time;
            }
            t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            float s = t % 60;

            if (s < 10)
            {
                string seconds = s.ToString("f3");
                timerText.text = minutes + ":0" + seconds.Substring(0, 1) + ":" + seconds.Substring(2);
            }
            else
            {
                string seconds = s.ToString("f3");
                timerText.text = minutes + ":" + seconds.Substring(0, 2) + ":" + seconds.Substring(3);
            }
        }
        else
        {
            startTime = Time.time;
            timerText.text = "0:00:000";
        }
    }
}
