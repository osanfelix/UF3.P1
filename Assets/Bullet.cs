using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	float baseSpeed = 0f;
	public float speed = 1f;

	Vector3 direction = Vector3.zero;

	public void setDirection(Vector3 dir)
	{
		direction = dir;
	}

	public void setCurrentSpeed(float currentSpeed)
	{
		baseSpeed = currentSpeed;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position = transform.position + direction * (baseSpeed + speed) * Time.deltaTime;
	}
}