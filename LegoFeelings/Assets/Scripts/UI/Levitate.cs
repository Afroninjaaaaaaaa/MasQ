using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour {

    public float offset;
    Vector3 startPosition;

	// Use this for initialization
	void Start ()
    {
        startPosition = transform.position;
    }
	void Update ()
    {
        transform.position = new Vector3(transform.position.x + Random.Range(-offset, offset), transform.position.y + Random.Range(-offset, offset), transform.position.z);
        //transform.position = startPosition;
    }
}
