using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springs : MonoBehaviour
{
    private float omega; 
    private float A;			// amplitude 
    private float alpha;
    private float betta;

    public float k = 0.5f;		// coefficient
    public float v = 4.0f;   // speed of ball
    public float m = 1.0f;	// mass of ball
    public float x_0 = 0.0f;	// start location


    // Start is called before the first frame update
    void Start()
    {
        A = Mathf.Sqrt(Mathf.Pow(x_0,2) + Mathf.Pow(v,2)/Mathf.Pow(k,2));

        omega = Mathf.Sqrt(m / k);
        if (v > 0.0001)
            alpha = Mathf.Atan(x_0 * k / v);
        else
            alpha = x_0;
		//alpha = Mathf.Atan(x_0 * k / v);
		
        transform.position = new Vector3(Mathf.Sin(alpha) * A, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
    	betta = Time.time * omega + alpha;
        transform.position = new Vector3(Mathf.Sin(betta) * A, 0, 0);
    }
}
