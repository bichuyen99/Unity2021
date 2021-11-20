using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fosrce : MonoBehaviour
{
    public Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(force);
    }
}
