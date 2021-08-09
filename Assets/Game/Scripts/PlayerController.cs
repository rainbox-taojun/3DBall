using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCharacter character;
    PlayerCamera playerCamera;
    PlayerHUD hud;
    public GameMode mode;
    void Awake()
    {
        character = FindObjectOfType<PlayerCharacter>();
        playerCamera = FindObjectOfType<PlayerCamera>();
        hud = FindObjectOfType<PlayerHUD>();
        mode = FindObjectOfType<GameMode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode.GetGameState() == true) return;
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var cameraTrans = playerCamera.cameraComponent.transform;
        var movement = (v * cameraTrans.forward + h * cameraTrans.right).normalized;
        movement.y = 0;
        character.Move(movement);

        var jump = Input.GetKeyDown(KeyCode.Space);
        if (jump)
		{
            character.Jump();
		}
    }

    public void ShowGameoverPanel()
	{
        hud.ShowGameoverPanel();
        mode.SetGameState(true);
    }

    public void LevelComplete()
	{
        hud.ShowGameoverPanel();
        mode.SetGameState(true);
    }
}
