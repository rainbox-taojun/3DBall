using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCharacter character;
    PlayerCamera playerCamera;

    void Awake()
    {
        character = FindObjectOfType<PlayerCharacter>();
        playerCamera = FindObjectOfType<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var cameraTrans = playerCamera.cameraComponent.transform;
        var movement = (v * cameraTrans.forward + h * cameraTrans.right).normalized;

        character.Move(movement);

        var jump = Input.GetKeyDown(KeyCode.Space);
        if (jump)
		{
            character.Jump();
		}
    }
}
