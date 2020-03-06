using UnityEngine;
using System.Collections;

public class Asteroid: MonoBehaviour 
{
	public float upspeed;
	public float defaultx;
	public float rndrange;
	public GameObject player;

	// Use this for initialization
	void Start () 
	{
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		//if (player.isdestroyed  )
		transform.position += Vector3.down * GameController.upspeed * 2;
		
	}
}

