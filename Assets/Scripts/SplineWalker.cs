using UnityEngine;
using UnityEngine.UI;

public class SplineWalker : MonoBehaviour
{

    public BezierSpline spline;

    public float duration;

    private float progress;
    public bool lookForward;
    public bool isOnWay;
    private bool isToStop = true;
    [SerializeField]
    private Text startStopText;
    //public float speed = 10.0f;
   // public Vector3 startPos;
    //public Vector3 curPos;

    void Start()
    {
        startStopText.text = "Старт";
        //startPos = transform.position;
    }
    public void ToStartToStop()
    {
        if (isToStop == true)
        {
            isToStop = false;
            startStopText.text = "Стоп";
        }
        else if (isToStop == false)
        {
            isToStop = true;
            startStopText.text = "Старт";
        }
    }
    void Update()
    {
        /* if(transform.position == curPos)
         {
             transform.position = startPos;
             progress = 0f;
         }
         curPos = transform.position;*/
        if (isOnWay)
        {
             progress += Time.deltaTime / duration;
             if (progress > 1f)
             {
                 progress = 0f;
             }
        }
        if (isToStop)
         {
            if (duration <= 200)
            {
                duration += 1;
                if (duration >= 200)
                {
                    isOnWay = false;
                }
            }
         }
        if (!isToStop)
        {
                if(duration >= 20)
                {
                    duration -= 1;
                }
                isOnWay = true;
         }
        /*else
        {
            if (isToStop)
            {
                isOnWay = true;
                isToStop = true;
            }
        }*/

        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }
    public void Finish()
    {
        duration = 0;
    }
}
