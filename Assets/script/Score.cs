using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	[SerializeField]
	Sky sky;
	TextMesh flyscore;

	// Use this for initialization
	void Start () {
		flyscore = GetComponent<TextMesh> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		float fl = sky.FlightLevel;
		float time = Time.time + 900;
		flyscore.text = string.Format ("{0:n}",time);

	}
}
