using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenFishItem : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip ItemSoundEffect;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Player")
        {
            return;
        }

        _audio.PlayOneShot(ItemSoundEffect);
        other.transform.parent.gameObject.GetComponent<PlayerMovement>().Hit();
        gameObject.SetActive(false);
    }
}
