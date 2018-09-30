using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class optionsScript : MonoBehaviour {

    List<string> resolutions = new List<string>() { "", "1024×576", "1152×648", "1280×720", "1366×768", "1600×900", "1920×1080" };
    public Dropdown dropdown;

    void Start()
    {
        PopulateList();
    }

    public void goToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Dropdown_IndexChanged(int index)
    {
        switch (index)
        {
            case 1:
                Screen.SetResolution(1024, 576, false);
                break;
            case 2:
                Screen.SetResolution(1152, 648, false);
                break;
            case 3:
                Screen.SetResolution(1280, 720, false);
                break;
            case 4:
                Screen.SetResolution(1366, 768, false);
                break;
            case 5:
                Screen.SetResolution(1600, 900, false);
                break;
            case 6:
                Screen.SetResolution(1920, 1080, false);
                break;
            
        }
        Debug.Log("Index Changed");
    }

    void PopulateList()
    {
        dropdown.AddOptions(resolutions);
    }
}
