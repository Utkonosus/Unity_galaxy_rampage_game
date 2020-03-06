using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    void Start ()
    {
        Debug.Log(CurrentLevel);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            CurrentLevel = 0;
                       
        };
        
    }
    
    public static char[] levels = {'0','A','L','L'}; /*A - available L - locked C - cleared */
    public static string[] levelNames = {"Menu","Level1","Level2","Level3"};
    public static int[] levelDifficulty = {1,1,2,3};
    public static int lastLevel = 3;
    public static int difficulty = 1;
    public static int CurrentLevel;
         
}
