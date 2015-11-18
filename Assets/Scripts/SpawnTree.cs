using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SpawnTree : MonoBehaviour 
{

	public GameObject spawner;
	public GameObject spawnerSpecial;

	public float reloadTime;
	float timer;
	bool canShoot;
	public AudioClip shotSound;
	AudioSource audio;

	public string lightColors;
	


	// Use this for initialization
	void Start () 
	{
		lightColors = "Blue";
		canShoot = true;
		Cursor.visible = false;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (Input.GetMouseButton(0) && canShoot)
		{
			Instantiate(spawner,transform.position, transform.rotation);
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
		if(Input.GetMouseButtonDown(1))
		{
			switch(lightColors)
			{
			case "Blue" :
				GameObject specialShotBlue = Instantiate(spawnerSpecial,transform.position, transform.rotation) as GameObject;
				specialShotBlue.GetComponent<SpawnerBullet>().light = "Blue";
				canShoot = false;
				break;
			case "Orange" :
				GameObject specialShotOrange = Instantiate(spawnerSpecial,transform.position, transform.rotation) as GameObject;
				specialShotOrange.GetComponent<SpawnerBullet>().light = "Orange";
				canShoot = false;
				break;
			case "Purple" : 
				GameObject specialShotPurple = Instantiate(spawnerSpecial,transform.position, transform.rotation) as GameObject;
				specialShotPurple.GetComponent<SpawnerBullet>().light = "Purple";
				canShoot = false;
				break;
			}

			
			audio.PlayOneShot(shotSound);
		}
	}
}
