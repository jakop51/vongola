using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{

	void Update()
	{
		//mouse or touch down handling for computer and phone
#if UNITY_EDITOR
			if (Input.GetKey(KeyCode.Mouse0) && GameController.Instance.InGame == true)
			{
			float zTmp = GameController.Instance.BallController.transform.position.z;
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
											 Input.mousePosition.y, zTmp - Camera.main.transform.position.z));
				GameController.Instance.BallController.ChangeBallAxisX(mousePosition.x);
			}
#else
		if (Input.touchCount > 0 && GameController.Instance.InGame == true)
		{
			float zTmp = GameController.Instance.BallController.transform.position.z;
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x,
										 Input.GetTouch(0).position.y, zTmp - Camera.main.transform.position.z));
			GameController.Instance.BallController.ChangeBallAxisX(mousePosition.x);
		}
#endif
	}

}
