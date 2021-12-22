using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassPosition : MonoBehaviour
{
	public float massa = 100;
    public GameObject spwn;
	public GameObject planet;
	Nplanets tester;
	// Start is called before the first frame update

	private void Start()
	{
		
	}
	void Update()
    {
		tester = GameObject.Find("spawner").GetComponent<Nplanets>();
		Rigidbody rb12;
		Vector3 pos;
		Vector3 temp = new Vector3(0,0,0);
		float mass = 0;
		var t = spwn.GetComponent<Nplanets>();
		t.planet = planet;
		if (t.spawned)
		{
			for (int i = 0; i < t.n; i++)
			{
				if (t.planets[i] != null)
				{
					rb12 = t.planets[i].GetComponent<Rigidbody>();
					if ((t.planets[i].transform.position-transform.position).magnitude <= 1000)
					{
						temp += t.planets[i].transform.position * mass/10;
						mass += rb12.mass;
					}
				}
			}
			pos = temp / mass;
			transform.position = pos;
		}
	}
}
