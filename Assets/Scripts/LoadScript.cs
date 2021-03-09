using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour
{
    public Text text;
    public int loaded;
    public GameObject loadButton;
    private int loadedNumber = 0;

    void Start()
    {
        text.text = loaded.ToString();
    }
    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "train")
        {
            if (c.GetComponent<SplineWalker>().isOnWay == false)
            {
                if (loadedNumber == 0)
                {
                    loadButton.SetActive(true);
                    loadedNumber++;
                }
            }
        }
        
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "train")
        {
            loadButton.SetActive(false);
            loadedNumber = 0;
        }
    }
    public void Load()
    {
        loaded++;
        text.text = loaded.ToString();
        loadButton.SetActive(false);
    }
}
