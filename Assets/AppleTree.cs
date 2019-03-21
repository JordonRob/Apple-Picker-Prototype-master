using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    public GameObject applePrefab;
    public float speed = 1f;//speed of Apple
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.5f;
    public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () {
        //wait 2 seconds before to drop apple
        Invoke("DropApple", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        // Get current position of Appletree
        Vector3 pos = transform.position;
        //Calculate the amount of movement
        pos.x += speed * Time.deltaTime;
        //move the tree by position distance
        transform.position = pos;
        // if we hit the left edge
        if (pos.x < -leftAndRightEdge)
        {
            // change direction
            speed = Mathf.Abs(speed);
        }
        // if we hit the left edge
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        // every 10% of the time the direction changes
        else if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }

	}
    void DropApple()
    {
        //create an apple
        GameObject apple = Instantiate<GameObject>(applePrefab);
        // put the apple in the tree
        apple.transform.position = transform.position;
        // repeat every few seconds
        Invoke("DropApple", secondsBetweenAppleDrops);
    
    }
}
