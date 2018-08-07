using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBox : MonoBehaviour
{
	public GameObject controllingObject;
	[SerializeField]
	private GameObject collidingObject;
	[SerializeField]
	private int attackDamage;

	private void Start()
	{
		if(controllingObject.GetComponent<AttackBase>())
		{
			attackDamage = controllingObject.GetComponent<AttackBase>().GetCurrentAttack();
		}
	}

	private void Update()
	{
		if (controllingObject.GetComponent<AttackBase>())
		{
			attackDamage = controllingObject.GetComponent<AttackBase>().GetCurrentAttack();
		}

		if(Input.GetButtonDown("FirePrimary"))
		{
			//MeleeOnce();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != controllingObject)
		{
			if (other.CompareTag("Enemy"))
			{
				collidingObject = other.gameObject;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject != controllingObject)
		{
			if (other.CompareTag("Enemy"))
			{
				collidingObject = other.gameObject;
			}
		}
	}

	public void MeleeOnce()
	{
		if (collidingObject != null && collidingObject.CompareTag("Enemy"))
		{
			//Check if colliding object has HealthBase script attached
			if (collidingObject.GetComponent<HealthBase>())
			{
				int resultDamage = attackDamage;

				//See if need to take into account colliding object's defence
				if (collidingObject.GetComponent<DefenceBase>())
				{
					//Calculate final attack damage, taking into account opponent's defence - if any
					resultDamage = attackDamage - collidingObject.GetComponent<DefenceBase>().GetCurrentDefence();

					//Make sure damage done does not end up increasing opponent's health
					if (resultDamage < 0)
						resultDamage = 0;

					collidingObject.GetComponent<HealthBase>().ModifyCurrentHealth(-resultDamage);
				}
				//Colliding object does not have defence stat so just deal raw damage
				else
				{
					//Make sure damage done does not end up increasing opponent's health
					if (resultDamage < 0)
						resultDamage = 0;

					collidingObject.GetComponent<HealthBase>().ModifyCurrentHealth(-resultDamage);
				}
			}
		}
	}
}
