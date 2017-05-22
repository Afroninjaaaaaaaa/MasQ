using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBody : MonoBehaviour {

    private float moveOffset = 0.1f;

	void Update () {
        if (Input.GetKey("z"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z + moveOffset
                );
        }
        if (Input.GetKey("s"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z - moveOffset
                );
        }
        if (Input.GetKey("q"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - moveOffset,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z
                );
        }
        if (Input.GetKey("d"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + moveOffset,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z
                );
        }
    }
}
