using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScripts : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float speed = 0.2f;
    [SerializeField]
    public Vector3 offset;
   // public float offsetX;
    //public float offsetY;
    //public float offsetZ;
    private Vector3 startPos;
    private Vector3 currentPos;
    private bool isDown;
    public bool isFreeLook;
    private bool isStartPosition;
    private Vector3 behindPosition;
    public Text cameraButtonText;
    void Start()
    {
        cameraButtonText.text = "Фрилук";
        //transform.position = target.position + offset;
    }
    void Update()
    {
        //offsetX = transform.position.x;
        //offsetY = transform.position.y;
       // offsetZ = target.position.z;
        if (!isFreeLook)
        {
           // transform.position = target.position + offset;
            //Vector3 Desired = target.position + offset;
            //Vector3 Smoothed = Vector3.Lerp(transform.position, Desired, speed);
            //transform.position = Smoothed;
            transform.parent = target.transform;
            if (isStartPosition)
            {
                transform.position = target.position;
                transform.localPosition = new Vector3(0, 1, -3);
            }
           // transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 3);
            transform.LookAt(target);
            //behindPosition = target.position + offset;
        }
        if (isFreeLook)
        {
            isStartPosition = true;
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                isDown = true;
            }
            if (isDown)
            {
                currentPos = Input.mousePosition;
                if(currentPos.x > startPos.x)
                {
                    transform.Translate(0.1f, 0, 0);
                }
                if (currentPos.y > startPos.y)
                {
                    transform.Translate(0, 0.1f, 0);
                }
                if (currentPos.x < startPos.x)
                {
                    transform.Translate(-0.1f, 0, 0);
                }
                if (currentPos.y < startPos.y)
                {
                    transform.Translate(0, -0.1f, 0);
                }
                //transform.parent = target.transform;
                transform.LookAt(target);
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDown = false;
            }
        }
    }
    public void CameraPerspective()
    {
        if (isFreeLook == true)
        {
            isFreeLook = false;
            cameraButtonText.text = "Фрилук";
        }
        else if (isFreeLook == false)
        {
            isFreeLook = true;
            cameraButtonText.text = "Нот фрилук";
        }
    }


}

