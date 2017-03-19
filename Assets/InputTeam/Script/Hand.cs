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
        if (drink) {
            float sum = Mathf.Abs(acc.x) + Mathf.Abs(acc.y) + Mathf.Abs(acc.z);
            if (sum > 1.0f) Shakes += sum;
            Shakes = Mathf.Max(100000, Shakes);
        }
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
            if (drink == null) {
                drink = CreateDrink();
            }
        }
        else if (c.gameObject.name == "Holder1") {
            // 右のホルダー
            if (drink != null) {
                player.Drink1 = drink.GetComponent<Drink>();
                SetDrinkToHolder(player.Drink1, c.gameObject.transform);
            }
        }
        else if (c.gameObject.name == "Holder2") {
            // 左のホルダー
            if (drink != null) {
                player.Drink2 = drink.GetComponent<Drink>();
                SetDrinkToHolder(player.Drink2, c.gameObject.transform);
            }
        }
	}
    
    GameObject CreateDrink () {
        var dobj = Instantiate(drinkPref, transform, true);
        dobj.transform.localPosition = new Vector3(0, 0.07f, -0.15f);
        dobj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        var d = dobj.GetComponent<Drink>();
        d.player = player;
        return dobj;
    }

    void SetDrinkToHolder (Drink d, Transform parent) {
        drink.transform.parent = parent;
        Debug.Log("Shakes " + Shakes);
        d.energy = Shakes;
        drink = null;
        Shakes = 0;
    }
}
