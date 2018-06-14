using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SkillReader : SingletonHelper<SkillReader>
{
	//Array with all the skills within the skilltree
	private List<Skill> skillTreeList;

	//Dictionary to hold all the skills within the skilltree
	private Dictionary<int, Skill> skillDict;

	//Variable to cache the skill thats currently being inspected
	private Skill skillInspected;

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	//Initialize skill tree
	private void InitSkillTree()
	{
		skillDict = new Dictionary<int, Skill>();
		LoadSkillTree();
	}

	public void LoadSkillTree()
	{
		string filePath = "Assets/Scripts/SkillTree/Data/skilltree.json";
		string dataFromJSON;

		if(File.Exists(filePath))
		{
			//Read data from file into string
			dataFromJSON = File.ReadAllText(filePath);

			//Pass JSON data to JSONUtility and tell it to create a SkillTree object
			SkillTree loadedData = JsonUtility.FromJson<SkillTree>(dataFromJSON);

			//Store the SkillTree as a list of skills
			skillTreeList = new List<Skill>();
			skillTreeList = loadedData.skillTree;

			//Populate the dictionary with skill ID and skill data
			foreach(Skill skill in skillTreeList)
			{
				skillDict.Add(skill.skillID, skill);
			}
		}
		else
		{
			Debug.LogError("File Invalid: Cannot load skilltree data!");
		}
	}

	//Unlock a skill
	public bool UnlockSkill(int skillID)
	{
		//Check if skill exists
		if(skillDict.TryGetValue(skillID, out skillInspected))
		{
			//Check if player has enough skill points
			if(skillInspected.skillCost <= Player.Instance.playerSkillPoints)
			{
				//Update player's available skillpoints
				Player.Instance.playerSkillPoints -= skillInspected.skillCost;
				skillInspected.skillUnlocked = true;

				//Update entry within dictionary
				skillDict.Remove(skillID);
				skillDict.Add(skillID, skillInspected);

				return true;
			}
			else
			{
				//Player does not have enough points
				return false;
			}
		}

		return false;
	}

	//Check if particular skill has been unlocked
	public bool IsSkillUnlocked(int skillID)
	{
		if (skillDict.TryGetValue(skillID, out skillInspected))
			return skillInspected.skillUnlocked;

		return false;
	}

	//Check if particular skill can be unlocked, ie all dependent skills have been unlocked, and has enough skill points
	public bool IsSkillUnlockable(int skillID)
	{
		//Check if skill exists
		if(skillDict.TryGetValue(skillID, out skillInspected))
		{
			//Check if player has enough points
			if(skillInspected.skillCost <= Player.Instance.playerSkillPoints)
			{
				int[] dependencies = skillInspected.skillDependencies;
				for(int i = 0; i < dependencies.Length; ++i)
				{
					if(skillDict.TryGetValue(dependencies[i], out skillInspected))
					{
						//Return false once a dependency skill has been found that hasn't been unlocked yet
						if(!skillInspected.skillUnlocked)
						{
							return false;
						}
					}
					else
					{
						//Return false if a dependency doesn't exists, should not ever come here unless skilltree data is borked
						return false;
					}
				}
			}
			else
			{
				//Player does not have enough points
				return false;
			}
		}
		else
		{
			//Skill doesn't exists
			return false;
		}

		return true;
	}
}
