using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

	bool detected = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Base: Vidas recargadas!!");
			GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.green);
			GetComponent<Light>().enabled = true;
			if (!detected)
			{
				other.GetComponent<Viper>().baseFounded();
			}
			other.GetComponent<Viper>().lives = 3;
		}

	}
}
