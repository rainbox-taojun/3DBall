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
        character = FindObjectOfType<PlayerCharacter>(); // 角色对象
        playerCamera = FindObjectOfType<PlayerCamera>(); // 相机对象
        hud = FindObjectOfType<PlayerHUD>();
        mode = FindObjectOfType<GameMode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode.GetGameState() == true) return; // 游戏状态为true表示已结束,停止角色控制
        var h = Input.GetAxis("Horizontal");// 水平输入
        var v = Input.GetAxis("Vertical");// 高度输入

        var cameraTrans = playerCamera.cameraComponent.transform; // 得到相机的视角
        var movement = (v * cameraTrans.forward + h * cameraTrans.right).normalized; // 水平输入 * 相机方向 + 高度输入*相机的角度
        movement.y = 0; // y值归零
        character.Move(movement); // 执行角色移动方法

        var jump = Input.GetKeyDown(KeyCode.Space);// 跳跃键
        if (jump)
		{
            character.Jump(); // 执行角色跳跃方法
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
