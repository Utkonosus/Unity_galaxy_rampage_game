using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{
    public Button saveExit;
    public Button confirmReset;
    public Toggle reset;
    public void ResetFlag()
    {
       if (reset.isOn)
        
            confirmReset.interactable = true;
        
       else
           confirmReset.interactable = false;
    }
    public void ResetButton()
    {
        LevelData.levels = new char[] { '0','A','L','L'};
        PlayerPrefs.DeleteAll();
    }
    public void SaveExit()
    {
       for (int i = 0; i <= LevelData.lastLevel; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), LevelData.levels[i]);
        }
        Application.Quit();
    }
}
