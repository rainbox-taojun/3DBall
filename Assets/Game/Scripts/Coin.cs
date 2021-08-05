using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip pickupSound;

	private void OnTriggerEnter(Collider other)
	{
        var player = other.GetComponent<PlayerCharacter>();

        if (player)
		{
            player.AddCoin();
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
	}
}
