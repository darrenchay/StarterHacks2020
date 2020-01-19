using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class flappy : MonoBehaviour {

    bool isJumping = false;
    bool isGrounded = true;
    public float jumpHeight;
    private Vector2 jump = new Vector2(0, 10);
    Rigidbody2D rb;
    AudioSource audio;
    float fallTime = 0.0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && !isJumping && isGrounded)
        {
            rb.AddForce(jump, ForceMode2D.Impulse);
            audio.Play();
            rb.velocity = jump;
            isJumping = true;
            isGrounded = false;
            Debug.Log("jumped");
            //audio.Stop();

        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground") // GameObject is a type, gameObject is the property
        {
            isJumping = false;
            Debug.Log("not jumping");
            isGrounded = true;

        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = false;
        fallTime += Time.deltaTime;
        if (fallTime > 3.0)
        {
            Debug.Log("YOU DED");
            print("YOU DEDDD");
        }
    }
}
