﻿using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour 
{
	public float desiredScale;
	public float minMax;
	public float growSpeed;
	public float rotateMax;
	float randScale;
	Vector3 actualScale;
	float randomRotateX;
	float randomRotateY;
	float randomRotateZ;

	// Use this for initialization
	void Start () 
	{

		randScale = Random.Range (desiredScale - minMax, desiredScale + minMax);
		actualScale = transform.localScale;
		randomRotateX = Random.Range (0f,rotateMax);
		randomRotateY = Random.Range (0f,rotateMax);
		randomRotateZ = Random.Range (0f,rotateMax);
		//transform.position = transform.position - transform.forward * 0.5f;

	}

	// Update is called once per frame
	void Update () 
	{
		if(actualScale.x < randScale)
		{
			actualScale.x += growSpeed * Time.deltaTime;
			actualScale.y += growSpeed * Time.deltaTime;
			actualScale.z += growSpeed * Time.deltaTime;
			transform.Rotate (randomRotateX,randomRotateY,randomRotateZ);
		}
		else 
		{
			actualScale.x = randScale;
			actualScale.y = randScale;
			actualScale.z = randScale;
		}

		transform.localScale = actualScale;
	}
}
