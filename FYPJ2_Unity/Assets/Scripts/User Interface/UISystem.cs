using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : SingletonMono<UISystem> {

    public GameObject playerUI;
    public GameObject menuUI;
    public GameObject optionsUI;
    public GameObject questUI;
    public GameObject inventoryUI;
    public GameObject skillsUI;
    public GameObject dialogueUI;

    // Use this for initialization
    void Start () {
        //I forgot how init the instance to bypass this so I just gonna leave this here
        optionsUI.SetActive(true);
        OptionSystem.Instance.enabled = true;
        //

        playerUI.SetActive(true);
        menuUI.SetActive(false);
        optionsUI.SetActive(false);
        questUI.SetActive(false);
        inventoryUI.SetActive(false);
        skillsUI.SetActive(false);
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(OptionSystem.Instance.keybinds["Toggle Menu"]))
        {
            if (playerUI.activeSelf)
            {
                playerUI.SetActive(false);
                menuUI.SetActive(true);
                optionsUI.SetActive(false);
                questUI.SetActive(false);
                inventoryUI.SetActive(false);
                skillsUI.SetActive(false);
                dialogueUI.SetActive(false);
            }
            else
            {
                playerUI.SetActive(true);
                menuUI.SetActive(false);
                optionsUI.SetActive(false);
                questUI.SetActive(false);
                inventoryUI.SetActive(false);
                skillsUI.SetActive(false);
                dialogueUI.SetActive(false);
            }
        }
        if (Input.GetKeyDown(OptionSystem.Instance.keybinds["Skills"]))
        {
            if (playerUI.activeSelf)
            {
                playerUI.SetActive(false);
                menuUI.SetActive(false);
                optionsUI.SetActive(false);
                questUI.SetActive(false);
                inventoryUI.SetActive(false);
                skillsUI.SetActive(true);
                dialogueUI.SetActive(false);
            }
            else
            {
                playerUI.SetActive(true);
                menuUI.SetActive(false);
                optionsUI.SetActive(false);
                questUI.SetActive(false);
                inventoryUI.SetActive(false);
                skillsUI.SetActive(false);
                dialogueUI.SetActive(false);
            }
        }
        if (Input.GetKeyDown(OptionSystem.Instance.keybinds["Inventory"]))
        {
            if (playerUI.activeSelf)
            {
                playerUI.SetActive(false);
                menuUI.SetActive(false);
                optionsUI.SetActive(false);
                questUI.SetActive(false);
                inventoryUI.SetActive(true);
                skillsUI.SetActive(false);
                dialogueUI.SetActive(false);
            }
            else
            {
                playerUI.SetActive(true);
                menuUI.SetActive(false);
                optionsUI.SetActive(false);
                questUI.SetActive(false);
                inventoryUI.SetActive(false);
                skillsUI.SetActive(false);
                dialogueUI.SetActive(false);
            }
        }
    }

    public void BackToMenu()
    {
        playerUI.SetActive(false);
        menuUI.SetActive(true);
        optionsUI.SetActive(false);
        questUI.SetActive(false);
        inventoryUI.SetActive(false);
        skillsUI.SetActive(false);
        dialogueUI.SetActive(false);
    }

    public void OptionsButton()
    {
        optionsUI.SetActive(true);
        playerUI.SetActive(false);
        menuUI.SetActive(false);
        questUI.SetActive(false);
        inventoryUI.SetActive(false);
        skillsUI.SetActive(false);
        dialogueUI.SetActive(false);
    }

    public void QuestButton()
    {
        optionsUI.SetActive(false);
        playerUI.SetActive(false);
        menuUI.SetActive(false);
        questUI.SetActive(true);
        inventoryUI.SetActive(false);
        skillsUI.SetActive(false);
        dialogueUI.SetActive(false);
    }

    public void InventoryButton()
    {
        optionsUI.SetActive(false);
        playerUI.SetActive(false);
        menuUI.SetActive(false);
        questUI.SetActive(false);
        inventoryUI.SetActive(true);
        skillsUI.SetActive(false);
        dialogueUI.SetActive(false);
    }

    public void SkillButton()
    {
        optionsUI.SetActive(false);
        playerUI.SetActive(false);
        menuUI.SetActive(false);
        questUI.SetActive(false);
        inventoryUI.SetActive(false);
        skillsUI.SetActive(true);
        dialogueUI.SetActive(false);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
