using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest2 : QuestNode {

    public override void CheckTarget(GameObject obj)
    {
        if (obj.CompareTag(questTarget.tag))
            questCounter++;

        if (questProgress == questCounter)
        {
            isCompleted = true;
            QuestSystem.instance.ProgressQuest();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
