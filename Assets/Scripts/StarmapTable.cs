using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarmapTable : MonoBehaviour
{
    // TODO: maybe let all objects that need reference to EditorFunctions...
    // inherit from a base class that provides this reference? 
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
        editorFunctions.selectionState = EditorFunctions.SelectionState.NoSelection;
        editorFunctions.NewSelection(transform);
    }
}
