using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{

    public GameObject plotter;

    public List<string> datapoint_values;
    public string username;
    public string tweetLength;
    public string hashtagCount;
    public string followerCount;

    private DataPlotter dataPlotterScript;

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    //[SerializeField] private TextMeshProUGUI

    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {
        dataPlotterScript = plotter.GetComponent<DataPlotter>();


        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("Mouse is up");
                    Debug.Log(selection.name);
                    Debug.Log(dataPlotterScript.followerCount);

                    datapoint_values = dataPlotterScript.GetValues(selection.name);
                    Debug.Log("DataPoint Values: "+datapoint_values[0]);

                    username = datapoint_values[0];
                    tweetLength = datapoint_values[2];
                    hashtagCount = datapoint_values[3];
                    followerCount = datapoint_values[1];

                    var textboards = GameObject.FindGameObjectsWithTag("textboard");
                    Debug.Log(textboards.Length);

                    GameObject textboard_1 = textboards[0];
                    textboard_1.GetComponent<TextMeshProUGUI>().text = username;

                    GameObject textboard_2 = textboards[1];
                    textboard_2.GetComponent<TextMeshProUGUI>().text = selection.name;

                    GameObject textboard_3= textboards[2];
                    textboard_3.GetComponent<TextMeshProUGUI>().text =  followerCount;

                    GameObject textboard_4 = textboards[3];
                    textboard_4.GetComponent<TextMeshProUGUI>().text = hashtagCount;

                    GameObject textboard_5 = textboards[4];
                    textboard_5.GetComponent<TextMeshProUGUI>().text = tweetLength;
                    
                }

                _selection = selection;
            }

        }

    }
}
