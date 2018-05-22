using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager instance = null;

    [SerializeField]
    GameObject dialogueBox;
    [SerializeField]
    Text dialogueText;

    private GameObject interactedNPC;

    private string[] dialogueList;
    private int dialogueIndex;

    private bool dialogueActive;

    // Use this for initialization
    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject.transform.parent);
    }

    void Start () {
        dialogueList = new string[] { "" };
        dialogueIndex = 0;

        dialogueBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyDown(KeyCode.Q))
        {
            if (dialogueList.Length == dialogueIndex)
            {
                dialogueBox.SetActive(false);
                dialogueActive = false;
                interactedNPC.SendMessage("ChangeInteracting", false);
            }
            else
            {
                dialogueText.text = dialogueList[dialogueIndex++];
            }
        }
	}

    void ShowDialogue(string dialogue)
    {
        dialogueList = new string[] { dialogue };
        dialogueIndex = 0;

        dialogueActive = true;
        dialogueBox.SetActive(true);
    }

    void ShowDialogue(string[] dialogue)
    {
        dialogueList = dialogue;
        dialogueIndex = 0;

        dialogueActive = true;
        dialogueBox.SetActive(true);
    }

    void AttachNPC(GameObject npc)
    {
        interactedNPC = npc;
    }
}
