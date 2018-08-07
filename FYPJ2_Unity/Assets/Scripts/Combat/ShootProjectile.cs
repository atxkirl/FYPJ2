using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
	//Public variables
	public GameObject controllingObject;//Controlling object
	public GameObject projectile;       //Projectile
	public AudioClip shootSound;        //Audio file
	public int maxRounds = 100;         //Max number of rounds
	public int currRounds = 100;        //Curr number of rounds
	public int fireRate = 600;			//Rounds Per Minute
	public List<FireMode> fireModeList; //List of firemodes
	public enum FireMode
	{
		FT_SEMI,
		FT_BURST,
		FT_AUTO
	}

	//Sound variables
	private float lowVolume = 0.25f;
	private float highVolume = 0.75f;
  
	[SerializeField]
	private float bounceTime = 0.0f;                
	[SerializeField]
	private float elapsedTime = 0.0f;
	[SerializeField]
	private int bulletsToFire = 0;
	[SerializeField]
	private FireMode fireMode = FireMode.FT_AUTO;   

	//Firerate map
	private readonly IDictionary FireModesMap = new Dictionary<FireMode, FireMode>();

	// Use this for initialization
	private void Awake()
	{
		//Resize fireModeList if inspector input too large (max. size 3)
		if (fireModeList.Count > 3)
			fireModeList.RemoveRange(3, fireModeList.Count - 3);

		//Assign firemodes to map
		for (int i = 0; i < fireModeList.Count - 1; ++i)
		{
			FireModesMap.Add(fireModeList[i], fireModeList[i + 1]);
		}

		if (FireModesMap.Contains(fireModeList[0]))
		{
			FireModesMap.Add(fireModeList[fireModeList.Count - 1], fireModeList[0]);
		}

		//Assign first firemode
		fireMode = fireModeList[0];

		//Assign bullet count according to firemodes available
		switch (fireMode)
		{
			case FireMode.FT_SEMI:
				bulletsToFire = 1;
				break;
			case FireMode.FT_BURST:
				bulletsToFire = 3;
				break;
		}
	}

	// Updates every frame
	public void Update()
	{
		elapsedTime += Time.deltaTime;
	}

	// Creates projectile
	private void CreateProjectile()
	{
		//Set owner of projectile to be owner of the firearm so as to not shoot yourself in the foot.
		GameObject bullet = Instantiate(projectile);
		if(bullet != null && bullet.GetComponent<Bullet>())
		{
			bullet.GetComponent<Bullet>().owner = controllingObject;
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;
			bullet.transform.forward = transform.forward;
		}
		//Decrease number of bullets left
		if (currRounds != -1)
			--currRounds;
	}

	// Fires weapon
	public void FireWeapon()
	{
		//If infinite ammo then dont skip
		if (currRounds != -1)
		{
			//If no more bullets left then skip
			if (currRounds <= 0)
			{
				currRounds = 0;
				return;
			}
		}

		//If enough time has passed then fire again
		if (bounceTime <= elapsedTime)
		{
			//Auto fire
			if (fireMode == FireMode.FT_AUTO)
			{
				//Play sfx
				float volume = Random.Range(lowVolume, highVolume);
				SoundManager.Instance.PlayOnce(shootSound, volume);
				//Create projectile
				CreateProjectile();
			}
			//Semi and Burst fire
			else if (bulletsToFire > 0)
			{
				//Play sfx
				float volume = Random.Range(lowVolume, highVolume);
				SoundManager.Instance.PlayOnce(shootSound, volume);
				//Create projectile
				CreateProjectile();
				//Decrease number of bullets left in volley
				--bulletsToFire;
			}

			//Delay for firerate if not semi auto
			if (fireMode != FireMode.FT_SEMI)
			{
				bounceTime = elapsedTime + (60.0f / fireRate);
			}
		}
	}

	// Reset firemode
	public void ResetWeapon()
	{
		switch (fireMode)
		{
			case FireMode.FT_SEMI:
				bulletsToFire = 1;
				break;
			case FireMode.FT_BURST:
				bulletsToFire = 3;
				break;
		}
	}

	// Change firemode
	public void ChangeFiretype()
	{
		if(fireModeList.Count > 1)
		{
			fireMode = (FireMode)FireModesMap[fireMode];
			ResetWeapon();
		}
	}

	// Add ammo
	public void ModifyAmmo(int _ammo)
	{
		currRounds += _ammo;
		if (currRounds > maxRounds)
			currRounds = maxRounds;
		else if (currRounds <= 0)
			currRounds = 0;
	}
}
