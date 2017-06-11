using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour {

    public int rotateOffset;
    Vector3 newrotation;

    void Update ()
    {
        /*if (Input.GetKey("left") && gameObject.transform.eulerAngles.y < 220)
        {
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,
                                                            gameObject.transform.eulerAngles.y + rotateOffset,
                                                            gameObject.transform.eulerAngles.z
                                                          );
        }
        if (Input.GetKey("right") && gameObject.transform.eulerAngles.y > 120)
        {
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,
                                                            gameObject.transform.eulerAngles.y - rotateOffset,
                                                            gameObject.transform.eulerAngles.z
                                                          );
        }*/


        newrotation = transform.position - Input.mousePosition / 100;
        //Debug.Log("Vect x: " + transform.localEulerAngles.x + " | y: " + transform.localEulerAngles.y + " | z: " + transform.localEulerAngles.z);
        transform.localEulerAngles = newrotation;
    }
}
