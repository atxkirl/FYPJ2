using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
	public InventoryListControl playerInventory = null;
	public InventoryListControl otherInventory = null;
}
