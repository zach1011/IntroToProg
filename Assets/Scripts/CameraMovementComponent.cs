using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementComponent : MonoBehaviour
{
    //create an offset for it to always stay behind
    public Vector3 Offset;

    //speed for the camera to move smoothly
    public float SpeedDamp = 2.0f;

    //create an object we want to focus on
    public GameObject CameraFocus;


	// Use this for initialization
	void Start ()
    {

        Offset = transform.position - CameraFocus.transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 NewLocation = CameraFocus.transform.position + Offset;


        transform.position = Vector3.Lerp(transform.position, NewLocation, SpeedDamp * Time.deltaTime); 
        //take the camera and set it on the player character
                                                             //make sure to stay on top of the player


	}
}
