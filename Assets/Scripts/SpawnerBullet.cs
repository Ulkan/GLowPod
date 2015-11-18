using UnityEngine;
using System.Collections;

public class SpawnerBullet : MonoBehaviour 
{
	public GameObject normalCrystal;
	public GameObject lightBlue;
	public GameObject lightOrange;
	public GameObject lightPurple;
	public float speed;
	public bool isSpecial = false;

	public string light;
	Ray ray;
	public float colliderSize;
	bool toDestroy;
	public float destroyTime;
	float destroyTimer;

	GameObject previousLight;
	GameObject toSpawn;

	// Use this for initialization
	void Start () 
	{
		toDestroy = false;
		if(isSpecial)
		{
			switch(light)
			{
			case "Blue" :
				previousLight = GameObject.Find ("CrystalGlowBlue(Clone)");
				toSpawn = lightBlue;
				break;
			case "Orange" :
				previousLight = GameObject.Find ("CrystalGlowOrange(Clone)");
				toSpawn = lightOrange;
				break;
			case "Purple" : 
				previousLight = GameObject.Find ("CrystalGlowPurple(Clone)");
				toSpawn = lightPurple;
				break;
			}

		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		RaycastHit hit;
		if(Physics.Raycast (transform.position, transform.forward, out hit, colliderSize) && !toDestroy)
		{

			if ( hit.collider.gameObject.tag == "Ground")
			{
				if(isSpecial)
				{
					if(previousLight == null)
					{
						previousLight = Instantiate(toSpawn, transform.position + transform.up * 5, transform.rotation) as GameObject;
					}
					else 
					{
						previousLight.transform.position = transform.position + transform.up * 5;
					}
				}
				else 
				{
					Instantiate(normalCrystal, transform.position, transform.rotation);
				}

				toDestroy = true;
			}


		}
		if (!toDestroy) 
		{
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		else
		{
			destroyTimer += Time.deltaTime;
			if(destroyTimer >= destroyTime)
			{
				Destroy (this.gameObject);
			}
		}
	}
	
}
