using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
    private HashSet<Rigidbody> affectedbodies = new HashSet<Rigidbody>();
    private Rigidbody componentRigidbody;
    float G = 6.67408e-2F;

    void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedbodies.Add(other.attachedRigidbody);

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedbodies.Remove(other.attachedRigidbody);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Rigidbody body in affectedbodies)
        {
            Vector3 directionToPlanet = (transform.position - body.position).normalized;
            float distence = (transform.position - body.position).magnitude;
            float force = G * body.mass * componentRigidbody.mass / (distence * distence);
            body.AddForce(directionToPlanet * force, ForceMode.Impulse);

        }
    }
}
