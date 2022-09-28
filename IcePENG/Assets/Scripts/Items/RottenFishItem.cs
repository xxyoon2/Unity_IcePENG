using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenFishItem : MonoBehaviour
{
    public AudioClip ItemSoundEffect;
    private AudioSource _audio;
    private SpriteRenderer _sprite;
    private bool _isItemUsed = false;

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
        if(_isItemUsed)
        {
            return;
        }
        else
        {
            _isItemUsed = true;
            _sprite.color = new Color(0, 0, 0, 0);
            _audio.PlayOneShot(ItemSoundEffect);
            other.transform.parent.gameObject.GetComponent<PlayerMovement>().Hit();
        }
    }
}
