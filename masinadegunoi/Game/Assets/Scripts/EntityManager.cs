using UnityEngine;
using System;
using System.Collections.Generic;
public class EntityManager : Singleton<EntityManager>
{
	private List<Entity> m_entities;
	public EntityManager ()
	{
		m_entities = new List<Entity> ();
	}

	public void AddEntity(Entity _ent)
	{
		m_entities.Add (_ent);
	}

	public void RemoveEntity(Entity _ent)
	{
		m_entities.Remove (_ent);
	}

	public Entity GetEntity(GameObject _obj)
	{
		for (int i = 0; i < m_entities.Count; i++) 
		{
			if(_obj == m_entities[i].gameObject)
			{
				return m_entities[i];
			}
		}
		return null;
	}
}


