using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public GameObject objectToPool;
	public int numberOfPoolObjects = 20;
	public bool allowPoolToGrow = true;

	public List<GameObject> pool;

	void Start()
	{
		pool = new List<GameObject>();

		for(int i = 0; i < numberOfPoolObjects; i++)
		{
			GameObject obj = (GameObject)Instantiate(objectToPool);
			obj.SetActive(false);
			pool.Add(obj);
		}
	}

	public GameObject GetObjectFromPool()
	{
		foreach(GameObject obj in pool)
		{
			if (!obj.activeInHierarchy)
				return obj;
		}

		if(allowPoolToGrow)
		{
			GameObject obj = (GameObject)Instantiate(objectToPool);
			obj.SetActive(false);
			pool.Add(obj);

			return obj;
		}

		return null;
	}
}
