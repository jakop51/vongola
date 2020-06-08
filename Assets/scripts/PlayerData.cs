using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
	private PlayerData() { }

	private static PlayerData instance = null;
	public static PlayerData Instance
	{
		get
		{
			if (instance == null)
				instance = new PlayerData();

			return instance;
		}
	}

	public int BestScore
	{
		get
		{
			return PlayerPrefs.HasKey("BestScore") ? PlayerPrefs.GetInt("BestScore") : 0;
		}
		set
		{
			PlayerPrefs.SetInt("BestScore", value);
		}
	}
	public int Money
	{
		get
		{
			return PlayerPrefs.HasKey("Money") ? PlayerPrefs.GetInt("Money") : 0;
		}
		set
		{
			PlayerPrefs.SetInt("Money", value);
		}
	}
	public int CurrentMaterial
	{
		get
		{
			return PlayerPrefs.HasKey("CurrentMaterial") ? PlayerPrefs.GetInt("CurrentMaterial") : 0;
		}
		set
		{
			PlayerPrefs.SetInt("CurrentMaterial", value);
		}
	}

	//public int Skin1
	//{
	//	get
	//	{
	//		return PlayerPrefs.HasKey("Skin1") ? PlayerPrefs.GetInt("Skin1") : 0;
	//	}
	//	set
	//	{
	//		PlayerPrefs.SetInt("Skin1", value);
	//	}
	//}
	//public int Skin2
	//{
	//	get
	//	{
	//		return PlayerPrefs.HasKey("Skin2") ? PlayerPrefs.GetInt("Skin2") : 0;
	//	}
	//	set
	//	{
	//		PlayerPrefs.SetInt("Skin2", value);
	//	}
	//}
	//public int Skin3
	//{
	//	get
	//	{
	//		return PlayerPrefs.HasKey("Skin3") ? PlayerPrefs.GetInt("Skin3") : 0;
	//	}
	//	set
	//	{
	//		PlayerPrefs.SetInt("Skin3", value);
	//	}
	//}
	//public int Skin4
	//{
	//	get
	//	{
	//		return PlayerPrefs.HasKey("Skin4") ? PlayerPrefs.GetInt("Skin4") : 0;
	//	}
	//	set
	//	{
	//		PlayerPrefs.SetInt("Skin4", value);
	//	}
	//}
	//public int Skin5
	//{
	//	get
	//	{
	//		return PlayerPrefs.HasKey("Skin5") ? PlayerPrefs.GetInt("Skin5") : 0;
	//	}
	//	set
	//	{
	//		PlayerPrefs.SetInt("Skin5", value);
	//	}
	//}
	//public int Skin6
	//{
	//	get
	//	{
	//		return PlayerPrefs.HasKey("Skin6") ? PlayerPrefs.GetInt("Skin6") : 0;
	//	}
	//	set
	//	{
	//		PlayerPrefs.SetInt("Skin6", value);
	//	}
	//}
}
