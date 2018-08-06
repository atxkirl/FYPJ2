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

    [SerializeField]
    protected string questDescription;

    [SerializeField]
    protected string questObjective;

    [SerializeField]
    private string questName;

    protected int questCounter;

    public bool isInProgress;

    public bool isCompleted;

    [SerializeField]
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

    public string GetQuestDescription()
    {
        return questDescription;
    }

    public string GetQuestProgress()
    {
        return questObjective + ": " + questCounter.ToString() + "/" + questProgress.ToString();
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

    public virtual void CheckTarget(GameObject obj)
    {
        if (obj.CompareTag(questTarget.tag))
            questCounter++;

        if (questProgress <= questCounter)
        {
            isCompleted = true;
            QuestSystem.instance.ProgressQuest();
        }
    }

    public GameObject GetQuestGiver()
    {
        return questGiver;
    }

}
