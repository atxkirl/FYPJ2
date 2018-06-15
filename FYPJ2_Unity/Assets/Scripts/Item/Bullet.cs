using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject owner;
	public int damage;
	public float speed;
	public float lifetime;

	void OnEnable()
	{
		Invoke("DestroyBullet", lifetime);
	}

	void OnDisable()
	{
		CancelInvoke();
	}

	void Update()
	{
		//Update projectile position
		transform.position += transform.forward * speed * Time.deltaTime;

		//Raycast to check collision
		RaycastHit hit;
		Ray ray = new Ray(transform.position + transform.forward * GetComponent<SphereCollider>().radius, transform.forward);

		if (Physics.Raycast(ray, out hit, speed * Time.deltaTime))
		{
			if (hit.transform.gameObject != owner)
			{
				DestroyBullet();
				return;
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag.Equals("Player"))
		{
			Player.Instance.ModifyHealthPoints(damage);
		}
		if (other.gameObject != owner)
		{
			//Destroy projectile
			DestroyBullet();
		}
	}

	void DestroyBullet()
	{
		this.gameObject.SetActive(false);
	}
}
