using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
    float flightLevel;
	[SerializeField]
	Sky sky;
	public float velocity = 0;
	public Drink drink1;
	public Drink drink2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		flightLevel += (velocity - 0.98f)* Time.deltaTime;
		sky.FlightLevel = flightLevel;
		float energy = drink1.jet(100*Time.deltaTime) + drink2.jet(100*Time.deltaTime);
		velocity = energy;



		if (flightLevel<= 0) {
			flightLevel = 0;
		}
	}

}
