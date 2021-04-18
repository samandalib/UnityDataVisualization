using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public GameObject fileManager;
    //public GameObject fileToggle;
    //public Transform ToggleCanvas;

    //private Vector3 canvasPosition;
    //public string[] inputfiles;

    public List<string> datapoint_values;
    // Start is called before the first frame update

    public string username;
    public string tweetLength;
    public string hashtagCount;
    public string followerCount;

    public static Transform selectedObject;
    public GameObject plotter;
    private DataPlotter dataPlotterScript;

    public GameObject[] textboards;
    GameObject textboard_1;
    GameObject textboard_2;
    GameObject textboard_3;
    GameObject textboard_4;
    GameObject textboard_5;


    private bool _selectionExistence;
    void Start()
    {

        textboards = GameObject.FindGameObjectsWithTag("textboard");
        textboard_1 = textboards[0];
        textboard_2 = textboards[1];
        textboard_3 = textboards[2];
        textboard_4 = textboards[3];
        textboard_5 = textboards[4];
    }

    // Update is called once per frame
    void Update()
    {
        _selectionExistence = SelectionManager.selectionExists;



        if (_selectionExistence)
        {
            dataPlotterScript = plotter.GetComponent<DataPlotter>();

            datapoint_values = dataPlotterScript.GetValues(selectedObject.name);
            Debug.Log("DataPoint Values: " + datapoint_values[0]);

            username = datapoint_values[0];
            tweetLength = datapoint_values[2];
            hashtagCount = datapoint_values[3];
            followerCount = datapoint_values[1];

            textboard_1.GetComponent<TextMeshProUGUI>().text = username;
            textboard_2.GetComponent<TextMeshProUGUI>().text = selectedObject.name;
            textboard_3.GetComponent<TextMeshProUGUI>().text = followerCount;
            textboard_4.GetComponent<TextMeshProUGUI>().text = hashtagCount;
            textboard_5.GetComponent<TextMeshProUGUI>().text = tweetLength;
        }

        else
        {
            textboard_1.GetComponent<TextMeshProUGUI>().text = "";
            textboard_2.GetComponent<TextMeshProUGUI>().text = "";
            textboard_3.GetComponent<TextMeshProUGUI>().text = "";
            textboard_4.GetComponent<TextMeshProUGUI>().text = "";
            textboard_5.GetComponent<TextMeshProUGUI>().text = "";
        }
 
    }
}
