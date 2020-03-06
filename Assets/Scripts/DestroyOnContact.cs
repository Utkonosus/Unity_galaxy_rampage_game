using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour

{
    public GameController gameController;
   
    void Start()
    {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }
        else
            Debug.Log("Error, No Game Controller");

    }
  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            gameController.DamageHull();
            Destroy(gameObject);
            if (gameController.stats.gameover)
            {
                Destroy(other.gameObject);
            }
            return;
        }
        gameController.AddScore ();
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
