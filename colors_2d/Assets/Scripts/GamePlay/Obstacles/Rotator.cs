using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    [SerializeField] float rotation_speed = 100f;
    [SerializeField] int rotationDirection;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate each frame:
        transform.Rotate(0f, 0f, rotationDirection * rotation_speed * Time.deltaTime);
	}
}
