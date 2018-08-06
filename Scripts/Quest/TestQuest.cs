using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest : QuestNode {

    [SerializeField]
    GameObject test;

    // Use this for initialization
    void Start () {
        base.Init();
	}
	
	// Update is called once per frame
	void Update () {

        if (parentNode != null && !parentNode.isCompleted)
            return;

		if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isInProgress)
                QuestSystem.instance.StartQuest(questGiver);
            else
                CheckTarget(test);
        }
	}
}
