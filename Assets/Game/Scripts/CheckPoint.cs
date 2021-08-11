using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public AudioClip checkPointSound;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();

        if (player)
        {
            player.controller.LevelComplete();
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(checkPointSound, transform.position);
        }
    }
}
