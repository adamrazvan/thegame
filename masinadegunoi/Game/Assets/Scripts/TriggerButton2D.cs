using UnityEngine;
using System.Collections.Generic;

public class TriggerButton2D : MonoBehaviour 
{
	public AudioSource m_OverSound;
	public AudioSource m_OnClickSound;
	public float m_fMouseOverScale = 0.2f;
	public Vector2 m_fScale;
	public Vector3 m_fRotation;
	public string m_MessageName;
	public Color m_cBaseColor = Color.green;
	public Color m_cOnClickCol = Color.blue;
	public Color m_cOnMouseOver = Color.red;
	public bool m_bComposed = false;
	public Vector3 m_fPosTarget ;
	public GameObject m_oLayer;
	public float m_fTime  = 2.0f;
	public bool m_bOnlyX = true;

	protected Vector3 m_fInitRotation;
	protected bool m_bLock = false;
	protected Vector3 m_fInitialPosition;
	protected float m_fCurrentTime = 0.0f;
	protected bool m_active = false;
	protected Transform m_transformModify;

	public bool IsComposed
	{
		get{ return m_bComposed;}
		set{ m_bComposed = value; }
	}

	void Start ()
	{
		if(m_oLayer != null)
			m_fInitialPosition = m_oLayer.transform.localPosition;
		m_fCurrentTime = m_fTime + 1.0f;
		if(m_bOnlyX)
			m_fPosTarget = new Vector3 (m_fPosTarget.x,m_fInitialPosition.y,m_fInitialPosition.z);

		m_fInitRotation = transform.localRotation.eulerAngles;
		m_transformModify = transform;
		
		if (m_bComposed) 
		{
			m_transformModify = transform.parent.transform;
		}
		SetRotation (m_fInitRotation);
		SetColor (m_cBaseColor);
		SetScale (m_fScale.x,m_fScale.y);
	}

	void Update ()
	{
		if (m_oLayer == null)
			return;
		
		m_fCurrentTime += Time.deltaTime;
		float factor = m_fCurrentTime / m_fTime;
		Vector3 newVector;
		if (factor < 1.0f) 
		{
			if(m_active)
				newVector = Vector3.Lerp(m_fInitialPosition,m_fPosTarget,factor);
			else
				newVector = Vector3.Lerp(m_fPosTarget,m_fInitialPosition,factor);
		}
		else
		{
			if(m_active )
				newVector =  m_fPosTarget;
			else
				newVector = m_fInitialPosition;
		}
		m_oLayer.transform.localPosition = newVector;
	}
	
	protected void SetRotation(Vector3 _rotation)
	{
		m_transformModify.localRotation = Quaternion.Euler(_rotation);
	}
	
	protected void SetColor(Color _col)
	{
		SpriteRenderer SpriteComponent = m_transformModify.GetComponent<SpriteRenderer> ();
		TextMesh TextComponent = m_transformModify.GetComponent<TextMesh> ();
		if (TextComponent)
			TextComponent.color = _col;

		if (SpriteComponent)
			SpriteComponent.color = _col;
	
	}	
	
	protected void SetScale(float _scaleX , float _scaleY )
	{
		m_transformModify.localScale = new Vector3(_scaleX, _scaleY, 1.0f);
	}
	
	protected void OnMouseDown () 
	{
		if (m_bLock)
			return;

		SetRotation (m_fRotation);
		SetColor (m_cOnClickCol);
	}
	
	protected void OnMouseEnter () 
	{
		SetScale (m_fScale.x + m_fMouseOverScale,m_fScale.y + m_fMouseOverScale);
		
		if(m_OverSound != null)
			m_OverSound.Play ();
	}
	
	protected virtual void OnMouseExit ()
	{
		SetScale (m_fScale.x,m_fScale.y);
		SetRotation (m_fInitRotation);
		SetColor (m_cBaseColor);
	}
	
	public void OnLock()
	{
		m_bLock = true;
	}

	public void OnUnlock()
	{
		m_bLock = false;
	}

	public void AutoTrigger()
	{
		OnMouseUpAsButton ();
	}

	protected virtual void OnMouseUpAsButton ()
	{
		if (m_bLock)
			return;

		m_active = !m_active;
		m_fCurrentTime = 0.0f;
		SetColor (m_cBaseColor);
		SetScale (m_fScale.x + m_fMouseOverScale,m_fScale.y + m_fMouseOverScale);
		SetRotation (m_fInitRotation);

		if(m_OnClickSound != null)
			m_OnClickSound.Play ();

		if(m_MessageName != "")
			UIManager.Instance.OnClick (m_MessageName);
	}
}
