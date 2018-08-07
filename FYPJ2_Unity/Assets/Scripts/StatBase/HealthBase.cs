using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : MonoBehaviour
{
	[SerializeField]
	int health;
	[SerializeField]
	int maxHealth;
	[SerializeField]
	public int maxHealthModifier;

    float testCase = 0;

    [SerializeField]
    float barDisplay = 0;
    [SerializeField]
    Texture2D progressBarEmpty;
    [SerializeField]
    Texture2D progressBarFull;

    private void Start()
    {
        progressBarEmpty = Resources.Load("bar_mask") as Texture2D;
        progressBarFull = Resources.Load("bar_health") as Texture2D;

	}

	/// <summary>
	/// Get current health
	/// </summary>
	public int GetCurrentHealth()
	{
		return health;
	}

	/// <summary>
	/// Get max health
	/// </summary>
	public int GetMaxHealth()
	{
		return maxHealth + maxHealthModifier;
	}

	/// <summary>
	/// Set current health
	/// </summary>
	public void SetCurrentHealth(int _health)
	{
		health = _health;
	}

	/// <summary>
	/// Set max health
	/// </summary>
	public void SetMaxHealth(int _maxHealth)
	{
		maxHealth = _maxHealth;
	}

	/// <summary>
	/// Modify current health
	/// </summary>
	public void ModifyCurrentHealth(int _amountToModify)
	{
		health += _amountToModify;
		NumberHelper.Instance.ClampBetweenValues(ref health, 0, GetMaxHealth());
	}

	/// <summary>
	/// Modify max health
	/// </summary>
	public void ModifyMaxHealth(int _amountToModify)
	{
		maxHealthModifier += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref maxHealthModifier, -maxHealth, int.MaxValue);
	}

	/// <summary>
	/// Check if health <= 0
	/// </summary>
	public bool CheckIsDead()
	{
		return (health <= 0);
	}

    private void OnGUI()
    {
        if (Player.Instance.gameObject == this.gameObject)
            return;

        Vector3 viewPos = CameraManager.Instance.currCamera.WorldToViewportPoint(transform.position);

        if (viewPos.z < 0 || viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y >1)
            return;

        barDisplay = (float)GetCurrentHealth() / (float)GetMaxHealth();

        Vector3 screenPos = CameraManager.Instance.currCamera.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + (transform.localScale.y * 0.6f), transform.position.z));
        screenPos.y = Screen.height - screenPos.y;

        Vector2 pos = new Vector2(screenPos.x - (progressBarEmpty.width * 0.5f), screenPos.y);
        Vector2 size = new Vector2(progressBarEmpty.width, progressBarEmpty.height);
        int test = progressBarEmpty.height;

        GUI.BeginGroup(new Rect(pos, size)/*, progressBarEmpty*/);
        GUI.DrawTexture(new Rect(new Vector2(), size), progressBarEmpty);
        //GUI.Box(new Rect(new Vector2(), size), progressBarEmpty);

        size.x -= (progressBarEmpty.width / 7);

        GUI.BeginGroup(new Rect(10, 0, size.x * barDisplay, size.y)/*, progressBarFull*/);
        GUI.DrawTexture(new Rect(0, 0, size.x, size.y), progressBarFull);
        //GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.EndGroup();

        GUI.EndGroup();
        return;
    }
}
