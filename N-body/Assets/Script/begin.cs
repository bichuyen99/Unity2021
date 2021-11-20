using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class begin : MonoBehaviour
{
    // Instantiates a prefab in a circle

    public GameObject prefab;
    public int numberOfObjects = 40;
    public float radius = 20f;


    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
           
            Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }

   
}
