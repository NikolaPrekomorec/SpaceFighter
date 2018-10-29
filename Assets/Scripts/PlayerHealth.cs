using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private int playerHealth = 100, velocity = 0;
    public Slider healthBar;
    public Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        healthBar.value = playerHealth;
        velocity=Mathf.RoundToInt(Vector3.Magnitude(rb2d.velocity));
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth = playerHealth - velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerHealth = playerHealth - velocity;
    }

    

}
