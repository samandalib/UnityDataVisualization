using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public GameObject UIManager;
    public static string selectedFileName;
    public static bool newFileSelected;

    [SerializeField]
    private string _selectedFileName = selectedFileName; 

    void Start()
    {

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
