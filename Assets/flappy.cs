using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class flappy : MonoBehaviour {

    bool isJumping = false;
    public float jumpHeight = 10;
    private Vector2 jump = new Vector2(0, 10);
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(jump, ForceMode2D.Impulse);
            rb.velocity = jump;
            isJumping = true;
            Debug.Log("jumped");
            
        }
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground") // GameObject is a type, gameObject is the property
        {
            isJumping = false;
        }
    }
}
