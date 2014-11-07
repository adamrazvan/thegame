using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
	public string m_spriteName;
	private Collider2D m_collider;
	private Rigidbody2D m_rigidBody;
	private SpriteRenderer m_spriteRenderer;
	private Sprite m_sprite;
	public Collider2D Colider
	{
		get{ return m_collider; }
	}
	// Use this for initialization
	void Start () 
	{
		EntityManager.Instance.AddEntity (this);
		Init ();
	}

	virtual protected void Init()
	{
		m_sprite = Resources.Load<Sprite>(m_spriteName);
		m_spriteRenderer = new SpriteRenderer ();
	}
	
	virtual protected void OnHit()
	{
		MessageManager.Instance.TriggerMessage ("OnEntityHit", gameObject);
	}

	virtual protected void OnDie()
	{
		MessageManager.Instance.TriggerMessage ("OnEntityDie", gameObject);
	}

	virtual protected void OnUpdate()
	{
		MessageManager.Instance.TriggerMessage ("OnEntityUpdate", gameObject);
	}

	virtual protected void OnAfterPhysics()
	{
		MessageManager.Instance.TriggerMessage ("OnAfterEntityPhysics", gameObject);
	}

	// Update is called once per frame
	virtual protected void Update () 
	{
	
	}

	virtual protected void OnEntityCollide(Entity _ent,Collision2D _coll)
	{

	}

	void OnCollisionEnter2D(Collision2D _coll) 
	{
		Entity ent = EntityManager.Instance.GetEntity (_coll.gameObject);
		OnEntityCollide (ent, _coll);
	}


	void OnDestroy()
	{
		EntityManager.Instance.RemoveEntity (this);
	}
}
