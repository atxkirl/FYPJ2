using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour {

    [SerializeField]
    private QuestNode questNode;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Text progressText;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(onQuestButtonClicked);
    }

    // Update is called once per frame
    void Update () {
	}

    public void onQuestButtonClicked()
    {
        nameText.text = questNode.GetQuestName();
        descriptionText.text = questNode.GetQuestDescription();
        progressText.text = questNode.GetQuestProgress();

    }

    public void SetNameText(Text text)
    {
        nameText = text;
    }

    public void SetDescriptionText(Text text)
    {
        descriptionText = text;
    }

    public void SetProgressText(Text text)
    {
        progressText = text;
    }

    public void SetQuestNode(QuestNode quest)
    {
        questNode = quest;
        this.GetComponentInChildren<Text>().text = questNode.GetQuestName();
    }
}
