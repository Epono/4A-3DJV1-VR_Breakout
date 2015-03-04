using UnityEngine;
using System.Collections;

public class BrickCollisionScript : MonoBehaviour
{
	
	public Collider2D collider;//enlever les collider par la suite
	public Collider2D leftCollider;
	public Collider2D rightCollider;

	private Bounds bound;//enlever les collider par la suite
	private Bounds leftBound;
	private Bounds rightBound;

	private BallMovementScript ballMovement;
	private BallCollisionScript ballCollision;

	// Use this for initialization
	void Start()
	{
		bound = collider.bounds;
		leftBound = leftCollider.bounds;
		rightBound = rightCollider.bounds;

		ballMovement = GameObject.FindGameObjectWithTag("ball").GetComponent<BallMovementScript>();
		ballCollision = GameObject.FindGameObjectWithTag("ball").GetComponent<BallCollisionScript>();
	}

	private bool touched = false;
	// Update is called once per frame
	void Update()
	{
		if(bound.Intersects(ballCollision.collider2D.bounds))
		{
			ballMovement.direction = Direction.inverse(ballMovement.direction);
			ballMovement.ballSpeed = ballMovement.defaultSpeed;
			touched = true;
		}
		else if(leftBound.Intersects(ballCollision.collider2D.bounds))
		{
			ballMovement.direction = Direction.opposite(ballMovement.direction);
			ballMovement.ballSpeed = ballMovement.defaultSpeed;
			touched = true;
		}
		else if(rightBound.Intersects(ballCollision.collider2D.bounds))
		{
			ballMovement.direction = Direction.opposite(ballMovement.direction);
			ballMovement.ballSpeed = ballMovement.defaultSpeed;
			touched = true;
		}
		if (touched)
		{
			ballCollision.LastBound = bound;
			Destroy(gameObject);
			BrickInstantiateScript.nbBrickInstantiate--;
		}
	}
}
