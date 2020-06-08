using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
	[SerializeField]
	private GameObject blockEx;
	[SerializeField]
	private Transform parentBlock;
	[SerializeField]
	private int blockAmount;

	//spawn points depends on screen corners
	float yStart;
	float yEnd;

	float xLeft;
	float xRight;

	private GameObject[] blockCopys;

	[SerializeField]
	float blocksSpeed;
	public float BlocksSpeed
	{
		get
		{
			return blocksSpeed;
		}

		set
		{
			blocksSpeed = value;
		}
	}

	float startSpeed;
	public float StartSpeed
	{
		get
		{
			return startSpeed;
		}
	}

	private void CheckValues()
	{
		if (blockEx == null)
			Debug.LogError("blockEx bad value in BlocksController");
		if (parentBlock == null)
			Debug.LogError("parentBlock bad value in BlocksController");
		if (blockAmount <= 0)
			Debug.LogError("blockAmount bad value in BlocksController");
		if (blocksSpeed <= 0)
			Debug.LogError("blocks speed bad value in BlocksController");
	}

	void Awake()
	{
		CheckValues();
		startSpeed = blocksSpeed;
	}

	void Start()
	{
		//set important vars
		yStart = GameController.Instance.lowerRight.y;
		yEnd = GameController.Instance.upperRight.y;
		xLeft = GameController.Instance.lowerLeft.x;
		xRight = GameController.Instance.lowerRight.x;

		print("yStart:" + yStart + "yEnd:" + yEnd + "xLeft:" + xLeft + "xRight:" + xRight);

		//create array of pre-loaded blocks
		blockCopys = new GameObject[blockAmount];
		//set created block to array
		for (int i = 0; i < blockAmount; i++)
		{
			blockCopys[i] = Instantiate(blockEx, parentBlock);
			blockCopys[i].SetActive(false);
		}
	}

	private GameObject GetFreeBlock()
	{
		for (int i = 0; i < blockCopys.Length; i++)
		{
			if (blockCopys[i].activeSelf == false)
			{
				blockCopys[i].SetActive(true);
				return blockCopys[i];
			}
		}
		Debug.LogError("No blocks found");
		return null;
	}

	public void SpawnBlock()
	{
		float randX = Random.Range(xLeft, xRight);
		GameObject tmpBlock = GetFreeBlock();
		if (tmpBlock != null)
			tmpBlock.transform.position = new Vector3(randX, yStart, 0);
	}

	public void DisableAllBlock()
	{
		for (int i = 0; i < blockCopys.Length; i++)
			blockCopys[i].SetActive(false);
	}

	public void MoveActiveBlocks()
	{
		for (int i = 0; i < blockCopys.Length; i++)
		{
			if (blockCopys[i].activeSelf == true)
			{
				blockCopys[i].transform.position += Vector3.up * blocksSpeed * Time.deltaTime;
				if (blockCopys[i].transform.position.y > yEnd)//disable block if too high
					blockCopys[i].SetActive(false);
			}
		}
	}

}