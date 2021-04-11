using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour
{
    public bool on;
    //public Object csvFile;

    public GameObject fileManager;



    public void onChange()
    {
        if (GetComponent<Toggle>())
        {
            on = GetComponent<Toggle>().isOn;
        }

        if(on)
        {
            //_inputFilesScript.inputFiles.Add(csvFile.name);
            //Debug.Log("CheckBox Script:" + csvFile.name);
            //FileManager.selectedFiles.Add(transform.name);

        }
        else
        {
            Debug.Log("Toggle Shows: OFF");
        }
    }
}
