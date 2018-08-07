using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSystem : SingletonMono<OptionSystem> {

    public Dictionary<string, KeyCode> keybinds = new Dictionary<string, KeyCode>();
    private Dictionary<string, GameObject> existingKey = new Dictionary<string, GameObject>();

    public GameObject OptionMenu;
    public GameObject AudioPanel;
    public GameObject KeybindPanel;

    private GameObject currentKey;

    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 selected = new Color32(102, 43, 53, 255);

    private Text value;

	// Use this for initialization
	void Awake () {

        OptionMenu = this.transform.GetChild(0).gameObject;
        AudioPanel = this.transform.GetChild(1).gameObject;
        KeybindPanel = this.transform.GetChild(2).gameObject;

        keybinds.Add("Forward", KeyCode.W);
        keybinds.Add("Back", KeyCode.S);
        keybinds.Add("Left", KeyCode.A);
        keybinds.Add("Right", KeyCode.R);
        keybinds.Add("Attack", KeyCode.Mouse0);
        keybinds.Add("Interact", KeyCode.F);
        keybinds.Add("Jump", KeyCode.Space);
        keybinds.Add("Switch Camera", KeyCode.V);
        keybinds.Add("Items", KeyCode.E);
        keybinds.Add("Skills", KeyCode.T);
        keybinds.Add("Inventory", KeyCode.Tab);
        keybinds.Add("Toggle Fire", KeyCode.Mouse1);
        keybinds.Add("Toggle Menu", KeyCode.Escape);

        List<string> keybindsKey = new List<string>(this.keybinds.Keys);

        for(int i = 0; i < keybinds.Count; ++i)
        {
            GameObject obj = Instantiate(Resources.Load("KeyBinds")) as GameObject;
            obj.transform.SetParent(KeybindPanel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0), false);

            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 525.0f - i * 85.0f);

            obj.transform.GetChild(0).GetComponent<Text>().text = keybindsKey[i] + ":";
            obj.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = keybinds[keybindsKey[i]].ToString();

            obj.transform.GetChild(1).name = keybindsKey[i];
            
            obj.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { ChangeKey(obj.transform.GetChild(1).gameObject); });

            existingKey.Add(keybinds[keybindsKey[i]].ToString(), obj.transform.GetChild(1).gameObject);
        }

        Slider slider = AudioPanel.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Slider>();
        slider.value = SoundManager.Instance.minVolume / SoundManager.Instance.maxVolume;
        value = AudioPanel.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
        value.text = ((int)(slider.value * 100)).ToString();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnGUI()
    {
        if (currentKey == null)
            return;

        Event e = Event.current;
        if (e.isKey || e.isMouse)
        {
            if (e.keyCode != KeyCode.None)
            {
                if (!existingKey.ContainsKey(e.keyCode.ToString()))
                {
                    existingKey.Remove(keybinds[currentKey.name].ToString());
                    keybinds[currentKey.name] = e.keyCode;
                    currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                    existingKey.Add(e.keyCode.ToString(), currentKey);
                }
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
            else if (e.button >= 0 && e.button <= 3)
            {
                switch (e.button)
                {
                    case 0:
                        if (!existingKey.ContainsKey(KeyCode.Mouse0.ToString()))
                        {
                            existingKey.Remove(keybinds[currentKey.name].ToString());
                            keybinds[currentKey.name] = KeyCode.Mouse0;
                            currentKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse0.ToString();
                            existingKey.Add(KeyCode.Mouse0.ToString(), currentKey);
                        }
                        break;
                    case 1:
                        if (!existingKey.ContainsKey(KeyCode.Mouse1.ToString()))
                        {
                            existingKey.Remove(keybinds[currentKey.name].ToString());
                            keybinds[currentKey.name] = KeyCode.Mouse1;
                            currentKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse1.ToString();
                            existingKey.Add(KeyCode.Mouse1.ToString(), currentKey);
                        }
                        break;
                    case 2:
                        if (!existingKey.ContainsKey(KeyCode.Mouse2.ToString()))
                        {
                            existingKey.Remove(keybinds[currentKey.name].ToString());
                            keybinds[currentKey.name] = KeyCode.Mouse2;
                            currentKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse2.ToString();
                            existingKey.Add(KeyCode.Mouse2.ToString(), currentKey);
                        }
                        break;
                }
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void BackButton()
    {
        OptionMenu.SetActive(true);
        AudioPanel.SetActive(false);
        KeybindPanel.SetActive(false);
    }

    public void GoToAudioMenu()
    {
        AudioPanel.SetActive(true);
        OptionMenu.SetActive(false);
        KeybindPanel.SetActive(false);
    }

    public void GoToKeybind()
    {
        AudioPanel.SetActive(false);
        OptionMenu.SetActive(false);
        KeybindPanel.SetActive(true);
    }

    public void AdjustVolume(Slider slider)
    {
        SoundManager.Instance.minVolume = slider.value;

        if (value == null)
            return;
        value.text = ((int)(slider.value * 100)).ToString();
    }
}
