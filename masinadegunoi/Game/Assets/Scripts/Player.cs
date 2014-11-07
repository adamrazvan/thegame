using UnityEngine;
using System.Collections;

public class Player : Entity 
{
	private string m_moveHorizontal = "Horizontal";
	private float  m_movementSpeedFactor = 10.0f;

	public string MoveKey
	{
		get{ return m_moveHorizontal; }
		set{ m_moveHorizontal = value; }
	}
	
	public float MovementSpeedFactor
	{
		get { return m_movementSpeedFactor; } 
		set { m_movementSpeedFactor = value;}
	}
	
	public void MovePlayer()
	{
		if (Input.GetButton(m_moveHorizontal))
		{
			float translateX = Time.deltaTime * Input.GetAxis(m_moveHorizontal) * m_movementSpeedFactor ;
			transform.Translate(new Vector3(translateX,0.0f,0.0f));
		}
	}

	override protected void OnEntityCollide(Entity _ent,Collision2D _coll)
	{
		if (!_ent)
			return;

		if (_ent.name == "Ball") 
		{

			//_ent.gameObject.rigidbody2D.AddForce();
		}
	}

	override protected void Update()
	{
		MovePlayer ();
	}
}
