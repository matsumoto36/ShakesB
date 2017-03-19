using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

	public bool isPlay;
	bool _isPlay;

	ParticleSystem p;

	// Use this for initialization
	void Start () {
		isPlay = true;
		_isPlay = true;
		p = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isPlay ^ _isPlay) {
			_isPlay = isPlay;
			EnableParticle(isPlay);
		}

	}

	void EnableParticle(bool enable) {
		if(enable) {
			p.Play();
		}
		else {
			p.Stop();
		}

	}
}
