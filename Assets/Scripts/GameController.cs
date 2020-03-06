using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [System.Serializable]
    public class Score
    {
        public Text scoreText;
        public int score;
        public int scoreValue1;
    }
    [System.Serializable]
    public class Difficulty
    {
        public int difficulty;
        public int waveSize;
        public float spawnRate;
        public float startWait;
        public int damage;
        public int targetScore;
    }
    [System.Serializable]
    public class Stats
    {
        public Text hullText;
        public bool gameover;
        public int hull;
        public int maxhull;
        public bool won;         
    }
    public GameObject hazard;
    public static int speed = 10;
    public static float upspeed;
    public Vector3 spawnValues;
    public Text gamoversText;
    public Text retryText;
    public Text goal;
    public Text retryText2;
    public Difficulty difficulty;
    public Score score;
    public Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        goal.text = "";     
        score.score = 0;
        stats.hull = stats.maxhull;
        UpdateScore();
        UpdateHull();
        gamoversText.text = "";
        retryText.text = "";
        retryText2.text = "";
        stats.gameover = false;
        stats.won = false;
 
        SetDifficulty(LevelData.difficulty);
        StartCoroutine(SpawnWaves());
       
        
    }
 
    void SetDifficulty(int diff)
    {
        difficulty.difficulty = diff;
        difficulty.waveSize = 5 + 5*diff;
        difficulty.spawnRate = 0.6f - 0.1f * diff;
        difficulty.startWait = 2;
        difficulty.damage = 1;
        difficulty.targetScore = 500 * diff;
        score.scoreValue1 = 10 * diff;
        upspeed = 0.05f * diff;
}
    IEnumerator SpawnWaves()
    {
        goal.text = "Score " + difficulty.targetScore + " points";
        yield return new WaitForSeconds(difficulty.startWait);
        goal.text = "";
        while (!stats.gameover && !stats.won)
        {
            for (int i = 0; i < difficulty.waveSize; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = new Quaternion();
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(difficulty.spawnRate);
            }
            yield return new WaitForSeconds(difficulty.spawnRate * 3);
        }
        
        if (stats.gameover && !stats.won)
        {
            gamoversText.text = "Game Over";
            retryText.text = "Press 'R' to restart";
            retryText2.text = "Press 'X' to exit";
        }
        if (stats.won)
        {
            LevelData.levels[LevelData.CurrentLevel] = 'C';
            if (LevelData.CurrentLevel != LevelData.lastLevel)
                LevelData.levels[LevelData.CurrentLevel+1] = 'A';
            for (int i = 0; i <= LevelData.lastLevel; i++)
            {
                PlayerPrefs.SetInt(i.ToString(), LevelData.levels[i]);
            }
            foreach (char lvl in LevelData.levels)
            {
                Debug.Log(lvl);
            }


            gamoversText.text = "Lever Cleared!";
            retryText.text = "Press 'X' to exit";
            retryText2.text = "Press 'R' to restart";
        }
    }
    public void AddScore()
    {
        score.score += score.scoreValue1;
        UpdateScore();
        if (score.score > difficulty.targetScore)
            stats.won = true;
    }

    void UpdateScore()
    {
        score.scoreText.text = "Score: " + score.score;
    }
    void UpdateHull()
    {
        stats.hullText.text = "Hull: " + stats.hull + "/" + stats.maxhull;
    }
    public void DamageHull()
    {
        stats.hull -= difficulty.damage;
        UpdateHull();
        if (stats.hull == 0)
            stats.gameover = true;
    }
    void Update()
    {
        if (stats.won)
        {
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("Menu");               
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Galaxy Rampage");
            }

        }
        if (stats.gameover)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("Menu");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Galaxy Rampage");          
            }
        }
        
    }
}

