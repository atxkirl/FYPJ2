[System.Serializable]
public class PlayerAttributes
{
	public Attributes attribute;
	public int amount;

	public PlayerAttributes(Attributes _attribute, int _amount)
	{
		attribute = _attribute;
		amount = _amount;
	}
}
