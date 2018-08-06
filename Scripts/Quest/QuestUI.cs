using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour {

    public GameObject availableContent;
    public GameObject progressContent;
    public GameObject completedContent;

    private Dictionary<string, GameObject> availableButtonList;
    private Dictionary<string, GameObject> progressButtonList;
    private Dictionary<string, GameObject> completedButtonList;

    private Dictionary<string, int> questList;

    const float topPos = 130.0f;
    const float xPos = 10.0f;
    Vector2 buttonSize = new Vector2(270, 30);

    [SerializeField]
    private Transform test;
	// Use this for initialization
	void Start () {
        test = this.transform.GetChild(1);

        availableButtonList = new Dictionary<string, GameObject>();
        progressButtonList = new Dictionary<string, GameObject>();
        completedButtonList = new Dictionary<string, GameObject>();

        questList = new Dictionary<string, int>();

        QuestNode questA = QuestSystem.instance.GetQuestA().GetComponent<QuestNode>();
        QuestNode questB = QuestSystem.instance.GetQuestA().GetComponent<QuestNode>();
        do
        {
            if (questA != null)
            {
                if (questA.isCompleted)
                {
                    Vector3 pos = new Vector3(xPos, topPos - completedButtonList.Count * 30.0f, 0);
                    GameObject obj = Instantiate(Resources.Load("QuestButton"), completedContent.transform, false) as GameObject;
                    obj.GetComponent<RectTransform>().sizeDelta = buttonSize;
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                    completedButtonList.Add(questA.GetQuestName(), obj);
                    questList.Add(questA.GetQuestName(), 1);
                    obj.GetComponent<QuestButton>().SetQuestNode(questA);
                    SetQuestButton(obj);
                }
                else if (questA.isInProgress)
                {
                    Vector3 pos = new Vector3(xPos, topPos - progressButtonList.Count * 30.0f, 0);
                    GameObject obj = Instantiate(Resources.Load("QuestButton"), progressContent.transform, false) as GameObject;
                    obj.GetComponent<RectTransform>().sizeDelta = buttonSize;
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                    progressButtonList.Add(questA.GetQuestName(), obj);
                    questList.Add(questA.GetQuestName(), 2);
                    obj.GetComponent<QuestButton>().SetQuestNode(questA);
                    SetQuestButton(obj);
                }
                else if (questA.GetParentNode() == null || questA.GetParentNode().isCompleted)
                {
                    Vector3 pos = new Vector3(xPos, topPos - availableButtonList.Count * 30.0f, 0);
                    GameObject obj = Instantiate(Resources.Load("QuestButton"), availableContent.transform, false) as GameObject;
                    obj.GetComponent<QuestButton>().SetQuestNode(questA);
                    obj.GetComponent<RectTransform>().sizeDelta = buttonSize;
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                    availableButtonList.Add(questA.GetQuestName(), obj);
                    questList.Add(questA.GetQuestName(), 3);
                    SetQuestButton(obj);
                }

                questA = questA.GetNextNode();
            }

            if (QuestSystem.instance.GetSameQuest())
                questB = questB.GetNextNode();

            if (questB != null && !QuestSystem.instance.GetSameQuest())
            {
                if (questB.isCompleted)
                {
                    Vector3 pos = new Vector3(xPos, topPos - completedButtonList.Count * 30.0f, 0);
                    GameObject obj = Instantiate(Resources.Load("QuestButton"), completedContent.transform, false) as GameObject;
                    obj.GetComponent<RectTransform>().sizeDelta = buttonSize;
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                    completedButtonList.Add(questB.GetQuestName(), obj);
                    questList.Add(questB.GetQuestName(), 1);
                    obj.GetComponent<QuestButton>().SetQuestNode(questB);
                    SetQuestButton(obj);
                }
                else if (questB.isInProgress)
                {
                    Vector3 pos = new Vector3(xPos, topPos - progressButtonList.Count * 30.0f, 0);
                    GameObject obj = Instantiate(Resources.Load("QuestButton"), progressContent.transform, false) as GameObject;
                    obj.GetComponent<RectTransform>().sizeDelta = buttonSize;
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                    progressButtonList.Add(questB.GetQuestName(), obj);
                    questList.Add(questB.GetQuestName(), 2);
                    obj.GetComponent<QuestButton>().SetQuestNode(questB);
                    SetQuestButton(obj);
                }
                else if (questB.GetParentNode() == null || questB.GetParentNode().isCompleted)
                {
                    Vector3 pos = new Vector3(xPos, topPos - availableButtonList.Count * 30.0f, 0);
                    GameObject obj = Instantiate(Resources.Load("QuestButton"), availableContent.transform, false) as GameObject;
                    obj.GetComponent<RectTransform>().sizeDelta = buttonSize;
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                    availableButtonList.Add(questB.GetQuestName(), obj);
                    questList.Add(questB.GetQuestName(), 3);
                    obj.GetComponent<QuestButton>().SetQuestNode(questB);
                    SetQuestButton(obj);
                }

                questB = questB.GetNextNode();
            }

        } while (questA != null || questB != null);
    }

    // Update is called once per frame
    void Update () {

	}

    private void SetQuestButton(GameObject button)
    {
        button.GetComponent<QuestButton>().SetNameText(test.GetChild(0).GetComponent<Text>());
        button.GetComponent<QuestButton>().SetDescriptionText(test.GetChild(1).GetComponent<Text>());
        button.GetComponent<QuestButton>().SetProgressText(test.GetChild(2).GetComponent<Text>());
    }

    public void UpdateQuest(QuestNode updateQuest)
    {
        if (questList.ContainsKey(updateQuest.GetQuestName()))
        {
            GameObject obj;
            Dictionary<string, GameObject>.ValueCollection value;
            int count = 0;
            switch (questList[updateQuest.GetQuestName()])
            {
                case 1:
                    break;
                case 2:
                    obj = progressButtonList[updateQuest.GetQuestName()];
                    obj.transform.SetParent(completedContent.transform, false);
                    progressButtonList.Remove(updateQuest.GetQuestName());
                    completedButtonList.Add(updateQuest.GetQuestName(), obj);
                    questList[updateQuest.GetQuestName()] = 1;

                    value = progressButtonList.Values;
                    foreach (GameObject other in value)
                    {
                        other.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, topPos - count++ * 30.0f);
                    }

                    count = 0;
                    value = completedButtonList.Values;
                    foreach (GameObject other in value)
                    {
                        other.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, topPos - count++ * 30.0f);
                    }

                    break;
                case 3:
                    obj = availableButtonList[updateQuest.GetQuestName()];
                    obj.transform.SetParent(progressContent.transform, false);
                    availableButtonList.Remove(updateQuest.GetQuestName());
                    progressButtonList.Add(updateQuest.GetQuestName(), obj);
                    questList[updateQuest.GetQuestName()] = 2;

                    value = availableButtonList.Values;
                    foreach (GameObject other in value)
                    {
                        other.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, topPos - count++ * 30.0f);
                    }

                    count = 0;
                    value = progressButtonList.Values;
                    foreach (GameObject other in value)
                    {
                        other.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, topPos - count++ * 30.0f);
                    }
                    break;
            }
        }
        else
        {
            Vector3 pos = new Vector3(xPos, topPos - availableButtonList.Count * 30.0f, 0);
            GameObject obj = Instantiate(Resources.Load("QuestButton"), availableContent.transform, false) as GameObject;
            obj.GetComponent<RectTransform>().sizeDelta = buttonSize;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
            availableButtonList.Add(updateQuest.GetQuestName(), obj);
            questList.Add(updateQuest.GetQuestName(), 3);
            obj.GetComponent<QuestButton>().SetQuestNode(updateQuest);
            SetQuestButton(obj);
        }
    }
}
