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

    [SerializeField]
    GameObject drinkPref;

    GameObject drink;

    [SerializeField]
    Player player;

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
        if (c.gameObject.name == "Cube") {
            // UDH
            drink = Instantiate(drinkPref, transform.parent);
        }
        else if (c.gameObject.name == "Holder1") {
            // 右のホルダー
            player.drink1 = drink.GetComponent<Drink>();
            drink = null;
        }
        else if (c.gameObject.name == "Holder2") {
            // 左のホルダー
            player.drink2 = drink.GetComponent<Drink>();
            drink = null;
        }
	}
}
