using UnityEngine;
using System.Collections;

public class SpawnerBullet : MonoBehaviour 
{
	public GameObject waterSpawn;
	public GameObject groundSpawn;
	public float speed;
	Ray ray;
	public float colliderSize;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		RaycastHit hit;
		if(Physics.Raycast (transform.position, transform.forward, out hit, colliderSize))
		{
			if(hit.collider.gameObject.tag == "Water")
			{
				//Debug.Log("Colliding with Water");
				GameObject aquaStuff = Instantiate(waterSpawn, transform.position, transform.rotation) as GameObject;
				Vector3 toMid = Vector3.zero - aquaStuff.transform.position;
				toMid = toMid.normalized;
				aquaStuff.transform.up = toMid;
				Destroy (this.gameObject);
			}
			else if ( hit.collider.gameObject.tag == "Ground")
			{
				//Debug.Log("Colliding with Ground");
				GameObject groundStuff = Instantiate(groundSpawn, transform.position, transform.rotation) as GameObject;
				Vector3 toMiddle = Vector3.zero - groundStuff.transform.position;
				toMiddle = toMiddle.normalized;
				groundStuff.transform.forward = toMiddle;
				Destroy (this.gameObject);
			}


		}
		transform.position += transform.forward * Time.deltaTime * speed;
	}

	void OnCollisionEnter ( Collision other )
	{
		/*
		if ( other.gameObject.tag == "Water")
		{
			Debug.Log("Colliding with Water");
			GameObject aquaStuff = Instantiate(waterSpawn, transform.position, transform.rotation) as GameObject;
			Vector3 toMid = Vector3.zero - aquaStuff.transform.position;
			toMid = toMid.normalized;
			aquaStuff.transform.up = toMid;
			Destroy (this.gameObject);
		}
		else if ( other.gameObject.tag == "Ground")
		{
			Debug.Log("Colliding with Ground");
			GameObject groundStuff = Instantiate(groundSpawn, transform.position, transform.rotation) as GameObject;
			Vector3 toMiddle = Vector3.zero - groundStuff.transform.position;
			toMiddle = toMiddle.normalized;
			groundStuff.transform.forward = toMiddle;
			Destroy (this.gameObject);
		}
		*/
	}
}
