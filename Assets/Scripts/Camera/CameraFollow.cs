using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothing = 5F;

	Vector3 moveOffset;
	Quaternion turnOffset;
	[SerializeField] Vector3 axis = Vector3.zero;
	[SerializeField] float turn = 0;
	void Start () {
		moveOffset = transform.position - target.position;
		turnOffset = transform.rotation;
	}

	private void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + moveOffset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		transform.rotation = turnOffset * target.transform.rotation;
		target.transform.rotation.ToAngleAxis(out turn, out axis);
		Quaternion turnRotation = Quaternion.Euler(0, axis.y*turn, 0);
		transform.rotation = turnRotation * turnOffset;
	}
}
