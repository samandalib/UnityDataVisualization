using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StopMouseLook : MonoBehaviour
{
    private MouseLook mous;
    public GameObject FPS;
    public GameObject fileMenu;
    //MouseLook playerLook;
    void Start()
    {
        mous = FPS.GetComponent<FirstPersonController>().m_MouseLook;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mous.lockCursor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mous.XSensitivity = 0;
            mous.YSensitivity = 0;

            fileMenu.SetActive(true);
            //mous[0].enabled = false;
            //mous[1].enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            mous.XSensitivity = 2;
            mous.YSensitivity = 2;

            fileMenu.SetActive(false);
            //mous[0].enabled = false;
            //mous[1].enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (mous.XSensitivity == 0 && mous.YSensitivity == 0)
            {
                mous.XSensitivity = 2;
                mous.YSensitivity = 2;
            }
            else
            {
                mous.XSensitivity = 0;
                mous.YSensitivity = 0;
            }
            
        }
    }
}
