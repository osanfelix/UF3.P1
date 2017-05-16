using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform gun;
	public Transform player;
	public GameObject bullet;


	public float shotRate = 2f;
	float lastShotTime = 0;
	// Update is called once per frame
	void FixedUpdate ()
	{
		gun.LookAt(player);


		// Shot
		if(lastShotTime > shotRate)
		{
			lastShotTime = Random.Range(-1.5f, 0f);
			bullet = Instantiate(bullet);
			bullet.GetComponent<Bullet>().setEnemyTag("Player");
			bullet.GetComponent<Bullet>().speed = 0.5f;
			bullet.transform.position = transform.position + gun.forward * 0.1f;
			bullet.GetComponent<Bullet>().setDirection(gun.forward);
		}

		lastShotTime += Time.deltaTime;
	}

	
}
