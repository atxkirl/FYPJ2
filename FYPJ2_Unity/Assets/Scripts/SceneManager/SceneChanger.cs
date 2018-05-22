using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public static SceneChanger instance;
	public Animator animator;

	private int sceneToLoad;

	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this;

		//If instance already exists and it's not this then destroy
		else if (instance != this)
			Destroy(gameObject);
	}

	public void FadeToScene(int sceneIndex)
	{
		sceneToLoad = sceneIndex;
		animator.SetTrigger("FadeOut");
	}

	public void OnFadeComplete()
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
