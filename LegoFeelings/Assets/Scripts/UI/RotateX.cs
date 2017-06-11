using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateX : MonoBehaviour {


    float speed;

    void Start()
    {
        speed = 0.01f;
    }

    void Update()
    {
        //transform.Rotate(Vector3.right * speed * Time.deltaTime);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + speed, transform.rotation.z, transform.rotation.w);
        Debug.Log(transform.rotation.y);
    }
}
