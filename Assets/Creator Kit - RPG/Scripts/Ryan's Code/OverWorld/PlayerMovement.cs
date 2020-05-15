using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	//speed for how fast player goes
	[SerializeField]
	private float speed;

	//player animator
	[SerializeField]
	private Animator animator;

	//code for movement
	void FixedUpdate () {
		//get current input for movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//grab current velocity from player
		Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D> ().velocity;

		//code for checking x direction
		float newVelocityX = 0f;
		if (moveHorizontal < 0 && currentVelocity.x <= 0) {
			newVelocityX = -speed;
			animator.SetInteger ("DirectionX", -1);
		} else if (moveHorizontal > 0 && currentVelocity.x >= 0) {
			newVelocityX = speed;
			animator.SetInteger ("DirectionX", 1);
		} else {
			animator.SetInteger ("DirectionX", 0);
		}

		//code for checking y direction
		float newVelocityY = 0f;
		if (moveVertical < 0 && currentVelocity.y <= 0) {
			newVelocityY = -speed;
			animator.SetInteger ("DirectionY", -1);
		} else if (moveVertical > 0 && currentVelocity.y >= 0) {
			newVelocityY = speed;
			animator.SetInteger ("DirectionY", 1);
		} else {
			animator.SetInteger ("DirectionY", 0);
		}

		//move player in direction of the input
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (newVelocityX, newVelocityY);
	}
}
