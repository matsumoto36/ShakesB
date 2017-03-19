using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    [SerializeField]
    float Shakes;

    [SerializeField]
    bool isLeft;

    [SerializeField]
    float sx;
    [SerializeField]
    float sy;
    [SerializeField]
    float sz;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //OVRDevice.GetAcceleration(ref sx, ref sy, ref sz);

    }


	void OnTriggerEnter(Collider c) {
		Debug.Log("touch");
	}
}
