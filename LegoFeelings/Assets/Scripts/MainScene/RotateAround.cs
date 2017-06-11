using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    float speed;

    void Start ()
    {
        speed = Random.Range(5.0f, 10.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }
}
