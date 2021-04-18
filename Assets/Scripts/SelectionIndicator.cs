using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    public Transform indicators;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 hitPosition = ray.origin;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            if (selection.CompareTag("indicator"))
            {

                if (Input.GetMouseButtonUp(0))
                {
                    GameObject indicator = selection.transform.gameObject;
                    indicator.transform.SetParent(indicators);
                    indicator.SetActive(false);
                    SelectionManager.selectionExists = false;
                }

            }

        }

    }
}
