using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    public float targetTime = 0.0f;
    private float platformWidth;
    Random random;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        random = new Random();
    }

    // Update is called once per frame
    void Update() {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y + Random.Range(-3,3), transform.position.z);

          Instantiate(thePlatform, transform.position, transform.rotation);
            targetTime = 1.0f;
        }

    }
}
