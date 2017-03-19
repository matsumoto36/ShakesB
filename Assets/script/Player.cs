using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
    float flightLevel;
	[SerializeField]
	Sky sky;

	public GameObject drinkPref;
	public float velocity = 0;
    private Drink drink1;
    private Drink drink2;

    public Drink Drink1 {
        get { return drink1; }
        set {
            Destroy(drink1);
            drink1 = value;
        }
    }
    public Drink Drink2 {
        get { return drink2; }
        set {
            Destroy(drink2);
            drink2 = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		flightLevel += (velocity - 0.98f)* Time.deltaTime;
		sky.FlightLevel = flightLevel;
		var energy = 0.0f;
		if (Drink1 != null) energy += Drink1.jet(100*Time.deltaTime);
		if (Drink2 != null) energy += Drink2.jet(100*Time.deltaTime);
		velocity = energy;
		if (flightLevel<= 0) {
			flightLevel = 0;
		}
	}

}
