using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SkillTreeReader : SingletonHelper<SkillTreeReader>
{
    // Array with all the skills in our skilltree
    private Skill[] skillTree;

    // Dictionary with the skills in our skilltree
    private Dictionary<int, Skill> skillDict;

    // Variable for caching the currently being inspected skill
    private Skill skillInspected;

	public List<Skill> skillTreePublic = new List<Skill>();

    void Awake()
    {
		Instance.CreateReference();
		DontDestroyOnLoad(this.gameObject);
		SetUpSkillTree();
	}

	void Update()
	{
		skillTreePublic = skillTree.ToList();
	}

	// Use this for initialization of the skill tree
	void SetUpSkillTree ()
    {
        skillDict = new Dictionary<int, Skill>();

        LoadSkillTree();
	}
	
    public void LoadSkillTree()
    {
        string path = "Assets/Scripts/SkillTree/Data/skilltree.json";
        string dataAsJson;
        if (File.Exists(path))
        {
            // Read the json from the file into a string
            dataAsJson = File.ReadAllText(path);

            // Pass the json to JsonUtility, and tell it to create a SkillTree object from it
            SkillTree loadedData = JsonUtility.FromJson<SkillTree>(dataAsJson);

            // Store the SkillTree as an array of Skill
            skillTree = new Skill[loadedData.skillList.Length];
			skillTree = loadedData.skillList;

            // Populate a dictionary with the skill id and the skill data itself
            for (int i = 0; i < skillTree.Length; ++i)
            {
                skillDict.Add(skillTree[i].ID, skillTree[i]);
            }
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }        
    }

    public bool IsSkillUnlocked(int skillID)
    {
        if (skillDict.TryGetValue(skillID, out skillInspected))
        {
            return skillInspected.isUnlocked;
        }
        else
        {
            return false;
        }
    }

    public bool CanSkillBeUnlocked(int skillID)
    {
        bool canUnlock = true;
        if(skillDict.TryGetValue(skillID, out skillInspected)) // The skill exists
        {
            if(skillInspected.cost <= Player.Instance.playerSkillPoints) // Enough points available
            {
                int[] dependencies = skillInspected.dependentSkills;
                for (int i = 0; i < dependencies.Length; ++i)
                {
                    if (skillDict.TryGetValue(dependencies[i], out skillInspected))
                    {
                        if (!skillInspected.isUnlocked)
                        {
                            canUnlock = false;
                            break;
                        }
                    }
                    else // If one of the dependencies doesn't exist, the skill can't be unlocked.
                    {
                        return false;
                    }
                }
            }
            else // If the player doesn't have enough skill points, can't unlock the new skill
            {
                return false;
            }
            
        }
        else // If the skill id doesn't exist, the skill can't be unlocked
        {
            return false;
        }
        return canUnlock;
    }

    public bool UnlockSkill(int skillID)
    {
        if(skillDict.TryGetValue(skillID, out skillInspected))
        {
            if (skillInspected.cost <= Player.Instance.playerSkillPoints)
            {
				Player.Instance.playerSkillPoints -= skillInspected.cost;
				skillInspected.isUnlocked = true;

				// We replace the entry on the dictionary with the new one (already unlocked)
				skillDict.Remove(skillID);
				skillDict.Add(skillID, skillInspected);

                return true;
            }
            else
            {
                return false;   // The skill can't be unlocked. Not enough points
            }
        }
        else
        {
            return false;   // The skill doesn't exist
        }
    }
}
