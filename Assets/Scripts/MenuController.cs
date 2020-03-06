using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject clearMarker;
    public GameObject lockMarker;
    void Start()
    {
        foreach (char level in LevelData.levels)
        {
            Debug.Log(level);
        }
        UpdateLevels();
        foreach (char level in LevelData.levels)
        {
            Debug.Log(level);
        }
    }
    void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }
    public void UpdateLevels()
    {
        if ((char)PlayerPrefs.GetInt("0") == '0')
            {
            for (int j = 0; j <= LevelData.lastLevel; j++)
            {
                LevelData.levels[j] = (char)PlayerPrefs.GetInt(j.ToString());
            }
        }
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Marker");
        foreach (GameObject target in gameObjects)
        {
            Destroy(target);
        }
        int i = 0;
        foreach (char lvl in LevelData.levels)
        {
        

            if (LevelData.levelNames[i] != "Menu")
            {
                
                GameObject target = GameObject.Find(LevelData.levelNames[i]);
              
                GameObject marker = null;
                if (lvl == 'C')
                    marker = clearMarker;
                if(lvl == 'L')
                    marker = lockMarker;
                if (marker != null)
                   Instantiate(marker, target.transform.position, target.transform.rotation);
                
            }
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   /* public PlaceMarker(GameObject,)
    {

    }*/
    public static void ClickLevel(string lvlName)
    {
        switch (lvlName)
        {

            case "Level1":
                
                    if (LevelData.levels[1] != 'L')
                    {
                        LevelData.difficulty = LevelData.levelDifficulty[1];
                        LevelData.CurrentLevel = 1;
                        SceneManager.LoadScene("Galaxy Rampage");
                    }
                    break;
            case "Level2":
                if (LevelData.levels[2] != 'L')
                {
                    LevelData.difficulty = LevelData.levelDifficulty[2];
                    LevelData.CurrentLevel = 2;
                    SceneManager.LoadScene("Galaxy Rampage");
                }
                break;
            case "Level3":
                if (LevelData.levels[3] != 'L')
                {
                    LevelData.difficulty = LevelData.levelDifficulty[3];
                    LevelData.CurrentLevel = 3;
                    SceneManager.LoadScene("Galaxy Rampage");
                }
                break;
            default:
                Debug.Log("Error, no level");
                break;
        }
        }
    }
    
