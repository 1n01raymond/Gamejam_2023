using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWall : MonoBehaviour
{
    // set collided rigidbody2d to static
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
