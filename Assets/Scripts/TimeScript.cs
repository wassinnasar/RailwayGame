using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{

    public Text counterText;
    public float seconds, minutes;
    private Statistic statistic;
    private SplineWalker splineWalker;

    void Start()
    {
        statistic = FindObjectOfType<Statistic>();
        splineWalker = FindObjectOfType<SplineWalker>();
       // counterText = GetComponent<Text>() as Text;
    }

    void Update()
    {
        //hours = (int)(Time.timeSinceLevelLoad / 3600f);
        minutes = (int)(Time.timeSinceLevelLoad / 60f) % 60;
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        // milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;

        counterText.text = minutes + ":" + seconds.ToString("00");
       // counterText.text = seconds.ToString();
       if(minutes == 5)
        {
            statistic.ShowStatistic();
            splineWalker.Finish();
        }
    }
}
