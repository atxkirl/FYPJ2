using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour {

    public static QuestSystem instance;

    [SerializeField]
    GameObject curGameObjectA;

    [SerializeField]
    GameObject curGameObjectB;

    [SerializeField]
    QuestNode curQuestA;

    [SerializeField]
    QuestNode curQuestB;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this then destroy
        else if (instance != this)
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        if (curGameObjectA.GetComponent<QuestNode>())
            curQuestA = curGameObjectA.GetComponent<QuestNode>();

        if (curGameObjectB.GetComponent<QuestNode>())
            curQuestB = curGameObjectB.GetComponent<QuestNode>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ProgressQuest()
    {

        if (curQuestA.isCompleted && curQuestA.GetNextNode())
            curQuestA = curQuestA.GetNextNode();

        if (curQuestA == curQuestB)
            return;

        if (curQuestB.isCompleted && curQuestB.GetNextNode())
            curQuestB = curQuestB.GetNextNode();
    }

    public void UpdateQuest(GameObject obj)
    {
        if (curQuestA.isInProgress)
            curQuestA.CheckTarget(obj);

        if (curQuestA == curQuestB)
            return;

        if (curQuestB.isInProgress)
            curQuestB.CheckTarget(obj);
    }
}
