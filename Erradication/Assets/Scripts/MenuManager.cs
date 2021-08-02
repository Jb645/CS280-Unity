using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject modeSelection;



    public void SetActiveSettings()
    {
        settings.SetActive(!settings.activeSelf);
    }
    public void SetActiveModeSelection()
    {
        modeSelection.SetActive(!modeSelection.activeSelf);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
