using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viper : MonoBehaviour {
	public float acceleration = 20f;
	public float turnAcceleration = 2f;

	public GameObject bullet = null;

	float currentRotation = 0;
	Rigidbody rigid = null;


	void Start()
	{
		if(rigid == null)
			rigid = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		// Movement
		if (Input.GetKey(KeyCode.UpArrow))
			rigid.AddForce(-transform.forward * acceleration);
		else if (Input.GetKey(KeyCode.DownArrow))
			rigid.AddForce(transform.forward * acceleration);

		// Rotation
		if (Input.GetKey(KeyCode.LeftArrow))
			rigid.AddTorque(-transform.up * turnAcceleration);
		else if (Input.GetKey(KeyCode.RightArrow))
			rigid.AddTorque(transform.up * turnAcceleration);

		// Reset
		if (Input.GetKey(KeyCode.R))
		{
			rigid.MovePosition(Vector3.up * 5);
			rigid.MoveRotation(Quaternion.Euler(Vector3.zero));
			rigid.angularVelocity = Vector3.zero;
			rigid.velocity = Vector3.zero;
		}

		// Shot
		if(Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bala = Instantiate(bullet);
			bala.transform.position = transform.position - transform.forward * 0.1f;
			bala.GetComponent<Bullet>().setDirection(-transform.forward);
			//bala.GetComponent<Bullet>().setCurrentSpeed(rigid.velocity.magnitude);
			//bala.GetComponent<Bullet>().setCurrentSpeed(Vector3.Dot(-transform.forward, rigid.velocity));
		}
	}
}