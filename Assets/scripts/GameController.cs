using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class GameController : MonoBehaviour
{
	//singleton handling
	static private GameController instance;
	public static GameController Instance
	{
		get
		{
			return instance;
		}
	}

	BlocksController blocksController;
	public BlocksController BlocksController
	{
		get { return blocksController; }
	}

	[SerializeField]
	BallController ballController;
	public BallController BallController
	{
		get { return ballController; }
	}

	//time handling
	[SerializeField]
	float delay;
	float timeCounter;

	//screen corners handling
	public Vector3 upperLeft { get; private set; }
	public Vector3 upperRight { get; private set; }
	public Vector3 lowerLeft { get; private set; }
	public Vector3 lowerRight { get; private set; }

	//in game controll var
	bool inGame = false;
	public bool InGame
	{
		get
		{
			return inGame;
		}
	}

	[Header("Counting values")]
	[SerializeField]
	float progressCoef;
	private float currentProgress;
	[SerializeField]
	float speedIncrCoef;
	[SerializeField]
	float speedMax;

	public static int skinsPrice
	{
		get
		{
			return 30;
		}
	}


	//variables for skins
	public static string skinWord
	{
		get
		{
			return "Skin";
		}
	}

	[SerializeField]
	private Material[] materialsArr;
	public int MaterialsAmount
	{
		get
		{
			return materialsArr.Length;
		}
		private set { }
	}

	//private Material currentMaterial;
	//public Material CurrentMaterial
	//{
	//	get
	//	{
	//		return currentMaterial;
	//	}
	//}

	private void SetScreenCornersToWord()
	{
		//handling camera corners
		// Screens coordinate corner location
		float depth = (0 - Camera.main.transform.position.z);

		Vector3 upperLeftScreen = new Vector3(0, Screen.height, depth);
		Vector3 upperRightScreen = new Vector3(Screen.width, Screen.height, depth);
		Vector3 lowerLeftScreen = new Vector3(0, 0, depth);
		Vector3 lowerRightScreen = new Vector3(Screen.width, 0, depth);

		//Corner locations in world coordinates
		upperLeft = Camera.main.ScreenToWorldPoint(upperLeftScreen);
		upperRight = Camera.main.ScreenToWorldPoint(upperRightScreen);
		lowerLeft = Camera.main.ScreenToWorldPoint(lowerLeftScreen);
		lowerRight = Camera.main.ScreenToWorldPoint(lowerRightScreen);

		print("upperLeft :" + upperLeft);
		print("upperRight:" + upperRight);
		print("lowerLeft :" + lowerLeft);
		print("lowerRight:" + lowerRight);
	}

	private void CheckValues()
	{
		if (delay <= 0)
			Debug.LogError("delay bad value in GameController");
		if (blocksController == null)
			Debug.LogError("blocksController bad value in GameController");
		if (ballController == null)
			Debug.LogError("ballController bad value in GameController");
		if (progressCoef <= 0)
			Debug.LogError("progressCoef bad value in GameController");
		if (speedIncrCoef <= 0)
			Debug.LogError("speedIncrCoef bad value in GameController");
		if (speedMax <= 0)
			Debug.LogError("speedMax bad value in GameController");
	}

	public void Awake()
	{
		//crate singleton
		if (instance == null)
			instance = this;

		//set blockController from current object
		blocksController = this.gameObject.GetComponent<BlocksController>();

		CheckValues();


		//set word point screen corners
		SetScreenCornersToWord();

		//set start saved material
		SetMaterialToBall();
	}

	//set current material to ball
	public void SetMaterialToBall()
	{
		ballController.gameObject.GetComponent<MeshRenderer>().material = materialsArr[PlayerData.Instance.CurrentMaterial];
	}

	void Start()
	{
		ballController.SetBallCenter();
	}

	void ResetValues()
	{
		blocksController.BlocksSpeed = blocksController.StartSpeed;
		currentProgress = 0;
	}

	void RunValuesHandling()
	{
		//current progress counting
		currentProgress += progressCoef * Time.deltaTime;
		UIController.Instance.ChangeInGameText(((int)(currentProgress)).ToString());

		//speed incrising
		blocksController.BlocksSpeed += speedIncrCoef * Time.deltaTime;
		//check for speed too fast
		if (blocksController.BlocksSpeed > speedMax)
			blocksController.BlocksSpeed = speedMax;
	}

	void Update()
	{
		if (inGame == true)
		{
			timeCounter += Time.deltaTime;

			RunValuesHandling();

			if (timeCounter >= delay)
			{
				timeCounter = 0;
				blocksController.SpawnBlock();
			}
			blocksController.MoveActiveBlocks();
		}
	}

	public void StartGameHandling()
	{
		inGame = true;
		UIController.Instance.ShowInGameUI();
		ballController.SetBallCenter();
		//reset values before start
		ResetValues();
	}

	public void LoseGame()
	{
		inGame = false;
		blocksController.DisableAllBlock();

		ballController.SetBallCenter();

		//check for best score
		if ((int)currentProgress > PlayerData.Instance.BestScore)
			PlayerData.Instance.BestScore = (int)currentProgress;

		//moneys == score counting
		PlayerData.Instance.Money += (int)currentProgress;

		UIController.Instance.ShowMainMenuUI();
	}

	public void PrintShit()
	{
		print("shit");
	}
}
