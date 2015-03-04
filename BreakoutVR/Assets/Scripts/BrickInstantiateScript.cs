using UnityEngine;
using System.Collections;

public class BrickInstantiateScript : MonoBehaviour
{

	public GameObject brick;
	public Collider2D limitCollider;
	public static int nbBrickInstantiate = 30;
	public int nbBrick = 30;
	public static bool win = false;

	// Use this for initialization
	void Start()
	{
		win = false;
		var bound = limitCollider.bounds;
		var sizeX = brick.transform.localScale.x;
		var sizeY = brick.transform.localScale.y;
		var i = nbBrick;
		var startPoint = new Vector2((bound.center.x - bound.max.x) + sizeX, (bound.center.y + bound.max.y) - sizeY);
		var endPoint = new Vector2((bound.center.x + bound.max.x) - sizeX, (bound.center.y - bound.max.y) + sizeY);
		//Debug.Log("Start : " + startPoint);
		//Debug.Log("End : " + endPoint);
		while(i >= 0)
		{
			//Debug.Log("while, i = " + i + ", start y : " + startPoint.y + ", end y : " + endPoint.y + ", sizeY : " + sizeY);
			for(var j = startPoint.y ; j >= endPoint.y ; j -= sizeY)
			{
				//Debug.Log("for1, j = " + j);
				for(var k = startPoint.x ; k <= endPoint.x ; k += sizeX)
				{
					if(i < 0)
						break;
					var rand = Random.Range(0.0f, 100.0f);
					if (rand > 50f)
					{
						var go = Instantiate(brick) as GameObject;
						go.transform.position = new Vector2(k, j);
						i--;
					}
				}
			}
		}
		nbBrickInstantiate = nbBrick - i;
	}

	// Update is called once per frame
	void Update()
	{
		if(nbBrickInstantiate == 0)
			win = true;
	}
}
