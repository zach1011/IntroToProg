using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent : MonoBehaviour {

    public GunComponent CurrentGun;
	// Use this for initialization
	void Start () {
		
	}
	
    public void UpdateInput()
    {
        if (Input.GetButton("Fire1") && CurrentGun != null) CurrentGun.Fire(); //call the current gun's fire function. (left mouse button)

    }

	// Update is called once per frame
	void Update ()
    {
        UpdateInput();	
	}
}
