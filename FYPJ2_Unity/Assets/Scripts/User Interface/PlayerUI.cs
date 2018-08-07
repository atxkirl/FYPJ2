using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    Image HealthBar;

    [SerializeField]
    Image ManaBar;

    [SerializeField]
    Image StaminaBar;

    private float healthPercentage;
    private float manaPercentage;
    private float staminaPercentage;

    const float speed = 5.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        healthPercentage = (float)Player.Instance.GetCurrentHealth() / (float)Player.Instance.GetMaxHealth();

        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, healthPercentage, Time.deltaTime * speed);

        manaPercentage = (float)Player.Instance.GetCurrentMana() / (float)Player.Instance.GetMaxMana();

        ManaBar.fillAmount = Mathf.Lerp(ManaBar.fillAmount, manaPercentage, Time.deltaTime * speed);

        staminaPercentage = (float)Player.Instance.GetCurrentStamina() / (float)Player.Instance.GetMaxStamina();

        StaminaBar.fillAmount = Mathf.Lerp(StaminaBar.fillAmount, staminaPercentage, Time.deltaTime * speed);
    }
}
