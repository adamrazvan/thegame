using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Player m_Player;
	public Chain m_Chain;
	public Ball m_Balls;

	void CreateBounds()
	{

	}
	// Use this for initialization
	void Start () 
	{
		MessageManager.Instance.Init ();
		MessageManager.Instance.RegisterToConstants (gameObject);
	}

	void OnEntityDie(GameObject _obj)
	{

	}

	void OnEntityHit(GameObject _obj)
	{

	}

	void OnEntityUpdate(GameObject _obj)
	{

	}
	
	void OnAfterEntiryPhysics(GameObject _obj)
	{

	}


	// Update is called once per frame
	void Update () 
	{
	
	}
}
