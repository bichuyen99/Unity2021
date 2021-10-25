using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour

{
    public Vector3 V;

    void Start()
    {
        V = new Vector3(0, transform.position.z, -transform.position.y) * 1.7f;
        GetComponent<Rigidbody>().AddForce(V, ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {
        float length = transform.position.magnitude;
        float C = 6.67e-11f * 6e12f * GetComponent<Rigidbody>().mass / (length * length);
        Vector3 Force = -transform.position.normalized * C;
        GetComponent<Rigidbody>().AddForce(Force * Time.fixedDeltaTime, ForceMode.Impulse);
    }


    void Update()
    {

    }
}
