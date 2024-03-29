﻿using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {
    
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public float CameraPosY;
    // Update is called once per frame
    void LateUpdate () 
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, CameraPosY, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "EndLevel")
		{
			target = null;
			transform.position = new Vector3(transform.position.x, 4.485f, transform.position.z);
		}
	}

}