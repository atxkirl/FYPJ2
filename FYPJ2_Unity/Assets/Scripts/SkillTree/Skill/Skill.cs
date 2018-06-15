[System.Serializable]
public class Skill
{
    public int ID;
    public int[] dependentSkills;
    public int cost;
    public bool isUnlocked;
}
