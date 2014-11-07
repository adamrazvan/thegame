using UnityEngine;
using System.Collections.Generic;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
	private static T m_instance;

	public static T Instance
	{
		get
		{
			if(m_instance == null)
			{
				m_instance = GameObject.FindObjectOfType<T>();

				DontDestroyOnLoad(m_instance.gameObject);
			}
			
			return m_instance;
		}
	}
	
	void Awake() 
	{
		if(m_instance == null)
		{
			if(GameObject.FindObjectsOfType<T>().Length == 1)
			{
				m_instance = GameObject.FindObjectOfType<T>();
			}
			else
			{
				GameObject singleton = new GameObject();
				m_instance = singleton.AddComponent<T>();
				singleton.name = "(singleton) "+ typeof(T).ToString();
			}
			//If I am the first instance, make me the Singleton
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != m_instance)
				Destroy(this.gameObject);
		}
	}
}