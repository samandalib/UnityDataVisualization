using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject fileManager;
    //public GameObject fileToggle;
    //public Transform ToggleCanvas;

    //private Vector3 canvasPosition;
    public string[] inputfiles;
    public GameObject dropDown;

    // Start is called before the first frame update

    void Start()
    {
        //inputfiles = FileManager.inputFileNames.ToArray();

        dropDown.SetActive(true);
        //canvasPosition = ToggleCanvas.position;
        //for (int i = 0; i < inputfiles.Length; i++)
        //{
            //Toggle Doesn't work on screen
            /*
            GameObject toggleClone;
            toggleClone = Instantiate(fileToggle, new Vector3 (canvasPosition.x, canvasPosition.y+0.05f*i, canvasPosition.z), Quaternion.identity, ToggleCanvas);
            toggleClone.transform.GetChild(1).GetComponent<Text>().text = inputfiles[i];
            toggleClone.transform.name = inputfiles[i];

            toggleClone.transform.GetComponent<CheckBox>().fileManager = fileManager;
            */

            //Let's try Dropdown Menu instead

        //}
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
