using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class QuestNode : MonoBehaviour
{
    [SerializeField]
    protected GameObject questGiver;
    [SerializeField]
    protected GameObject questTarget;

    [SerializeField]
    protected int questProgress;

    [SerializeField]
    protected GameObject otherQuest;

    private string questName;

    protected int questCounter;

    public bool isActive;

    public bool isInProgress;

    public bool isCompleted;

    protected QuestNode parentNode;

    protected QuestNode childNode;

    public QuestNode() { }

    public QuestNode(GameObject target)
    {
        questTarget = target;
    }

    private void Start()
    {

    }

    public virtual void Init()
    {
        if (otherQuest.GetComponent<QuestNode>())
            SetNextNode(otherQuest.GetComponent<QuestNode>());
    }

    public string GetQuestName()
    {
        return questName;
    }

    public void SetNextNode(QuestNode node)
    {
        childNode = node;
    }

    public QuestNode GetNextNode()
    {
        return childNode;
    }

    private void SetParentNode(QuestNode node)
    {
        parentNode = node;
    }

    public QuestNode GetParentNode()
    {
        return parentNode;
    }

    public virtual void CheckTarget(GameObject obj) { }

}
