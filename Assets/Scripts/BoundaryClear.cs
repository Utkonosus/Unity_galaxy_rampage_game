using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryClear : MonoBehaviour
{


    public void OnTriggerExit2D(Collider2D other)
    {
        Object.Destroy(other.gameObject);
    }
}
