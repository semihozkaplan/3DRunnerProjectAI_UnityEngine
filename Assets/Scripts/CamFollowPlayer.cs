using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
	public Vector3 dist;
	public Transform cameraTarget;
	public Transform lookTarget;
	public float sSpeed = 10.0f;
	

	private void LateUpdate()
	{
		Vector3 dPos = cameraTarget.position + dist;
		Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
		transform.position = sPos;
		transform.LookAt(lookTarget.position);
	}
	
}
