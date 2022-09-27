using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshFishItem : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip ItemSoundEffect;
    private SpriteRenderer _sprite;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Player")
        {
            return;
        }
        
        _audio.PlayOneShot(ItemSoundEffect);
        _sprite.color = new Color(0, 0, 0, 0);
        other.transform.parent.gameObject.GetComponent<PlayerMovement>().Heal();
    }
}
