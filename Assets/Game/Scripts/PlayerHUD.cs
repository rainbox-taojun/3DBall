using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Text goldCount;
    PlayerCharacter character;

	private void Awake()
	{
		character = FindObjectOfType<PlayerCharacter>();
	}

	private void Update()
	{
		if (character)
		{
			goldCount.text = "Coin Count:" + character.GetCoinCount().ToString();
		}
	}
}
