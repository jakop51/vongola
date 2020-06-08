using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControllerUI : MonoBehaviour
{
	[SerializeField]
	Button skin1;
	[SerializeField]
	Button skin2;
	[SerializeField]
	Button skin3;
	[SerializeField]
	Button skin4;
	[SerializeField]
	Button skin5;
	[SerializeField]
	Button skin6;
	[Space]
	[SerializeField]
	Text moneyAmountText;
	[Space]
	[SerializeField]
	Button exitBtn;
	void Awake()
	{
		skin1.onClick.AddListener(delegate { SkinClickHandler(0); });
		skin2.onClick.AddListener(delegate { SkinClickHandler(1); });
		skin3.onClick.AddListener(delegate { SkinClickHandler(2); });
		skin4.onClick.AddListener(delegate { SkinClickHandler(3); });
		skin5.onClick.AddListener(delegate { SkinClickHandler(4); });
		skin6.onClick.AddListener(delegate { SkinClickHandler(5); });

		exitBtn.onClick.AddListener(HandleExitBtn);
	}

	void Start()
	{
		InitializeMaterialPrefs();
	}

	public void SetValuesToShopUI()
	{
		moneyAmountText.text = PlayerData.Instance.Money.ToString();
	}

	private void SkinClickHandler(int id)
	{
		if (PlayerPrefs.GetInt(GameController.skinWord + id.ToString()) == 0)
		{//try to buy
			if (PlayerData.Instance.Money >= GameController.skinsPrice)
			{
				PlayerData.Instance.Money -= GameController.skinsPrice;
				PlayerPrefs.SetInt(GameController.skinWord + id.ToString(), 1);
				PlayerData.Instance.CurrentMaterial = id;
				GameController.Instance.SetMaterialToBall();
			}
			else
				Debug.Log("NO MONEY");
		}
		else
		{
			PlayerData.Instance.CurrentMaterial = id;
			GameController.Instance.SetMaterialToBall();
		}
		SetValuesToShopUI();
	}

	private void InitializeMaterialPrefs()
	{
		for (int i = 0; i < GameController.Instance.MaterialsAmount; i++)
			if (PlayerPrefs.HasKey(GameController.skinWord + i.ToString()) == false)
				PlayerPrefs.SetInt(GameController.skinWord + i.ToString(), 0);

		PlayerPrefs.SetInt(GameController.skinWord + "0", 1);
	}

	private void HandleExitBtn()
	{
		UIController.Instance.ShowMainMenuUI();
	}
}
