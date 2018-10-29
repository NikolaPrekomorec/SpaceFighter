using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit " + other + "!");
        Destroy(gameObject);
    }
}
