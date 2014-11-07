using UnityEngine;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager>
{
	private Dictionary<string,List<string>> m_Messages;
	protected UIManager()
	{

	}
	[SerializeField]
	private List<GameObject> m_lButtons = new List<GameObject>();

	public void AddTriggerButton()
	{
		Object loaded = Resources.LoadAssetAtPath ("Assets/TriggerButton.prefab", typeof(GameObject)); 

		if (loaded != null) 
		{
			GameObject newGameObj = (GameObject)GameObject.Instantiate (loaded);
			newGameObj.transform.parent = Instance.transform;
			m_lButtons.Add (newGameObj);
		}
		else
		{
			Debug.LogWarning("Can't load trigger button prefab");
		}
	}

	public void AddSelectButton()
	{
		Object loaded = Resources.LoadAssetAtPath ("Assets/SelectButton.prefab", typeof(GameObject)); 
		
		if (loaded != null) 
		{
			GameObject newGameObj = (GameObject)GameObject.Instantiate (loaded);
			newGameObj.transform.parent = Instance.transform;
			m_lButtons.Add (newGameObj);
		}
		else
		{
			Debug.LogWarning("Can't load select button prefab");
		}
	}

	public void AddComposedButton()
	{
		Object loaded = Resources.LoadAssetAtPath ("Assets/ComposedButton.prefab", typeof(GameObject)); 
		
		if (loaded != null) 
		{
			GameObject newGameObj = (GameObject)GameObject.Instantiate (loaded);
			newGameObj.transform.parent = Instance.transform;
			m_lButtons.Add (newGameObj);
		}
		else
		{
			Debug.LogWarning("Can't load composed button prefab");
		}
	}

	public void OnClick(string _message)
	{
		BroadcastMsg (_message);
	}

	public void RegisterMsg(string msg, string tag)
	{
		tryInit ();

		if (m_Messages.ContainsKey (msg)) 
		{
			List<string> list = m_Messages[msg];
			list.Add(tag);
			m_Messages[msg] = list;
		}
		else
		{
			List<string> list = new List<string>();
			list.Add(tag);
			m_Messages.Add(msg,list);
		}
	}

	public void BroadcastMsg(string message)
	{
		tryInit ();

		if (m_Messages.ContainsKey (message)) 
		{
			List<string> messageTags = m_Messages [message];
		
			for (int i = 0; i < messageTags.Count; i++) 
			{
				GameObject[] objs = GameObject.FindGameObjectsWithTag (messageTags [i]);
				foreach (GameObject receiver in objs) 
				{
					receiver.SendMessage (message);
				}
			}
		}
	}

	public void LockAllButtons()
	{
		for(int i = 0; i < m_lButtons.Count; i++)
		{
			if(m_lButtons[i].GetComponent<TriggerButton2D>())
			{
				m_lButtons[i].GetComponent<TriggerButton2D>().OnLock();
			}
			else
			{
				for(int k = 0; k < m_lButtons[i].transform.childCount; k++)
					m_lButtons[i].transform.GetChild(k).GetComponent<TriggerButton2D>().OnLock();
			}
		}
	}

	public void UnlockAllButtons()
	{
		for(int i = 0; i < m_lButtons.Count; i++)
		{
			if(m_lButtons[i].GetComponent<TriggerButton2D>())
			{
				m_lButtons[i].GetComponent<TriggerButton2D>().OnUnlock();
			}
			else
			{
				for(int k = 0; k < m_lButtons[i].transform.childCount; i++)
					m_lButtons[i].transform.GetChild(k).GetComponent<TriggerButton2D>().OnUnlock();
			}
	
		}
	}

	public void LockTriggerButton(string name)
	{
		for(int i = 0; i < m_lButtons.Count; i++)
		{
			if(m_lButtons[i].name == name)
			{
				if(m_lButtons[i].GetComponent<TriggerButton2D>())
				{
					m_lButtons[i].GetComponent<TriggerButton2D>().OnLock();
				}
				else
				{
					for(int k = 0; k < m_lButtons[i].transform.childCount; i++)
						m_lButtons[i].transform.GetChild(k).GetComponent<TriggerButton2D>().OnLock();
				}
			}
		}
	}
	public void UnlockTriggerButton(string name)
	{
		for(int i = 0; i < m_lButtons.Count; i++)
		{
			if(m_lButtons[i].name == name)
			{
				if(m_lButtons[i].GetComponent<TriggerButton2D>())
				{
					m_lButtons[i].GetComponent<TriggerButton2D>().OnUnlock();
				}
				else
				{
					for(int k = 0; k < m_lButtons[i].transform.childCount; i++)
						m_lButtons[i].transform.GetChild(k).GetComponent<TriggerButton2D>().OnUnlock();
				}
			}
		}
	}
	public void AutoTriggerButton(string name)
	{
		for(int i = 0; i < m_lButtons.Count; i++)
		{
			if(m_lButtons[i].name == name)
			{
				m_lButtons[i].GetComponent<TriggerButton2D>().AutoTrigger();
			}
		}
	}
	void tryInit()
	{
		if(m_Messages == null)
			m_Messages = new Dictionary<string,List<string>>();
	}
	// Use this for initialization
	void Start () 
	{
		tryInit ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
