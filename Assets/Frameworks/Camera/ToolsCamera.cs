using UnityEngine;
using System.Collections;

public class ToolsCamera : MonoBehaviour
{

	protected Rect screenRect;
	[SerializeField]
	protected float aspect;
	protected Vector3[] corners;
	protected Camera mCamera;
	public new Camera camera
	{
		get { return mCamera; }
	}

	public enum Edge
	{
		None = 0,
		Up,
		Down,
		Left,
		Right,
	}

	protected virtual void Start()
	{
		mCamera = GetComponent<Camera>();
		mCamera.aspect = aspect;
		screenRect = new Rect(Screen.width * GetComponent<Camera>().rect.x,
								Screen.height * GetComponent<Camera>().rect.y,
								Screen.width * GetComponent<Camera>().rect.width,
								Screen.height * GetComponent<Camera>().rect.height);
	}

	/*public bool IsVisible(Transform tran, float outlinebound)
	{
		float xbound = Mathf.Max(Mathf.Abs(tran.position.x - transform.position.x) - outlinebound, 0);
		float zbound = Mathf.Max(Mathf.Abs(tran.position.z - transform.position.z) - outlinebound, 0);
		Vector3 pos = new Vector3(transform.position.x + xbound, tran.position.y, transform.position.z + zbound);

		bool inYView = (pos.y > transform.position.y - mCamera.farClipPlane) &&
						(pos.y < transform.position.y - mCamera.nearClipPlane);
		pos = mCamera.WorldToScreenPoint(pos);
		
		return screenRect.Contains(pos) && inYView;
	}*/

	public bool IsVisible(Transform tran, float outline)
	{
		float xita = mCamera.fieldOfView / 2 * Mathf.Deg2Rad;
		float zDis = ( mCamera.transform.position.y - tran.position.y ) * Mathf.Tan(xita);
		float xDis = zDis * mCamera.aspect;
		float xFactor = outline / ( xDis * 2 );
		float yFactor = outline / ( zDis * 2 );
		bool b = false;

		Vector3 pos = mCamera.WorldToViewportPoint(tran.position);
		if (pos.x >= -xFactor && pos.x <= 1 + xFactor && pos.y >= -yFactor && pos.y <= 1 + yFactor)
		{
			b = true;
		}

		bool inYView = ( pos.y > transform.position.y - mCamera.farClipPlane ) &&
						( pos.y < transform.position.y - mCamera.nearClipPlane );

		return b && inYView;
	}

	public Edge IsEdge(Vector3 pos)
	{
		Vector2 viewPos = mCamera.WorldToViewportPoint(pos);

		if (viewPos.x <= 0.0f)
		{
			return Edge.Left;
		}

		if (viewPos.x >= 1.0f)
		{
			return Edge.Right;
		}

		if (viewPos.y <= 0.0f)
		{
			return Edge.Down;
		}

		if (viewPos.y >= 1.0f)
		{
			return Edge.Up;
		}

		return Edge.None;
	}

	public bool InViewport(Vector3 pos)
	{
		pos = mCamera.WorldToViewportPoint(pos);
		if (pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}


	public Vector3 MoveInViewport(Vector3 current, Vector3 direction, float speed)
	{
		return MoveInViewport(current, direction, speed, new Vector4(1, 0, 0, 1)); //edge up down left right (0~1)
	}

	public Vector3 MoveInViewport(Vector3 current, Vector3 direction, float speed, Vector4 edge)
	{
		Vector3 nextPos = current + ( direction * Time.deltaTime * speed );
		Vector3 pos = mCamera.WorldToViewportPoint(nextPos);
		if (direction == Vector3.up && pos.y <= edge[0])
		{
			return nextPos;
		}
		else if (direction == Vector3.down && pos.y >= edge[1])
		{
			return nextPos;
		}
		else if (direction == Vector3.left && pos.x >= edge[2])
		{
			return nextPos;
		}
		else if (direction == Vector3.right && pos.x <= edge[3])
		{
			return nextPos;
		}
		return current;
	}

	public Vector3 MoveInViewportXZ(Vector3 current, Vector3 direction, float speed)
	{
		return MoveInViewportXZ(current, direction, speed, new Vector4(0.9f, 0.1f, 0.1f, 0.9f)); //edge up down left right (0~1)
	}

	public Vector3 MoveInViewportXZ(Vector3 current, Vector3 direction, float speed, Vector4 edge)
	{
		Vector3 nextPos = current + ( new Vector3(direction.x, direction.z, direction.y) * Time.deltaTime * speed );
		Vector3 pos = mCamera.WorldToViewportPoint(nextPos);
		if (Vector3Approximate(direction, Vector3.up) && pos.y <= edge[0])
		{
			return nextPos;
		}
		else if (Vector3Approximate(direction, Vector3.down) && pos.y >= edge[1])
		{
			return nextPos;
		}
		else if (Vector3Approximate(direction, Vector3.left) && pos.x >= edge[2])
		{
			return nextPos;
		}
		else if (Vector3Approximate(direction, Vector3.right) && pos.x <= edge[3])
		{
			return nextPos;
		}

		return current;
	}

	bool Vector3Approximate(Vector3 v1, Vector3 v2)
	{
		if (Mathf.Abs(v1.x - v2.x) < 0.005f && Mathf.Abs(v1.y - v2.y) < 0.005f && Mathf.Abs(v1.z - v2.z) < 0.005f)
			return true;

		return false;
	}

	public Vector3 WorldToView(Vector3 position)
	{
		return mCamera.WorldToViewportPoint(position);
	}

	public Vector3 WorldToView(Vector3 position, float z)
	{
		position = mCamera.WorldToViewportPoint(position);
		position.z = z;
		return position;
	}

	public Vector3 ViewToWorld(Vector3 position)
	{
		return ViewToWorld(position, position.z);
	}

	public Vector3 ViewToWorld(Vector3 position, float farFromCamera)
	{
		position.z = farFromCamera;
		return mCamera.ViewportToWorldPoint(position);
	}

	public Vector3 WorldToViewToWorld(Vector3 position, float farFromCamera)
	{
		position = mCamera.WorldToViewportPoint(position);
		position.z = farFromCamera;
		return mCamera.ViewportToWorldPoint(position);
	}

	public Vector3 WorldToCameraWorld(Vector3 position, ToolsCamera cam, float farFromCamera)
	{
		position = WorldToView(position);
		return cam.ViewToWorld(position, farFromCamera);
	}

	protected virtual void OnDrawGizmos()
	{
		if (GetComponent<Camera>().aspect == 1)
		{  //防止Unity5.0启动的时候报错。5.0刚启动摄像机的aspect为1
			return;
		}
		mCamera = GetComponent<Camera>();
		aspect = GetComponent<Camera>().aspect;
		//corners = NGUITools.GetWorldCorners(GetComponent<Camera>(), GetComponent<Camera>().farClipPlane);
	}

	protected void DrawCameraView(Camera camera, Color color, float aspect, float scale)
	{
		Matrix4x4 currentMatrix = Gizmos.matrix;
		Gizmos.color = color;
		if (camera.orthographic)
		{
			Gizmos.matrix = Matrix4x4.TRS(camera.transform.position,
										camera.transform.rotation,
										new Vector3(1 * scale, 1 * scale, 1));
			float spread = camera.farClipPlane - camera.nearClipPlane;
			float center = ( camera.farClipPlane + camera.nearClipPlane ) * 0.5f;
			Gizmos.DrawWireCube(new Vector3(0, 0, center),
								new Vector3(camera.orthographicSize * 2 * camera.aspect,
								camera.orthographicSize * 2,
								spread));
		}
		else
		{
			Gizmos.matrix = Matrix4x4.TRS(camera.transform.position,
										camera.transform.rotation,
										new Vector3(scale, scale * aspect, 1));
			Gizmos.DrawFrustum(Vector3.zero,
								camera.fieldOfView,
								camera.farClipPlane,
								camera.nearClipPlane,
								aspect);
		}
		Gizmos.matrix = currentMatrix;
	}

	protected void DrawAreaPlane(Camera camera, Color color, float ypos, Vector3[] corners)
	{
		if (camera.orthographic)
		{
			Vector3 center = Vector3.Lerp(corners[0], corners[2], 0.5f);
			center.y = ypos;
			Vector3 size = corners[2] - corners[0];
			Gizmos.color = color;
			Gizmos.DrawCube(center, size);
		}
		else
		{
			float scale = Mathf.Abs(ypos - camera.transform.position.y) / camera.farClipPlane;
			Vector3[] areaCorners = new Vector3[4];
			for (int i = 0; i < corners.Length; i++)
			{
				areaCorners[i] = Vector3.Lerp(camera.transform.position, corners[i], scale);
			}

			Vector3 center = Vector3.Lerp(areaCorners[0], areaCorners[2], 0.5f);
			Vector3 size = areaCorners[2] - areaCorners[0];
			Gizmos.color = color;
			Gizmos.DrawCube(center, size);
		}
	}

	protected void DrawAreaPlane(Camera camera, Color color, float ypos, Vector3[] corners, float outline)
	{
		if (camera.orthographic)
		{
			Vector3 center = Vector3.Lerp(corners[0], corners[2], 0.5f);
			center.y = ypos;
			Vector3 size = corners[2] - corners[0];
			Gizmos.color = color;
			Gizmos.DrawCube(center, size + new Vector3(outline, 0, outline) * 2.828f);
		}
		else
		{
			float scale = Mathf.Abs(ypos - camera.transform.position.y) / camera.farClipPlane;
			Vector3[] areaCorners = new Vector3[4];
			for (int i = 0; i < corners.Length; i++)
			{
				areaCorners[i] = Vector3.Lerp(camera.transform.position, corners[i], scale);
			}

			Vector3 center = Vector3.Lerp(areaCorners[0], areaCorners[2], 0.5f);
			Vector3 size = areaCorners[2] - areaCorners[0];
			Gizmos.color = color;
			Gizmos.DrawCube(center, size + new Vector3(outline, 0, outline) * 2f);
		}
	}
}