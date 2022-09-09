using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class MainEditorSceneControl : MonoBehaviour
{
    // Cam Control
    public CinemachineVirtualCamera vcam1;
    // maybe not needed
    public GameObject MainMenuCamMark;
    public GameObject EditorDefaultCamMark;
    public GameObject SettingsCamMark;

    // Editor Panels
    public GameObject EToolsPanel;
    public GameObject EAssetsPanel;
    public GameObject EMenuPanel;

    // Main Menu Panels
    public GameObject MMenuPanel;

    // Settings Panels
    public GameObject SSettingsPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // to be deleted
        if (Input.GetKeyDown(KeyCode.E))
        {
            CamFocusTo(EditorDefaultCamMark.transform);
            SetEditorUI(true);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            CamFocusTo(MainMenuCamMark.transform);
            SetEditorUI(false);
        }
        // to be deleted/
    }

    /// <summary>
    /// Set Editor's UI Element visibility. 
    /// </summary>
    /// <param name="active">True to show Editor UI, false to hide. </param>
    public void SetEditorUI(bool active = true)
    {
        EToolsPanel.SetActive(active);
        EAssetsPanel.SetActive(active);
        EMenuPanel.SetActive(false); // menu panel will always be invisible first. 
    }

    /// <summary>
    /// Set Main Menu's UI elements' visibility; 
    /// </summary>
    /// <param name="active">True to show Main Menu UI, false to hide. </param>
    public void SetMainMenuUI(bool active = true)
    {
        MMenuPanel.SetActive(active);
    }

    public void SetSettingsUI(bool active = true)
    {
        SSettingsPanel.SetActive(active);
    }

    /// <summary>
    /// Set an array of GameObject's visibility. 
    /// </summary>
    /// <param name="gos"></param>
    /// <param name="active"></param>
    public void SetUI(GameObject[] gos, bool active = true)
    {
        foreach (GameObject go in gos)
        {
            go.SetActive(active);
        }
    }

    /// <summary>
    /// Set the Cinemachine Virtual Cam (vcam 1)'s Follow and LookAt to the given transform. 
    /// </summary>
    /// <param name="tr">The transform of the desired object. </param>
    public void CamFocusTo(Transform tr)
    {
        vcam1.Follow = tr;
        vcam1.LookAt = tr;
    }

    public void EditorMenuButton()
    {
        // switch to another state; 
        EMenuPanel.SetActive(!EMenuPanel.activeInHierarchy);
    }
}
