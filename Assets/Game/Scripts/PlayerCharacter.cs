using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	Rigidbody rigid;// 刚体
	public float speed;// 速度
	int coinCount = 0;
	bool isAlive = true;
	public AudioClip deadSound;

	public PlayerController controller;

	void Awake()
	{
		rigid = GetComponent<Rigidbody>();// 获取刚体组件
		controller = FindObjectOfType<PlayerController>();// 获取角色控制器
	}

  // 移动方法
	public void Move(Vector3 force)
	{
		rigid.AddForce(force * speed); // 施加力 * 速度
	}

  // 跳跃方法
	public void Jump()
	{
    // 通过向下的射线检测下方物体和角色的距离是否超过0.6f(角色半径)
		if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
		{
      // 角色在地面上 施加向上的里 ForceMode.Impulse表示瞬间执行
			rigid.AddForce(Vector3.up * 8f, ForceMode.Impulse);
		}
	}
	public void AddCoin()
	{
		coinCount++;
		Debug.Log(coinCount);
	}

	public int GetCoinCount()
	{
		return coinCount;
	}

	private void Update()
	{
    // 角色高度低于-30 则死亡
		if (transform.position.y < -30)
		{
			if (isAlive && controller.mode.GetGameState() == false)
			{
				Die();
			}
		}
	}

	void Die()
	{
		isAlive = false;
		AudioSource.PlayClipAtPoint(deadSound, transform.position); // 播放死亡音效
		controller.ShowGameoverPanel(); // 打开ui面板
	}
}
