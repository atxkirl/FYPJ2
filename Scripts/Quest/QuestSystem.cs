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

    private bool sameQuest;

    public QuestUI questUI;

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

        if (curQuestA == curQuestB)
            sameQuest = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ProgressQuest()
    {
        if (curQuestA.isCompleted && curQuestA.GetNextNode())
        {
            questUI.UpdateQuest(curQuestA);
            curQuestA = curQuestA.GetNextNode();
            questUI.UpdateQuest(curQuestA);
        }

        if (sameQuest)
        {
            curQuestB = curQuestA;
            return;
        }

        if (curQuestB.isCompleted && curQuestB.GetNextNode())
        {
            questUI.UpdateQuest(curQuestB);
            curQuestB = curQuestB.GetNextNode();
            questUI.UpdateQuest(curQuestB);
        }
    }

    public void UpdateQuest(GameObject obj)
    {
        if (curQuestA == curQuestB)
            sameQuest = true;
        else
            sameQuest = false;

        if (curQuestA.isInProgress)
            curQuestA.CheckTarget(obj);

        if (sameQuest)
            return;

        if (curQuestB.isInProgress)
            curQuestB.CheckTarget(obj);
    }

    public GameObject GetQuestA()
    {
        return curGameObjectA;
    }

    public GameObject GetQuestB()
    {
        return curGameObjectB;
    }

    public bool GetSameQuest()
    {
        return sameQuest;
    }

    public void StartQuest(GameObject giver)
    {
        if (giver == curQuestA.GetQuestGiver() && !curQuestA.isInProgress && !curQuestA.isCompleted)
        {
            questUI.UpdateQuest(curQuestA);
            curQuestA.isInProgress = true;
        }

        if (sameQuest)
            return;

        if (giver == curQuestB.GetQuestGiver() && !curQuestB.isInProgress && !curQuestB.isCompleted)
        {
            questUI.UpdateQuest(curQuestB);
            curQuestB.isInProgress = true;
        }

    }
}
