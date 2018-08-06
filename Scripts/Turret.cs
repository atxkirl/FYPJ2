using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public int firerate = 1;

	void Start()
	{
		InvokeRepeating("Fire", (float)(60.0f / firerate), (float)(60.0f / firerate));
	}

	void Fire()
	{
		GameObject bullet = this.GetComponent<ObjectPool>().GetObjectFromPool();

		if(bullet)
		{
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;
			bullet.GetComponent<Bullet>().owner = this.gameObject;
			bullet.SetActive(true);
		}
	}
}
