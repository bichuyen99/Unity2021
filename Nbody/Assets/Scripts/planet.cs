using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
    public Vector3 v1, v2;
    public float m1, m2;
    private GameObject anPlanet;
    private Rigidbody planet1;
    private Rigidbody planet2;
    // Start is called before the first frame update
    void Start()
    {
        anPlanet = GameObject.Find("Planet2");
        planet1 = GetComponent<Rigidbody>();
        planet2 = anPlanet.GetComponent<Rigidbody>();
        v1 = new Vector3(0, transform.position.y, -transform.position.z) * 0.9f;
        v2 = new Vector3(0, planet2.transform.position.y, -planet2.transform.position.z) * -0.7f;
        planet1.AddForce(v1, ForceMode.VelocityChange);
        planet2.AddForce(v2, ForceMode.VelocityChange);
        Vector3 dir1 = -transform.position.normalized;
        Vector3 dir2 = -planet2.transform.position.normalized;
        float lenght = Mathf.Sqrt(Mathf.Pow(transform.position.x - planet2.transform.position.x, 2) + Mathf.Pow(transform.position.y - planet2.transform.position.y, 2) + Mathf.Pow(transform.position.z - planet2.transform.position.z, 2));
        float c = 6.67e-6f * planet1.mass * planet2.mass / (lenght * lenght);
        Vector3 force = -(transform.position - planet2.transform.position).normalized * c * Time.fixedDeltaTime;
        planet1.AddForce(force, ForceMode.Impulse);
        planet2.AddForce(-force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir1 = -transform.position.normalized;
        Vector3 dir2 = -planet2.transform.position.normalized;
        float lenght = Mathf.Sqrt(Mathf.Pow(transform.position.x-planet2.transform.position.x,2)+ Mathf.Pow(transform.position.y - planet2.transform.position.y, 2)+ Mathf.Pow(transform.position.z - planet2.transform.position.z, 2));
        float c = 6.67e-6f * planet1.mass * planet2.mass / (lenght * lenght);
        Vector3 force = -(transform.position-planet2.transform.position).normalized * c * Time.fixedDeltaTime;
        planet1.AddForce(force, ForceMode.Impulse);
        planet2.AddForce(-force, ForceMode.Impulse);
    }
}
