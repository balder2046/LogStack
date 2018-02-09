using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAni : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldAngle = transform.localEulerAngles;
		oldAngle.y = Time.timeSinceLevelLoad * 45.0f;
		transform.localEulerAngles = oldAngle;
	}
}
