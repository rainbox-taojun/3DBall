using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip pickupSound;

  // 触碰
	private void OnTriggerEnter(Collider other)
	{
        var player = other.GetComponent<PlayerCharacter>(); // 角色

        if (player)
		{
            player.AddCoin();
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
	}
}
