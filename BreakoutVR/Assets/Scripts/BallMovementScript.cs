using UnityEngine;
using System.Collections;


public class BallMovementScript : MonoBehaviour
{
	public Transform trPaddle;
	public float ballSpeed = 1f;
	public float defaultSpeed;
	private Vector2 defaultPos;

	public Vector2 direction;

	public SpriteRenderer sprite;

	// Use this for initialization
	void Start()
	{
		defaultSpeed = ballSpeed;
		FirstShoot();
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(direction * ballSpeed * Time.deltaTime);
	}

	public void FirstShoot()
	{
		sprite.enabled = true;
		defaultPos = new Vector2(trPaddle.position.x, trPaddle.transform.position.y + 0.5f);
		transform.position = defaultPos;
		//var rand = Random.Range(0.0f, 100.0f);
		//direction = rand < 50.0f ? Direction.rightUp : Direction.leftUp;
		direction = Direction.up;
	}
}
