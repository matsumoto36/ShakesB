using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class DebugInput : MonoBehaviour {

	[SerializeField]
	byte pulseIn;

	OVRHapticsClip clip;

	// Use this for initialization
	void Start () {

		byte[] samples = new byte[8];
		for(int i = 0;i < samples.Length;i++) {
			samples[i] = pulseIn;
		}

		clip = new OVRHapticsClip(samples, samples.Length);
	}
	
	// Update is called once per frame
	void Update () {

		//if(device == null) return;

		DeviceInput();

		// 着席モードでRキーで位置トラッキングをリセットする
		if(Input.GetKeyDown(KeyCode.R)) {
			InputTracking.Recenter();
		}

		if(Input.GetKey(KeyCode.P)) {
			DevicePulse(clip);
		}

	}


	void DeviceSensor() {

		if(OVRInput.Get(OVRInput.RawNearTouch.LIndexTrigger)) {
			Debug.Log("左人差し指用トリガーの近くに指がある");
		}
		if(OVRInput.Get(OVRInput.RawNearTouch.LThumbButtons)) {
			Debug.Log("左アナログスティックの近くに指がある");
		}

		if(OVRInput.Get(OVRInput.RawNearTouch.RIndexTrigger)) {
			Debug.Log("右人差し指用トリガーの近くに指がある");
		}
		if(OVRInput.Get(OVRInput.RawNearTouch.RThumbButtons)) {
			Debug.Log("右アナログスティックの近くに指がある");
		}
	}

	/// <summary>
	/// 入力
	/// </summary>
	void DeviceInput() {

		if(OVRInput.GetDown(OVRInput.RawButton.A)) {
			Debug.Log("Aボタンを押した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.B)) {
			Debug.Log("Bボタンを押した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.X)) {
			Debug.Log("Xボタンを押した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.Y)) {
			Debug.Log("Yボタンを押した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.Start)) {
			Debug.Log("メニューボタン（左アナログスティックの下にある）を押した");
		}

		if(OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) {
			Debug.Log("右人差し指トリガーを押した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) {
			Debug.Log("右中指トリガーを押した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)) {
			Debug.Log("左人差し指トリガーを押した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.LHandTrigger)) {
			Debug.Log("左中指トリガーを押した");
		}
	}

	/// <summary>
	/// 振動
	/// </summary>
	/// <param name="pulse"></param>
	void DevicePulse(OVRHapticsClip hapticsClip) {


		OVRHaptics.RightChannel.Mix(hapticsClip);
		OVRHaptics.LeftChannel.Mix(hapticsClip);
	}
}
