using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

	public int m_tankNo = 1;
	public float m_movementSpeed = 5F;
	public float m_turnSpeed = 180F;

	private string m_MovementAxisName;
	private string m_TurnAixName;
	private float m_MovementInputValue;
	private float m_TurnInputValue;

	Rigidbody m_TankRigidbody;

	private void Awake()
	{
		m_TankRigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		m_MovementAxisName = "Vertical" + m_tankNo;
		m_TurnAixName = "Horizontal" + m_tankNo;

	}

	private void Update()
	{
		m_MovementInputValue = Input.GetAxisRaw(m_MovementAxisName);
		m_TurnInputValue = Input.GetAxisRaw(m_TurnAixName);
	}

	private void FixedUpdate()
	{
		Move();
		Turn();
	}

	void Move()
	{
		Vector3 movement = transform.forward * m_MovementInputValue * m_movementSpeed * Time.deltaTime;

		m_TankRigidbody.MovePosition(m_TankRigidbody.position + movement);
	}

	void Turn()
	{
		float turn = m_TurnInputValue * m_turnSpeed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler(0F, turn, 0F);
		m_TankRigidbody.MoveRotation(m_TankRigidbody.rotation * turnRotation);
	}
}
