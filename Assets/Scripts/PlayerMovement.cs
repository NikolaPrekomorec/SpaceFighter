using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float forwardSpeed=5, reverseSpeed=3, rotationSpeed=5;
    private Rigidbody2D rb2d;
    public float maximumSpeed = 12f;

    //public Joystick vJoystick;
    
    




    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //float moveHorizontal = Input.GetAxis("Horizontal") + vJoystick.Horizontal;
        //float moveVertical = Input.GetAxis("Vertical") + vJoystick.Vertical;


        #region Movement


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0f, moveVertical);      
        Vector3 rotation = new Vector3(0f, 0f, -moveHorizontal);

        //Hover mode
        if (Input.GetAxis("Hover")!=0 && Vector3.Magnitude(rb2d.velocity)!=0)
        {
            rb2d.velocity = Vector3.Lerp(rb2d.velocity, Vector3.zero, 0.05f);
            rb2d.angularVelocity = Mathf.Lerp(rb2d.angularVelocity, 0, 0.05f);
        }

        //Adding force in forward or backwards direction
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb2d.AddForce(rb2d.transform.rotation * movement * reverseSpeed);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rb2d.AddForce(rb2d.transform.rotation * movement * forwardSpeed);
        }      
        // Rotating around z axis
        rb2d.transform.Rotate(rotation * rotationSpeed);
        #endregion

        //seting the speed limit
        //Debug.Log(rb2d.velocity);
        float speed = Vector3.Magnitude(rb2d.velocity);
        //Debug.Log(speed +" "+ rb2d.velocity);
        if (speed>maximumSpeed)
        {
            float brakeSpeed = speed - maximumSpeed;
            Vector3 normalisedVelocity = rb2d.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;
            rb2d.AddForce(-brakeVelocity);
        }
        //Debug.Log(speed + " " + rb2d.velocity);


    }
}
