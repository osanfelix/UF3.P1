using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
	public float minHeight = 4f;
	public float CameraHeightFactor = 3f;

	public Transform target;

	float height = 4f;

	void LateUpdate ()
	{
		//height = minHeight * (1 + target.GetComponent<Rigidbody>().velocity.magnitude / CameraHeightFactor);
		height = Mathf.Lerp(transform.position.y, minHeight * (1 + target.GetComponent<Rigidbody>().velocity.magnitude / CameraHeightFactor), 0.1f);
		transform.position = new Vector3(target.position.x, height, target.position.z);	
	}
}
