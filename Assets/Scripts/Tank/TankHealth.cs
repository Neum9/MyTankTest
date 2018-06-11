using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour {

	public Slider m_HealthSlider;

	private float m_MaxHealth;
	public float m_MinHealth { get; private set; }
	public float m_NowHealth { get; private set; }

	// Use this for initialization
	void Start () {
		m_MaxHealth = m_HealthSlider.maxValue;
		m_MinHealth = m_HealthSlider.minValue;
		m_NowHealth = m_MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//受伤时减少血量
	public void TakeDamage(float damage)
	{
		if (m_NowHealth - m_MinHealth < damage)
			m_NowHealth = m_MinHealth;
		else
			m_NowHealth -= damage;

		m_HealthSlider.value = m_NowHealth;
	}
}
