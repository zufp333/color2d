using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] Transform player_;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Incase the player had passed the current camera location,
        // update the camera's location:

        if (player_.position.y > transform.position.y)
            transform.position = new Vector3(transform.position.x, player_.position.y, transform.position.z);
    }
}
