﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	private Vector3 cameraPosition;

	public float m_speed = 0.1f;
	Camera mycam;

	// Use this for initialization
	void Start () {
		mycam = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void Update () {

		mycam.orthographicSize = (Screen.height / 100f) / 2.5f;

		if (target) {
			cameraPosition = Vector3.Lerp (cameraPosition, target.position, m_speed) + new Vector3 (0, 0, -10);
			transform.position = new Vector3 (cameraPosition.x,cameraPosition.y, cameraPosition.z);

		}


	}
}

