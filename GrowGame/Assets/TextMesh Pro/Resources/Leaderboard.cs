using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Timer timer;
    public Text displayTime;
    public void ShowInfo()
    {
        string minutes = ((int)timer.t / 60).ToString();
        float s = timer.t % 60;

        if (s < 10)
        {
            string seconds = s.ToString("f3");
            displayTime.text = "Time: " + minutes + ":0" + seconds.Substring(0, 1) + ":" + seconds.Substring(2);
        }
        else
        {
            string seconds = s.ToString("f3");
            displayTime.text = "Time: " + minutes + ":" + seconds.Substring(0, 2) + ":" + seconds.Substring(3);
        }
    }
}
