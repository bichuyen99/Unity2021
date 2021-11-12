using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere1 : MonoBehaviour
{
	private float G = 0.1f;
	private Vector3 r10;
	private Vector3 F;
	private Vector3 F1;
	private Vector3 r20;
	public Vector3 v10;
	public Vector3 v20;
	private Vector3 r1;
	private Vector3 r2;
	private Vector3 vv1;
	private Vector3 vv2;
	private Vector3 r;
	private Vector3 v1;
	private Vector3 v2;
	private Vector3 rst;
	public GameObject planet1;
	private Rigidbody rb1;
	public GameObject planet2;
	private Rigidbody rb2;
	public GameObject center;
	private float m1 = 0;
	private float m2 = 0;

	// Start is called before the first frame update
	void Start()
    {
		r10 = planet1.transform.position;
		r20 = planet2.transform.position;
		rb1 = planet1.GetComponent<Rigidbody>();
		rb2 = planet2.GetComponent<Rigidbody>();
		m1 = rb1.mass;
		m2 = rb2.mass;		
		center.transform.position = (m1 * r10 + m2 * r20) / (m1 + m2);
		rb1.AddForce(v10, ForceMode.VelocityChange);
		rb2.AddForce(v20, ForceMode.VelocityChange);

	}

	// Update is called once per frame
	void Update()
    {
		r = planet2.transform.position - planet1.transform.position;
		rst = planet1.transform.position + m1 / (m1 + m2) * r;
		F = G * m1 * m2 * r / (r.magnitude * r.magnitude * r.magnitude);
		rb1.AddForce(F, ForceMode.Impulse);
		F1 = -F;
		rb2.AddForce(F1, ForceMode.Impulse);
		rst = (m1 * planet1.transform.position + m2 * planet2.transform.position) / (m1 + m2);
	
		center.transform.position = rst;
	}
}
