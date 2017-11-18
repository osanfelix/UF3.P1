using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viper : MonoBehaviour {

	public int lives = 3;
	public int bases = 0;

	public float acceleration = 20f;
	public float turnAcceleration = 2f;

	public GameObject bullet = null;

	Rigidbody rigid = null;

	bool turningRight = false;
	bool turningLeft = false;

	bool movingForward = false;
	bool movingBackward = false;

	bool fire = false;

	Queue<GameObject> bulletQueue = new Queue<GameObject>();

	void Start()
	{
		Input.backButtonLeavesApp = true;

		if (rigid == null)
			rigid = GetComponent<Rigidbody>();
	}

	public void shot()
	{
		if (bulletQueue.Count < 10)
		{
			bullet = Instantiate(bullet);
			bullet.name = "Bullet_" + name + "_" + (bulletQueue.Count + 1);
			bullet.tag = gameObject.tag;
		}
		else
		{
			bullet = bulletQueue.Dequeue();
		}
		bulletQueue.Enqueue(bullet);
		bullet.SetActive(true);
		bullet.transform.position = transform.position + transform.forward * 0.1f;
		bullet.GetComponent<Bullet>().setDirection(transform.forward);
	}
	public void baseFounded()
	{
		bases++;


		if(bases == 4)
		{
			Debug.Log("¡¡Fin del juego!!");
		}
	}

	public void hit(GameObject other)
	{
		lives--;
		if (lives <= 0)
		{
			Debug.Log("Player: Nave destruida");
			gameObject.SetActive(false);
		}
		else
		{
			Debug.Log("Player: Daño recibido");
			rigid.AddExplosionForce(500, other.transform.position, 1);
		}
			
	}

	void FixedUpdate()
	{
		// Movement
		if (Input.GetKey(KeyCode.UpArrow) || movingForward)
			rigid.AddForce(transform.forward * acceleration);
		else if (Input.GetKey(KeyCode.DownArrow) || movingBackward)
			rigid.AddForce(-transform.forward * acceleration);

		// Rotation
		if (Input.GetKey(KeyCode.LeftArrow) || turningLeft)
			rigid.AddTorque(-transform.up * turnAcceleration);
		else if (Input.GetKey(KeyCode.RightArrow) || turningRight)
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
		if(Input.GetKeyDown(KeyCode.Space) || fire)
		{
			shot();
		}
	}


	public void inputLeft(bool on)
	{
		turningLeft = on;
	}

	public void inputRight(bool on)
	{
		turningRight = on;
	}

	public void inputUp(bool on)
	{
		movingForward = on;
	}

	public void inputDown(bool on)
	{
		movingBackward = on;
	}

	public void inputFire(bool on)
	{
		fire = on;
	}
}