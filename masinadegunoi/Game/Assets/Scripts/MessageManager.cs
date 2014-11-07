using UnityEngine;
using System.Collections.Generic;

public class MessageManager : Singleton<MessageManager>
{
	public Dictionary<string,List<GameObject>> m_Messages;

	[SerializeField]
	private List<string> m_ConstantMsgs;

	protected MessageManager()
	{
		if(m_Messages == null)
			m_Messages = new Dictionary<string,List<GameObject>>();

		if (m_ConstantMsgs == null)
			m_ConstantMsgs = new List<string> ();
	}

	public void Init()
	{
		foreach (string msgName in  m_ConstantMsgs) 
		{
			CreateMessage(msgName);
		}
	}

	public void CreateMessage(string _msgName)
	{
		List<GameObject> list = new List<GameObject>();
		m_Messages.Add(_msgName,list);
	}

	public void CreteMessageAndAddEntity(string _msgName ,GameObject _entity)
	{
		List<GameObject> list = new List<GameObject>();
		list.Add (_entity);
		m_Messages.Add(_msgName,list);
	}
	
	public void TriggerMessage(string _msgName, GameObject _obj)
	{
		foreach (GameObject obj in m_Messages[_msgName])
		{
			obj.SendMessage(_msgName,_obj);
		}
	}

	public void RegisterToConstants(GameObject _entity)
	{
		foreach (string msg in m_ConstantMsgs) 
		{
			m_Messages[msg].Add(_entity);
		}
	}

	public bool RegisterToMessage(string _msgName,GameObject _entity)
	{
		if (m_Messages.ContainsKey (_msgName)) 
		{
			m_Messages[_msgName].Add(_entity);
			return true;
		}

		return false;
	}
}
