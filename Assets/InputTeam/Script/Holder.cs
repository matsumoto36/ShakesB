using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour {

    [SerializeField]
    Transform owner;

    Vector3 offset;

    float rotY;

	// Use this for initialization
	void Start () {
        offset = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = owner.position + offset;

        rotY = owner.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
