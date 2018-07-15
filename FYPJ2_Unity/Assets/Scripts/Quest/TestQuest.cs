using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest : QuestNode {

    [SerializeField]
    GameObject test;

    public override void CheckTarget(GameObject obj)
    {
        if (obj.CompareTag(questTarget.tag))
            questCounter++;

        if (questProgress <= questCounter)
        {
            isCompleted = true;
            QuestSystem.instance.ProgressQuest();
        }
    }

    // Use this for initialization
    void Start () {
        base.Init();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M))
        {
            CheckTarget(test);
        }
	}
}
