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
            if (drink1 != null) Destroy(drink1.gameObject);
            drink1 = value;
        }
    }
    public Drink Drink2 {
        get { return drink2; }
        set {
            if (drink2 != null) Destroy(drink2.gameObject);
            drink2 = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var energy = 0.0f;
		if (Drink1 != null) energy += Drink1.jet(150000*Time.deltaTime);
		if (Drink2 != null) energy += Drink2.jet(150000*Time.deltaTime);
		velocity += energy - 0.98f*0.2f;
        if (velocity > 70) velocity = 70;
        if (velocity < -100) velocity = -100;
        flightLevel += (velocity) * Time.deltaTime;
        sky.FlightLevel = flightLevel;
        Debug.Log(velocity + ",," + energy);
        if (flightLevel<= 0) {
			flightLevel = 0;
            velocity = 0;
        }
        else
        {
        }
    }

}
