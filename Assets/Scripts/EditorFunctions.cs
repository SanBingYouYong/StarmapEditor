using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorFunctions : MonoBehaviour
{
    // Prefab Pointers
    public GameObject StarSystemPrefab;
    public GameObject SelectionRing;
    public GameObject MoveArrows;
    public GameObject RotateRings;
    public GameObject ScaleBoxes;

    // Real Time Pointers
    public GameObject activeToolMark;
    //public GameObject activeMoveArrows;
    public GameObject ToolMarktoBeGenerated;

    // states definition
    public enum ToolState
    {
        NoToolActive,
        MoveActive,
        RotateActive,
        ScaleActive
    }

    public enum SelectionState
    {
        NoSelection,
        ActiveSelection
    }

    public enum Tools
    {
        Move, 
        Rotate, 
        Scale
    }

    // states
    public ToolState toolState = ToolState.NoToolActive;
    public SelectionState selectionState = SelectionState.NoSelection;


    // Start is called before the first frame update
    void Start()
    {
        ToolMarktoBeGenerated = SelectionRing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// The place holder function to generate a new star system in origin's position
    /// </summary>
    public void NewStarSystem()
    {
        GameObject nss = Instantiate(StarSystemPrefab, transform); // this script is attached to WorldOrigin. 
    }

    // TODO: 
    public void NewSelection(Transform tr)
    {
        // clear existing tool mark
        if (activeToolMark != null)
        {
            Destroy(activeToolMark);
        }
        activeToolMark = Instantiate(ToolMarktoBeGenerated);
        activeToolMark.transform.SetParent(tr, false);

        //if (activeToolMark == null)
        //{
        //    activeToolMark = Instantiate(ToolMarktoBeGenerated);
        //    activeToolMark.transform.localScale = new Vector3(1f, 1f, 1f);
        //    activeToolMark.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        //}
        //activeToolMark.transform.SetParent(tr, false);

    }

    /// <summary>
    /// Change the tool state and the reference to the tool mark to be generated. 
    /// </summary>
    /// <param name="tool">tool as a string since OnClick does not support enum params</param>
    public void OnToolButtonPress(string tool)
    {
        if (tool == "M")
        {
            if (toolState == ToolState.MoveActive)
            {
                ToDefaultSelectionState();
            }
            else
            {
                toolState = ToolState.MoveActive;
                ToolMarktoBeGenerated = MoveArrows;
            }
        }
        else if (tool == "R")
        {
            if (toolState == ToolState.RotateActive)
            {
                ToDefaultSelectionState();
            }
            else
            {
                toolState = ToolState.RotateActive;
                ToolMarktoBeGenerated = RotateRings;
            }
        }
        else if (tool == "S")
        {
            if (toolState == ToolState.ScaleActive)
            {
                ToDefaultSelectionState();
            }
            else
            {
                toolState = ToolState.ScaleActive;
                ToolMarktoBeGenerated = ScaleBoxes;
            }
        }
        else
        {
            ToDefaultSelectionState();
        }
        NewSelection(activeToolMark.transform.parent.transform);
    }

    private void ToDefaultSelectionState()
    {
        toolState = ToolState.NoToolActive;
        ToolMarktoBeGenerated = SelectionRing;
    }

}
