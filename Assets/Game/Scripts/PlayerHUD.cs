using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Text goldCount;
	public GameObject GameoverPanel;
    PlayerCharacter character;

	public void OnClick_Restart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}

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

	public void ShowGameoverPanel()
	{
		GameoverPanel.SetActive(true);
	}
}
