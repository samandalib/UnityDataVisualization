using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public GameObject UIManager;
    //public List<Object> inputFiles = new List<Object>();
    //public static List<string> inputFileNames = new List<string>();

    public static string selectedFileName;
    public static bool newFileSelected;

    [SerializeField]
    private string _selectedFileName = selectedFileName; 


    //public static List<string> fileNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        for (int i=0; i<inputFiles.ToArray().Length; i++)
        {
            inputFileNames.Add(inputFiles[i].name);
           // Debug.Log(inputFiles[1]);
        }
        //Debug.Log(fileNames[1]);
        */
        UIManager.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetName(string name)
    {
        selectedFileName = name;
        Debug.Log("Button Pressed: " + selectedFileName);

    }

    public void OnClick()
    {
        Debug.Log("Button Pressed: " + selectedFileName);
        newFileSelected = true;
    }
}
