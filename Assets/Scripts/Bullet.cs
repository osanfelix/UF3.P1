using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 1f;

	Vector3 direction = Vector3.zero;

	public void setDirection(Vector3 dir)
	{
		direction = dir;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position = transform.position + direction * (speed) * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != gameObject.tag && other.tag != "Base")
		{
			if(other.tag == "Turret")
			{
				Debug.Log("Turret: Destruida unidad " + other.name);
				other.gameObject.SetActive(false);
			}
			else if(other.tag == "Player")
			{
				other.GetComponent<Viper>().hit(this.gameObject);
			}
			gameObject.SetActive(false);

		}
	}
}