using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSelection : MonoBehaviour
{
    public GameObject UIManager;
    public string[] inputFileNames;

    public string selection;
    // Start is called before the first frame update
    void Start()
    {
        inputFileNames = UIManager.GetComponent<UIManager>().inputfiles;
        for (int i = 0; i < inputFileNames.Length; i++)
        {
            Debug.Log("Dropdown Menu");
            Dropdown.OptionData option = new Dropdown.OptionData() { text = inputFileNames[i]};
            GetComponent<Dropdown>().options.Add(option);
            Debug.Log("DropdownOptions: " + GetComponent<Dropdown>().options[0] + GetComponent<Dropdown>().options[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
