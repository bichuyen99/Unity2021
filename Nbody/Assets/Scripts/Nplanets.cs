using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nplanets : MonoBehaviour
{
    public bool spawned = false;
    private string label = "";
    public int n = 5;
    public int mult = 10;
    public GameObject planet;
    public GameObject[] planets;
    public Vector3 v1, v2;
    public float m1, m2;
    private Rigidbody rb1;
    private Rigidbody rb2;
    // Start is called before the first frame update
    public void MorePlanets()
    {
        n++;
        label = n.ToString("f3");
    }

    public void LessPlanets()
    {
        n--;
        label = n.ToString("f3");
    }

	private void Awake()
	{
        label = n.ToString("f3");
    }
	public void Spawn()
    {
        
        planets = new GameObject[n];
        for (int i = 0; i < n; i++)
		{
            planets[i] = Instantiate(planet);
            planets[i].transform.position = new Vector3(Random.Range(-5f,5f)*i, Random.Range(-5f, 5f) * i, Random.Range(-5f, 5f) * i);
            rb1 = planets[i].GetComponent<Rigidbody>();
            v1 = new Vector3(0, rb1.transform.position.y+ Random.Range(-5f, 5f) * i, -rb1.transform.position.z) * 0.5f;
            rb1.AddForce(v1, ForceMode.VelocityChange);
        }
        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
            {
                if (i == j)
                    continue;
                rb1 = planets[i].GetComponent<Rigidbody>();
                rb2 = planets[j].GetComponent<Rigidbody>();
                Vector3 dir1 = -rb1.transform.position.normalized;
                Vector3 dir2 = -rb2.transform.position.normalized;
                float lenght = Mathf.Sqrt(Mathf.Pow(rb1.transform.position.x - rb2.transform.position.x, 2) + Mathf.Pow(rb1.transform.position.y - rb2.transform.position.y, 2) + Mathf.Pow(rb1.transform.position.z - rb2.transform.position.z, 2));
                float c = 100*rb1.mass * rb2.mass / (lenght * lenght);
                Vector3 force = -(rb1.transform.position - rb2.transform.position).normalized * c * Time.fixedDeltaTime;
                rb1.AddForce(force, ForceMode.Impulse);
                rb2.AddForce(-force, ForceMode.Impulse);
            }
        spawned = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int res = 0;
        if (spawned)
        {
            for (int i = 0; i < n; i++)
                for (int j = i; j < n-1; j++)
                {
                    if (i == j)
                        continue;
                    if ((planets[i] == null) || (planets[j] == null))
                        continue;
                    rb1 = planets[i].GetComponent<Rigidbody>();
                    rb2 = planets[j].GetComponent<Rigidbody>();
                    Vector3 dir1 = -rb1.transform.position.normalized;
                    Vector3 dir2 = -rb2.transform.position.normalized;
                    float lenght = Mathf.Sqrt(Mathf.Pow(rb1.transform.position.x - rb2.transform.position.x, 2) + Mathf.Pow(rb1.transform.position.y - rb2.transform.position.y, 2) + Mathf.Pow(rb1.transform.position.z - rb2.transform.position.z, 2));
                    if (lenght <= (planets[i].transform.localScale.x+ planets[j].transform.localScale.x))
                    {
                        planets[i].transform.localScale = new Vector3(2,2,2);
                        planets[j] = null;
                        continue;
                    }
                  
                    float c = mult * rb1.mass * rb2.mass / (lenght * lenght);
                    Vector3 force = -(rb1.transform.position - rb2.transform.position).normalized * c * Time.fixedDeltaTime;
                    rb1.AddForce(force, ForceMode.Impulse);
                    rb2.AddForce(-force, ForceMode.Impulse);
                }
            for (int i = 0; i < n; i++)
            {
                if (planets[i] != null)
                    res++;
            }
            label = res.ToString("f3");
        }
    }
    void OnGUI()
    {
        GUI.skin.label.fixedHeight = 40;
        GUI.skin.label.fontSize = 24;
        GUI.Label(new Rect(10, 10, 400, 30), label);
    }
}
