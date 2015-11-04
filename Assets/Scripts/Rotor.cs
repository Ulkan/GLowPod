using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour 
{
	public float rotateSpeed;
	public float accel;
	public float maxSpeed;
	float actualSpeed;

	// Use this for initialization
	void Start () 
	{
		actualSpeed = rotateSpeed;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Rotate ( new Vector3 ( actualSpeed * Time.deltaTime,0,0));

		if(Input.GetAxis("Horizontal") != 0f)
		{
			transform.Rotate ( new Vector3 ( 0,actualSpeed * Time.deltaTime * Input.GetAxis("Horizontal") * -1f ,0));
		}
		if(Input.GetAxis("Vertical") != 0f)
		{
			actualSpeed += Input.GetAxis("Vertical") * accel * Time.deltaTime;
			if ( actualSpeed <= 0f)
			{
				actualSpeed = 0f;
			}
			if ( actualSpeed >= maxSpeed )
			{
				actualSpeed = maxSpeed;
			}
		}
	}
}
