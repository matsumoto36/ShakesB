using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    [SerializeField]
    float Shakes;

    public bool isShake
    {
        get; set;
    }

    [SerializeField]
    bool isLeft;

    [SerializeField]
    Vector3 acc;

    [SerializeField]
    GameObject drinkPref;

    GameObject drink;

    [SerializeField]
    Player player;
    OVRHapticsClip pulseClip;

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

    /// <summary>
    /// 振動の強度を変更
    /// </summary>
    /// <param name="pulse"></param>
    public void SetPulse(byte pulse)
    {
        byte[] bff = new byte[8];
        for (int i = 0; i < bff.Length; i++)
        {
            bff[i] = pulse;
        }

        pulseClip = new OVRHapticsClip(bff, bff.Length);
    }

    /// <summary>
    /// 振動
    /// </summary>
    public void Pulse()
    {
        if (isLeft)
        {
            OVRHaptics.LeftChannel.Mix(pulseClip);
        }
        else
        {
            OVRHaptics.RightChannel.Mix(pulseClip);
        }
    }

	void OnTriggerEnter(Collider c) {
		Debug.Log("touch");
        if (c.gameObject.name == "Cube") {
            // UDH
            drink = Instantiate(drinkPref, transform.parent);
            var d = drink.GetComponent<Drink>();
            d.player = player;
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
