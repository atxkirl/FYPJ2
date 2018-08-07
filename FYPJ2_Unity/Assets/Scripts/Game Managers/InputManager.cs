using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMono<InputManager>
{
	public GameObject playerInventory = null;
	public GameObject otherInventory = null;
	public GameObject skillTree = null;
	public GameObject playerHand = null;

	private void Update()
	{
		//Toggle Inventory
		if (Input.GetButtonDown("ToggleInventory"))
		{
			if (playerInventory != null)
			{
				playerInventory.GetComponent<InventoryListControl>().Toggle();
				skillTree.GetComponent<Toggleable>().Toggle(false);
				ToolTip.Instance.ExitHover();
			}
		}
		//Toggle SkillTree
		if (Input.GetButtonDown("ToggleSkills"))
		{
			if (skillTree != null)
			{
				skillTree.GetComponent<Toggleable>().Toggle();
				playerInventory.GetComponent<InventoryListControl>().Toggle(false);
				ToolTip.Instance.ExitHover();
			}
		}

		//Removing Item
		if (Input.GetButtonDown("RemoveItem"))
		{
			if (playerInventory != null)
			{
				if (ItemHolder.Instance.itemToPreview)
				{
					playerInventory.GetComponent<PlayerInventory>().RemoveItem(ItemHolder.Instance.itemToPreview);
				}
			}
		}
		//Equip/UnEquip Item
		if (Input.GetButtonDown("EquipItem") || Input.GetButtonDown("UnEquipItem"))
		{
			if (playerInventory != null)
			{
				if (ItemHolder.Instance.itemToPreview)
				{
					if (ItemHolder.Instance.itemToPreview.GetComponent<Item>().itemEquipped)
					{
						playerInventory.GetComponent<PlayerInventory>().UnEquipItem(ItemHolder.Instance.itemToPreview);
					}
					else if (!ItemHolder.Instance.itemToPreview.GetComponent<Item>().itemEquipped)
					{
						playerInventory.GetComponent<PlayerInventory>().EquipItem(ItemHolder.Instance.itemToPreview);
					}
				}
			}
		}

		//Fire Weapon
		if(Input.GetButton("FirePrimary"))
		{
			if(playerHand != null && Player.Instance.playerWeapon != null)
			{
				//Check if weapon is projectile or melee
				if(Player.Instance.playerWeapon.GetComponent<ShootProjectile>())
				{
					Player.Instance.playerWeapon.GetComponent<ShootProjectile>().FireWeapon();
				}
				//Weapon is a melee weapon
				else if(Player.Instance.playerWeapon.GetComponent<Melee>())
				{
					Player.Instance.playerMeleeBox.GetComponent<MeleeBox>().MeleeOnce();	
				}
			}
		}
		if (Input.GetButtonUp("FirePrimary"))
		{
			if (playerHand != null && Player.Instance.playerWeapon != null)
			{
				if (Player.Instance.playerWeapon.GetComponent<ShootProjectile>())
				{
					Player.Instance.playerWeapon.GetComponent<ShootProjectile>().ResetWeapon();
				}
			}
		}
		if(Input.GetButtonDown("ChangeFiremode"))
		{
			if (playerHand != null && Player.Instance.playerWeapon != null)
			{
				if (Player.Instance.playerWeapon.GetComponent<ShootProjectile>())
				{
					Player.Instance.playerWeapon.GetComponent<ShootProjectile>().ChangeFiretype();
				}
			}
		}
	}
}
