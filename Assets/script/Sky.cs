using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour {
	[SerializeField]
	private float flightLevel;
	public float FlightLevel {
		get {
			return flightLevel;
		}
		set {
				flightLevel = value;
		}
	}

	// Use this for initialization
	void Start () {
		//FlightLevel = 10;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, -flightLevel, transform.position.z);


	}
}
