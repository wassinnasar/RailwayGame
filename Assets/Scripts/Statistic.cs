using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistic : MonoBehaviour
{
    [SerializeField]
    private GameObject statisticPanel;
    public GameObject cameraButton;
    public GameObject startStopButton;
    public int result;
    private GameObject loadscript;
    [SerializeField]
    private Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        loadscript = GameObject.Find("Station");
    }
    public void Restart()
    {
        Application.LoadLevel(0);
    }
    public void ShowStatistic()
    {
        result = loadscript.GetComponent<LoadScript>().loaded;
        statisticPanel.SetActive(true);
        cameraButton.SetActive(false);
        startStopButton.SetActive(false);
        resultText.text = "Грузов загруженно:"+result.ToString();
    }

}
