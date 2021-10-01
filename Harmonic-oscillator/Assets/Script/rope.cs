using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
	public float angle = 30f;
    public float l = 5f;
    public float g = 9.8f;
    public float v_angle = 4f;
    private float alpha;
    private float omega;
    private float A;
    private float betta;

    // Start is called before the first frame update
    void Start()
    {
        omega = Mathf.Sqrt(g / l);
        angle = Mathf.Deg2Rad * angle;
        if (v_angle > 0.0001)
            alpha = Mathf.Atan(angle * omega / v_angle);
        else
            alpha = angle;
        A = Mathf.Sqrt(Mathf.Sqrt(angle) + (Mathf.Sqrt(v_angle) / Mathf.Sqrt(omega)));
        transform.position = new Vector3(l*Mathf.Sin(alpha), -l*Mathf.Cos(alpha), 0);
    }

    // Update is called once per frame
    void Update()
    {
        betta = Mathf.Sin(Time.time * omega + alpha) * A;
        transform.position = new Vector3(l*Mathf.Sin(betta), -l*Mathf.Cos(betta), 0);

    }
}
