using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    public Booster booster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            //Particle
            booster.isPlay = true;
            //LoadScene
            Invoke("LoadScene", 3.0f);
        }

    }

    void LoadScene()
    {
        SceneManager.LoadScene("scene2");
    }
}
