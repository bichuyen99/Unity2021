using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 v;
    private Quaternion q;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = new Vector3(30,90,45).normalized;
        float c = 100;
        Vector3 force = dir * c * Time.fixedDeltaTime;
        GetComponent<Rigidbody>().AddTorque(force, ForceMode.Impulse);
        q = transform.rotation;
    }
}
