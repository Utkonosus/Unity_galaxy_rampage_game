using UnityEngine;
using System.Collections;

public class Background: MonoBehaviour 
	{
	public float upspeed;
    // Use this for initialization
    public Sprite blackBackground;
    public Sprite purpleBackground;
    public Sprite redBackground;
    void Start()
    {
        switch (LevelData.CurrentLevel)
        {
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = blackBackground;
                break;

            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = purpleBackground;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = redBackground;
                break;
            default:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = blackBackground;
                break;

        }
	}  
    // Update is called once per frame
    void FixedUpdate () 
	{
		transform.position += Vector3.down * GameController.upspeed;
		if (transform.position.y <= -2.7) 
		{
			transform.position = new Vector3 (transform.position.x,17f,transform.position.z);
		}
	}
}
