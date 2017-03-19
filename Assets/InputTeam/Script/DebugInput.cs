using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		//入力
		DeviceInput();

		//センサー
		if(Input.GetKey(KeyCode.S)) {
			SensorInput();
		}

		//振動
		if(Input.GetKey(KeyCode.P)) {
			DevicePulse(clip);
		}
	}

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

		/*  */
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

		if(OVRInput.GetDown(OVRInput.RawButton.LThumbstickUp)) {
			Debug.Log("左アナログスティックを上に倒した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown)) {
			Debug.Log("左アナログスティックを下に倒した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft)) {
			Debug.Log("左アナログスティックを左に倒した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight)) {
			Debug.Log("左アナログスティックを右に倒した");
		}

		if(OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp)) {
			Debug.Log("右アナログスティックを上に倒した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown)) {
			Debug.Log("右アナログスティックを下に倒した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft)) {
			Debug.Log("右アナログスティックを左に倒した");
		}
		if(OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight)) {
			Debug.Log("右アナログスティックを右に倒した");
		}
	}

	void SensorInput() {

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

	void DevicePulse(OVRHapticsClip hapticsClip) {
		OVRHaptics.RightChannel.Mix(hapticsClip);
		OVRHaptics.LeftChannel.Mix(hapticsClip);
	}
}
