using UnityEngine;
using System.Collections;
using UnityEditor;

public class PaddleMovementScript : MonoBehaviour
{

	public KeyCode moveLeft = KeyCode.LeftArrow; //a changer pour les detections
	public KeyCode moveRight = KeyCode.RightArrow; //a changer pour les detections

	public float speed = 1f;
	private Vector2 defaultPos = new Vector2(0, -4);

	public BoxCollider2D boxleft;
	public BoxCollider2D boxRight;
	public BoxCollider2D boxcenter;


	void Update()
	{
		/*pour la main ce sera : 
		 * transform.position = new Vector3(positionMain.x, transform.position.y);;
		 */
        /*
		if(Input.GetKey(moveLeft) && transform.position.x > -7.5f)
		{
			transform.Translate(new Vector2(0,1) * speed * Time.deltaTime);
		}
		else if(Input.GetKey(moveRight) && transform.position.x < 7.5f)
		{
			transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
		}
        */

	}

}
