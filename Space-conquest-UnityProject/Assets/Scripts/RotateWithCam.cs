using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Debug.Log(this.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 gazeDirection = Camera.main.transform.forward;

        this.transform.rotation = Quaternion.LookRotation(gazeDirection);
        Debug.Log(this.transform.rotation);
    }
}
