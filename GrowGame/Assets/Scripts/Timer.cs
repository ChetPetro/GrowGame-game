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
        if (playerMovemnt.finished == false)
        {
            if (playerMovemnt.isBadGrounded)
            {
                startTime = Time.time;
            }
            t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            float seconds = t % 60;

            if (seconds < 10)
            {
                string seconds1 = seconds.ToString("f3");
                timerText.text = minutes + ":0" + seconds1.Substring(0, 1) + ":" + seconds1.Substring(2);
            }
            else
            {
                string seconds1 = seconds.ToString("f3");
                timerText.text = minutes + ":" + seconds1.Substring(0, 2) + ":" + seconds1.Substring(3);
            }
        }
    }
}
