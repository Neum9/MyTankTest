using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTest : MonoBehaviour {

	[SerializeField]
	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
		Debug.Log("I am Start!");
	}

	private void Awake()
	{
		Debug.Log("I am Awake!");
	}

	private void OnEnable()
	{
		count++;
		Debug.Log("I am OnEnable!");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
