using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    bool isGameOver = false;

    public void SetGameState(bool isOver)
	{
		isGameOver = isOver;
	}

	public bool GetGameState()
	{
		return isGameOver;
	}
}
