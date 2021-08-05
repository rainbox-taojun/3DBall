using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	Rigidbody rigid;
	public float speed;
	int coinCount = 0;
	bool isAlive = true;
	public AudioClip deadSound;

	void Awake()
	{
		rigid = GetComponent<Rigidbody>();
	}

	public void Move(Vector3 force)
	{
		rigid.AddForce(force * speed);
	}

	public void Jump()
	{
		if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
		{
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
		if (transform.position.y < -30)
		{
			if (isAlive)
			{
				Die();
			}
		}
	}

	void Die()
	{
		isAlive = false;
		AudioSource.PlayClipAtPoint(deadSound, transform.position);
	}
}
