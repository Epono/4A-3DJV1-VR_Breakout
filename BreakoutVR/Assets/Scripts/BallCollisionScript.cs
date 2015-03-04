using UnityEngine;
using System.Collections;
using System.Threading;

public class BallCollisionScript : MonoBehaviour
{
	public Collider2D boundUpCollider;
	public Collider2D boundDownCollider;
	public Collider2D boundRightCollider;
	public Collider2D boundLeftCollider;

	private Bounds boundUp;//enlever les collider par la suite
	private Bounds boundDown;//enlever les collider par la suite
	private Bounds boundRight;//enlever les collider par la suite
	private Bounds boundLeft;//enlever les collider par la suite
	private Bounds ballBound;

	private Bounds boundPaddleCenter;
	private Bounds boundPaddleLeft;
	private Bounds boundPaddleRight;


	public SpriteRenderer sprite;
	public BallMovementScript ballMovement;
	public PaddleMovementScript paddle;

	public Bounds LastBound;
	// Use this for initialization
	void Start()
	{
		boundUp		= boundUpCollider.bounds;
		boundDown	= boundDownCollider.bounds;
		boundRight	= boundRightCollider.bounds;
		boundLeft	= boundLeftCollider.bounds;

		boundPaddleCenter	= paddle.boxcenter.bounds;
		boundPaddleLeft		= paddle.boxleft.bounds;
		boundPaddleRight	= paddle.boxRight.bounds;

		ballBound = collider2D.bounds;
		LastBound = boundPaddleCenter;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		boundPaddleCenter	= paddle.boxcenter.bounds;
		boundPaddleLeft		= paddle.boxleft.bounds;
		boundPaddleRight	= paddle.boxRight.bounds;
		ballBound			= collider2D.bounds;
		if (boundUp.Intersects(ballBound) && LastBound != boundUp)
		{
			ballMovement.direction = Direction.inverse(ballMovement.direction);
			LastBound = boundUp;
			ballMovement.ballSpeed = ballMovement.defaultSpeed;

		}
		else if (boundPaddleCenter.Intersects(ballBound) && LastBound != boundPaddleCenter)
		{
			ballMovement.direction = Direction.inverse(ballMovement.direction);
			LastBound = boundPaddleCenter;
			ballMovement.ballSpeed = ballMovement.defaultSpeed;

		}
		else if(boundRight.Intersects(ballBound))
		{
			ballMovement.direction = Direction.opposite(ballMovement.direction);
			LastBound = boundRight;
			ballMovement.ballSpeed = ballMovement.defaultSpeed;

		}
		else if (boundLeft.Intersects(ballBound))
		{
			ballMovement.direction = Direction.opposite(ballMovement.direction);
			LastBound = boundLeft;
			ballMovement.ballSpeed = ballMovement.defaultSpeed;

		}
		else if(boundPaddleLeft.Intersects(ballBound))
		{
			var rand = Random.Range(0.0f, 1.0f);
			if (rand < 0.5f)
			{
				ballMovement.direction = Direction.leftUp;
				ballMovement.ballSpeed = ballMovement.defaultSpeed;
			}
			else
			{
				 ballMovement.direction = Direction.leftUp / 2;
				 ballMovement.ballSpeed = ballMovement.defaultSpeed * 2;
			}
			LastBound = boundPaddleLeft;
		}
		else if(boundPaddleRight.Intersects(ballBound))
		{
			var rand = Random.Range(0.0f, 1.0f);
			if (rand < 0.5f)
			{
				ballMovement.direction = Direction.rightUp;
				ballMovement.ballSpeed = ballMovement.defaultSpeed;
			}
			else
			{
				ballMovement.direction = Direction.rightUp/2;
				ballMovement.ballSpeed = ballMovement.defaultSpeed * 2;
			}
			LastBound = boundPaddleRight;
		}
		else if(boundDown.Intersects(ballBound))
		{
			//Debug.Log("boundDown");
			sprite.enabled = false;
			Thread.Sleep(100);
			ballMovement.FirstShoot();
			LastBound = boundDown;
		}
	}

	//void OnCollisionEnter2D(Collision2D coll)
	//{
	//	if(coll.collider.CompareTag("Border") || coll.collider.CompareTag("Player"))
	//	{
	//		Debug.Log("collision border or player");
	//		var velY = rigidbody2D.velocity;
	//		velY.y = (velY.y / 2.0f) + (coll.collider.rigidbody2D.velocity.y / 3.0f);
	//		rigidbody2D.velocity = velY;
	//	}
	//	if(coll.collider.CompareTag("boundDown"))
	//	{
	//		Debug.Log("collision boundDown");
	//	}
	//}
}
