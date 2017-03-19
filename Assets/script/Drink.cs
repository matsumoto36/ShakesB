using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour {
	public float energy = 500;
	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public float jet(float _energy){
		if (energy - _energy >= 0) {
			energy -= _energy;
			return _energy;
		} else {
			
			return 0;
		}
	}
}
