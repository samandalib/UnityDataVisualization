using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{

    public GameObject selectionBox;

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;


    private Transform _selection;
    public static bool selectionExists;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

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

            

            if (selection == null)
            {
                selectionExists = false;
            }

            else if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;

                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    UIManager.selectedObject = selection;
                    selectionBox.SetActive(true);
                    selectionBox.transform.SetParent(selection);
                    selectionBox.transform.localPosition = new Vector3(0, 0, 0);
                    selectionExists = true;
                }
                _selection = selection;

            }

        }

    }          
            
}