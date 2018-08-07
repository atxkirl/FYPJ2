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
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != owner && other.gameObject.tag != owner.tag)
		{
			//Deal Damage
			//Check if colliding object has HealthBase script attached
			if (other.gameObject.GetComponent<HealthBase>())
			{
				int resultDamage = damage;

				//See if need to take into account colliding object's defence
				if (other.gameObject.GetComponent<DefenceBase>())
				{
					//Calculate final attack damage, taking into account opponent's defence - if any
					resultDamage = damage - other.gameObject.GetComponent<DefenceBase>().GetCurrentDefence();

					//Make sure damage done does not end up increasing opponent's health
					if (resultDamage < 0)
						resultDamage = 0;

					other.gameObject.GetComponent<HealthBase>().ModifyCurrentHealth(-resultDamage);
				}
				//Colliding object does not have defence stat so just deal raw damage
				else
				{
					//Make sure damage done does not end up increasing opponent's health
					if (resultDamage < 0)
						resultDamage = 0;

					other.gameObject.GetComponent<HealthBase>().ModifyCurrentHealth(-resultDamage);
				}
			}

			//Destroy projectile
			DestroyBullet();
		}
	}

	void DestroyBullet()
	{
		//this.gameObject.SetActive(false);
		Destroy(this.gameObject);
	}
}
