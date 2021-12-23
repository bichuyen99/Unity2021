using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float alpha = 45, beta = 10, speed = 8;
	private Vector3 v;

	void Start()
	{
		v = new Vector3(speed * Mathf.Sin(alpha*180/Mathf.PI) * Mathf.Cos(beta*180/Mathf.PI),
		speed * Mathf.Cos(alpha*180/Mathf.PI),
		speed * Mathf.Sin(alpha*180/Mathf.PI) * Mathf.Sin(beta*180/Mathf.PI));
		GetComponent<Rigidbody>().AddForce(v, ForceMode.VelocityChange);
	}
	void FixedUpdate()
	{
	
	}
}
