using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public Transform gun;
	public Transform player;
	public GameObject bullet;
	public float shootingDistance = 1;

	public float shotRate = 3f;
	float lastShotTime = 0;

	Queue<GameObject> bulletQueue = new Queue<GameObject>();

	// Update is called once per frame
	void Update()
	{
		if ((player.position - transform.position).magnitude < shootingDistance)
		{
			// Look for player
			gun.rotation = Quaternion.Slerp(gun.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 5f * Time.deltaTime);
			//gun.LookAt(player);

			// Shot
			if (lastShotTime > shotRate)
			{
				lastShotTime = 0;
				if (bulletQueue.Count < 10)
				{
					bullet = Instantiate(bullet);
					bullet.name = "Bullet_" + name + "_" + (bulletQueue.Count + 1);
				}
				else
				{
					bullet = bulletQueue.Dequeue();
				}
				bulletQueue.Enqueue(bullet);
				bullet.SetActive(true);

				bullet.tag = "Turret";
				bullet.GetComponent<Bullet>().speed = 0.5f;
				bullet.transform.position = transform.position + gun.forward * 0.1f;
				bullet.GetComponent<Bullet>().setDirection(gun.forward);
			}
		}
		lastShotTime += Time.deltaTime;
	}
}
