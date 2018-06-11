using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManageMent : MonoBehaviour {

	public GameObject Tank1;
	public GameObject Tank2;

	public Text TankHint1;
	public Text TankHint2;

	private TankHealth tank1Health;
	private TankHealth tank2Health;

	private float MinHealth;

	// Use this for initialization
	void Start () {
		tank1Health = Tank1.GetComponent<TankHealth>();
		tank2Health = Tank2.GetComponent<TankHealth>();
		MinHealth = tank1Health.m_MinHealth;
	}

	private void LateUpdate()
	{
		//tank1Health = Tank1.GetComponent<TankHealth>();
		//tank2Health = Tank2.GetComponent<TankHealth>();
		if (tank1Health.m_NowHealth <= MinHealth)
		{
			TankLostControl();
			TankHint1.text = "You Lose!";
			TankHint2.text = "You Win!";
		}
		else if (tank2Health.m_NowHealth <= MinHealth)
		{
			TankLostControl();
			TankHint1.text = "You Win!";
			TankHint2.text = "You Lose";
		}
	}

    private void TankLostControl()
	{
		Tank1.GetComponent<TankMovement>().enabled = false;
		Tank1.GetComponent<TankShooting>().enabled = false;
		Tank2.GetComponent<TankMovement>().enabled = false;
		Tank2.GetComponent<TankShooting>().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
