using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class BallController : MonoBehaviour
{
	[SerializeField]
	float rotationSpeed;
	[SerializeField]
	Transform trailParticle;

	void Awake()
	{
		if (rotationSpeed <= 0)
		{
			Debug.LogError("rotationSpeed bad value in BallController");
			rotationSpeed = 1;
		}
		if (trailParticle == null)
			Debug.LogError("trailParticle bad value in BallController");
	}

	public void ChangeBallAxisX(float x)
	{
		Vector3 posTmp = this.transform.position;
		posTmp.x = x;
		this.transform.position = posTmp;
	}

	//handle collisions
	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameController.Instance.LoseGame();
	}

	public void SetBallCenter()
	{
		Vector3 tmpPos = this.transform.position;
		tmpPos.x = (GameController.Instance.lowerLeft.x + GameController.Instance.lowerRight.x) / 2;
		this.transform.position = tmpPos;
	}

	void Update()
	{
		this.transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
		trailParticle.position = this.transform.position;
		//turrentWeapon.transform.rotation = Quaternion.Lerp(turrentWeapon.transform.rotation, 
		//	targetRotation, turretRotationSpeed * Time.deltaTime);
		//turrentWeapon.localEulerAngles.y = 0;
		//turrentWeapon.localEulerAngles.z = 0;
	}
}
