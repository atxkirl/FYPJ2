using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<Character> CharacterList = new List<Character>();

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

public class Character
{
	public string name;
	public Texture2D previewImage;
	public GameObject playerPrefab;
}