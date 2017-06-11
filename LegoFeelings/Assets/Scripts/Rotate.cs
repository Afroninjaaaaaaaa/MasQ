using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    float speed;

    void Start ()
    {
        speed = Random.Range(5.0f, 10.0f);
	}
	
	void Update ()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}
