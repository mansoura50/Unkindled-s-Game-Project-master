using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    //enemy speed
	public float moveSpeed;

	private Rigidbody2D myRigidbody;

	public bool isWalking;

	//determines how long enemy should walk
	public float walkTime; 

	//determines how long enemy should wait
	public float waitTime;

	private float walkCounter;

	private float waitCounter;

	private int WalkDirection;

	// Start is called before the first frame update
    void Start() {
		myRigidbody = GetComponent<Rigidbody2D>();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection();
    }

    // Update is called once per frame
    void Update() {
		if(isWalking) {
			walkCounter -= Time.deltaTime;


			switch(WalkDirection) {
			case 0:
				//move up
				myRigidbody.velocity = new Vector2(0,moveSpeed);		
				break;
			case 1:
				//move right
				myRigidbody.velocity = new Vector2(moveSpeed,0);		
				break;
			case 2:
				//move down
				myRigidbody.velocity = new Vector2(0,-moveSpeed);		
				break;
			case 3:
				//move left
				myRigidbody.velocity = new Vector2(-moveSpeed,0);		
				break;
			}

			if(walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}
				
		}

		else {
			waitCounter -= Time.deltaTime;

			myRigidbody.velocity = Vector2.zero;

			if(waitCounter < 0) {
				ChooseDirection();
			}
		}
    }

	//what is used to chose randomly new direction for enemy to walk
	public void ChooseDirection() {
		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}

}
