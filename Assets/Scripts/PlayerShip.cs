using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerShip : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isdestroyed;
    public float firerate;
    public string Fire1; 
	private SpriteRenderer sr;
    public Boundary bound;
    public GameObject bullet;
    private float nextFire = 1.5f;
	// Use this for initialization
	void Start ()
	{
		sr = gameObject.GetComponent<SpriteRenderer> ();
        rb = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
    void Update()
    {
     if (Input.GetKey(Fire1) && Time.time > nextFire)
        { 
            nextFire = Time.time + firerate;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
     void FixedUpdate ()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0.0f);
        rb.velocity = movement * GameController.speed;
        rb.position = new Vector3(
           Mathf.Clamp(rb.position.x, bound.xMin, bound.xMax),
           Mathf.Clamp(rb.position.y, bound.yMin, bound.yMax),
           0.0f
            );
        

	}
}
