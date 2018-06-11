using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour {

	public int m_TankNo = 1;
	public GameObject m_Shell;
	public Transform m_FireTransform;
	public Slider m_AimSlider;
	public AudioSource m_ShootingAudio;
	public AudioClip m_ChargingClip;
	public AudioClip m_FireClip;
	public float m_MinLaunchForce = 15F;
	public float m_MaxLaunchForce = 30F;
	public float m_MaxChargeTime = 0.75F;
	public float m_Recoil = 0.5F;

	private string m_FireButton;
	private Rigidbody m_ShellRigidBody;
	private float m_CurrentLaunchForce;
	private float m_ChargeSpeed;
	private bool m_Fired;
	private Rigidbody m_TankRigidBody;

	private void OnEnable()
	{
		m_CurrentLaunchForce = m_MinLaunchForce;
		m_AimSlider.value = m_MinLaunchForce;
	}

	// Use this for initialization
	void Start()
	{
		m_FireButton = "Fire" + m_TankNo;
		m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
		m_TankRigidBody = GetComponent<Rigidbody>();
		m_ShellRigidBody = m_Shell.GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void Update () {
		m_AimSlider.value = m_MinLaunchForce;

		if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
		{
			m_CurrentLaunchForce = m_MaxLaunchForce;
			Fire();
		}
		else if (Input.GetButtonDown(m_FireButton))
		{
			m_Fired = false;
			m_CurrentLaunchForce = m_MinLaunchForce;
			m_ShootingAudio.clip = m_ChargingClip;
			m_ShootingAudio.Play();
		}
		else if (Input.GetButton(m_FireButton) && !m_Fired)
		{
			m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
			m_AimSlider.value = m_CurrentLaunchForce;
		}
		else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
		{
			Fire();
		}
	}

	private void Fire()
	{
		m_Fired = true;

		Rigidbody shellInstance = Instantiate(m_ShellRigidBody, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

		shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

		m_ShootingAudio.clip = m_FireClip;
		m_ShootingAudio.Play();

		//增加后坐力
		m_TankRigidBody.MovePosition(m_TankRigidBody.position - m_TankRigidBody.transform.forward * m_Recoil);

		m_CurrentLaunchForce = m_MinLaunchForce;
	}
}
