using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour
{
	public static Vector2 rightUp	= new Vector2(1, 1);
	public static Vector2 rightDown = new Vector2(1, -1);
	public static Vector2 leftUp	= new Vector2(-1, 1);
	public static Vector2 leftDown	= new Vector2(-1, -1);
	public static Vector2 up		= new Vector2(0, 1);
	public static Vector2 down		= new Vector2(0,-1);
	public static Vector2 left		= new Vector2(-1, 0);
	public static Vector2 right		= new Vector2(1, 0);

	public static Vector2 opposite(Vector2 dir)
	{
		if(dir.Equals(up))
			return down;
		if(dir.Equals(down))
			return up;
		if(dir.Equals(right))
			return left;
		if(dir.Equals(left))
			return right;
		if(dir.Equals(rightUp) || dir.Equals(rightUp/2))
			return leftUp;
		if(dir.Equals(rightDown))
			return leftDown;
		if(dir.Equals(leftUp) || dir.Equals(leftUp / 2))
			return rightUp;
		if(dir.Equals(leftDown))
			return rightDown;
		return Vector2.zero;
	}

	public static Vector2 inverse(Vector2 dir)
	{
		if(dir.Equals(up))
			return down;
		if(dir.Equals(down))
			return up;
		if(dir.Equals(right))
			return left;
		if(dir.Equals(left))
			return right;
		if(dir.Equals(rightUp) || dir.Equals(rightUp / 2))
			return rightDown;
		if(dir.Equals(rightDown))
			return rightUp;
		if(dir.Equals(leftUp) || dir.Equals(leftUp / 2))
			return leftDown;
		if(dir.Equals(leftDown))
			return leftUp;
		return Vector2.zero;
	}
}