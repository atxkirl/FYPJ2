[System.Serializable]
public class PlayerAttributes
{
	public Attributes attribute;
	public int amount;

	public PlayerAttributes(Attributes newAttribute, int newAmount)
	{
		attribute = newAttribute;
		amount = newAmount;
	}
}
