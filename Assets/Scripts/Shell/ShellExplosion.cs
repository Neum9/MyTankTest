using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosion : MonoBehaviour {
	
	public LayerMask m_TankMask;
	public ParticleSystem m_ExplosionParticles;
	public AudioSource m_ExplosionAudio;
	public float m_MaxLifeTime = 2F;
	public float m_ExplosionRadius = 5F;
	public float m_MaxDamage = 50.0F;
	public float m_ExplosionForce = 100F;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, m_MaxLifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		Collider[] Tanks = Physics.OverlapSphere(transform.position, m_ExplosionRadius,m_TankMask);
		for (int i = 0;i < Tanks.Length;i++)
		{
			//hurt tank
			Rigidbody tartgetRigidbody = Tanks[i].GetComponent<Rigidbody>();

			tartgetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

			Tanks[i].GetComponent<TankHealth>().TakeDamage(CalDamage(tartgetRigidbody.position));
		}
		m_ExplosionParticles.transform.SetParent(null);
		m_ExplosionParticles.Play();
		m_ExplosionAudio.Play();
		Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
		Destroy(gameObject);
	}

	private float CalDamage(Vector3 targetPosition)
	{
		float damage = 0.0F;

		float dis = (targetPosition - transform.position).magnitude;
		if (dis < m_ExplosionRadius)
		{
			damage = m_MaxDamage * (dis / m_ExplosionRadius);
		}

		return damage;
	}

}
