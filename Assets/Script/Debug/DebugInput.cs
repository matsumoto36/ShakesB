﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour {

	[SerializeField]
	ushort pulseIn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
		var device = SteamVR_Controller.Input((int)trackedObject.index);

		if(device == null) return;

		DeviceInput(device);

		// 着席モードでRキーで位置トラッキングをリセットする
		if(Input.GetKeyDown(KeyCode.R)) {
			SteamVR.instance.hmd.ResetSeatedZeroPose();
		}

		if(Input.GetKey(KeyCode.P)) {
			DevicePulse(device, pulseIn);
		}

	}


	/// <summary>
	/// 入力
	/// </summary>
	void DeviceInput(SteamVR_Controller.Device device) {

		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("トリガーを浅く引いた");
		}
		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("トリガーを深く引いた");
		}
		if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("トリガーを離した");
		}
		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log("タッチパッドをクリックした");
		}
		if(device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log("タッチパッドをクリックしている");
		}
		if(device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log("タッチパッドをクリックして離した");
		}
		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log("タッチパッドに触った");
		}
		if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log("タッチパッドを離した");
		}
		if(device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			Debug.Log("メニューボタンをクリックした");
		}
		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log("グリップボタンをクリックした");
		}

		if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("トリガーを浅く引いている");
		}
		if(device.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("トリガーを深く引いている");
		}
		if(device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log("タッチパッドに触っている");
		}
	}

	/// <summary>
	/// 振動
	/// </summary>
	/// <param name="pulse"></param>
	void DevicePulse(SteamVR_Controller.Device device, ushort pulse) {

		device.TriggerHapticPulse(pulse);
	}
}
