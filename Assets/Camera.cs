using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
	public float minHeight = 4f;
	public float factor = 3f;
	public float CameraHeightFactor = 3f;

	public Transform viper;

	float height = 4f;

	void FixedUpdate ()
	{
		height = Mathf.Lerp(transform.position.y, minHeight * (1 + viper.GetComponent<Rigidbody>().velocity.magnitude / CameraHeightFactor), 0.1f);
		transform.position = Vector3.Lerp(transform.position, new Vector3(viper.position.x, height, viper.position.z), factor);	
	}
}
