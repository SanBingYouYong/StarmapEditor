using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public string StarName;
    // TODO: Maybe find a better way: the events and delegate system;
    private EditorFunctions editorFunctions;


    // Start is called before the first frame update
    void Start()
    {
        editorFunctions = GameObject.Find("WorldOrigin").GetComponent<EditorFunctions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        editorFunctions.selectionState = EditorFunctions.SelectionState.ActiveSelection;
        editorFunctions.NewSelection(transform);
    }

    
}
