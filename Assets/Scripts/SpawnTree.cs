using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SpawnTree : MonoBehaviour 
{

	public GameObject spawner;
	public float reloadTime;
	float timer;
	bool canShoot;
	public AudioClip shotSound;
	AudioSource audio;

	// Use this for initialization
	void Start () 
	{
		canShoot = true;
		Cursor.visible = false;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0) && canShoot)
		{
			GameObject spawnerBullet = Instantiate(spawner,transform.position, transform.rotation) as GameObject;
			canShoot = false;

			audio.PlayOneShot(shotSound);
		}

		if(canShoot == false)
		{
			timer += Time.deltaTime;
			if(timer >= reloadTime)
			{
				timer = 0f;
				canShoot = true;
			}
		}
	}
}
