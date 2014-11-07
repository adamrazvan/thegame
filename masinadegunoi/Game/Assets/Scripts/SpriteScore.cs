//using UnityEngine;
//using System.Collections.Generic;
//
//public class SpriteScore :MonoBehaviour
//{
//	public bool m_bSmall;
//	public float m_fScale = 100;
//	public float m_fOffset = 15;
//	public Color m_cSpriteColor = Color.blue;
//
//	private string m_sScore;
//	private List<Sprite> m_lSprites;
//	private List<GameObject> m_lNumbers;
//
//	public string Score
//	{
//		get 
//		{
//			return m_sScore;
//		}
//
//		set
//		{
//			UnspawnScore();
//			m_sScore = value;
//			SpawnScore();
//		}
//	}
//
//	void Start () 
//	{
//		if(m_lNumbers == null)
//			m_lNumbers = new List<GameObject>();
//	}
//
//	// Update is called once per frame
//	void Update () 
//	{
//		
//	}
//
//	//spawns the number
//	void SpawnScore()
//	{
//		int nNumbers = m_sScore.Length;
//		for(int i = 0; i < nNumbers; i++)
//		{
//			SpawnNumber(int.Parse(m_sScore[i].ToString()));
//		}
//	}
//
//	//spawns an digit from the nmber
//	void SpawnNumber(int number)
//	{
//		//spawn the game object and assing the sprite to the SpriteRenderer component
//		string name = "" + number;
//		
//		GameObject newNumber = new GameObject (name);
//
//		newNumber.transform.parent = transform;
//		newNumber.transform.localPosition = new Vector3(m_lNumbers.Count * m_fOffset,0.0f,0.0f);
//		newNumber.transform.localScale = new Vector3 (m_fScale, m_fScale, m_fScale);
//		newNumber.layer = LayerMask.NameToLayer("MainScreen");
//		SpriteRenderer spriteRenderer = (SpriteRenderer)newNumber.AddComponent ("SpriteRenderer");
//
//		if(m_bSmall)
//			m_lSprites = transform.parent.gameObject.GetComponent<ScoreManager> ().m_lSmall;
//		else
//			m_lSprites = transform.parent.gameObject.GetComponent<ScoreManager> ().m_lBig;
//
//		spriteRenderer.color = m_cSpriteColor;
//		spriteRenderer.sprite = m_lSprites [number];
//		spriteRenderer.sortingLayerName = "Slots";
//		spriteRenderer.sortingOrder = 1;
//		m_lNumbers.Add(newNumber);
//	}
//
//	//unspawns the number
//	void UnspawnScore()
//	{
//		if(m_lNumbers == null)
//			m_lNumbers = new List<GameObject>();
//
//		while(m_lNumbers.Count > 0)
//		{
//			GameObject obj = m_lNumbers[0];
//			Destroy(obj);
//			m_lNumbers.RemoveAt(0);
//		}
//	}
//}
//
//
