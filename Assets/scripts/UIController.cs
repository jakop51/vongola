using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	//singleton
	private static UIController instance;
	public static UIController Instance
	{
		get
		{
			return instance;
		}
	}

	[Header("Main canvases")]
	[SerializeField]
	GameObject mainMenuCanvas;
	[SerializeField]
	GameObject gameCanvas;
	[SerializeField]
	GameObject shopCanvas;

	[Header("Additional references")]
	[Space]
	[SerializeField]
	Text bestScoreMainMenuText;
	[SerializeField]
	Text inGameScoreText;
	[SerializeField]
	Text mainMenuMoneyText;

	private void CheckValues()
	{
		if (mainMenuCanvas == null)
			Debug.LogError("mainMenuCanvas bad values in UIController");
		if (gameCanvas == null)
			Debug.LogError("gameCanvas bad values in UIController");
		if (shopCanvas == null)
			Debug.LogError("shopCanvas bad values in UIController");

		if (bestScoreMainMenuText == null)
			Debug.LogError("bestScoreMainMenuText bad values in UIController");
		if (inGameScoreText == null)
			Debug.LogError("inGameScoreText bad values in UIController");
		if (mainMenuMoneyText == null)
			Debug.LogError("mainMenuMoneyText bad values in UIController");
	}


	void Awake()
	{
		//create singleton
		if (instance == null)
			instance = this;

		CheckValues();

		ShowMainMenuUI();
	}

	public void StartBtnHandling()
	{
		GameController.Instance.StartGameHandling();
	}

	public void ChangeInGameText(string str)
	{
		inGameScoreText.text = str;
	}

	////////Canvases appearing handling
	public void ShowMainMenuUI()
	{
		mainMenuCanvas.SetActive(true);
		gameCanvas.SetActive(false);
		shopCanvas.SetActive(false);

		//set best score and money text to UI
		bestScoreMainMenuText.text = PlayerData.Instance.BestScore.ToString();
		mainMenuMoneyText.text = PlayerData.Instance.Money.ToString();
	}
	public void ShowInGameUI()
	{
		mainMenuCanvas.SetActive(false);
		gameCanvas.SetActive(true);
		shopCanvas.SetActive(false);
	}
	public void ShowShopUI()
	{
		mainMenuCanvas.SetActive(false);
		gameCanvas.SetActive(false);
		shopCanvas.SetActive(true);
		this.gameObject.GetComponent<ShopControllerUI>().SetValuesToShopUI();
	}
}
