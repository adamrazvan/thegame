using UnityEngine;
using System.Collections.Generic;

public class SelectButton : TriggerButton2D 
{
	private bool m_bIsOn = false;

	protected override void OnMouseExit ()
	{
		if (m_bIsOn)
			SetColor (m_cOnMouseOver);
		else
			SetColor (m_cBaseColor);
		SetScale (m_fScale.x,m_fScale.y);
		SetRotation (m_fInitRotation);
	}

	
	protected override void OnMouseUpAsButton ()
	{
		m_bIsOn = !m_bIsOn;
		if (m_bLock)
			return;
		if (m_bIsOn)
			SetColor (m_cOnMouseOver);
		else
			SetColor (m_cBaseColor);
		
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

