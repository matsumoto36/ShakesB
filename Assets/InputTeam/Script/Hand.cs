using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    [SerializeField]
    float Shakes;

    [SerializeField]
    bool isLeft;

    [SerializeField]
    Vector3 acc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isLeft)
        {
            acc = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.LTouch);
        }
        else
        {
            acc = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.RTouch);
        }

        float sum = Mathf.Abs(acc.x) + Mathf.Abs(acc.y) + Mathf.Abs(acc.z);
        if (sum > 1.0f) Shakes += sum;
        Shakes = Mathf.Max(100000, Shakes);
    }


	void OnTriggerEnter(Collider c) {
		Debug.Log("touch");
	}
}
