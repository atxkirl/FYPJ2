﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonHelper<T> : MonoBehaviour where T : Component
{
	private static T _instance;

	public static T Instance
	{
		get
		{
			//Try to find an existing instance if necessary
			if (!_instance)
			{
				_instance = FindObjectOfType(typeof(T)) as T;
			}

			//If the instance is still null, create a new instance of object
			if (!_instance)
			{
				GameObject go = new GameObject();
				_instance = go.AddComponent<T>();
			}

			return _instance;
		}
	}

	private void Awake()
	{
		if (_instance)
		{
			Destroy(this);
		}
	}
}
