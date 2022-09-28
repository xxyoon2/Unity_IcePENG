using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidItem : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip ItemSoundEffect;
    private SpriteRenderer _sprite;
    private bool _isItemUsed = false;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(_isItemUsed)
            {
                return;
            }
            else
            {
                _isItemUsed = true;
                _audio.PlayOneShot(ItemSoundEffect);
                _sprite.color = new Color(0,0,0,0);
                GameManager.Instance.MakeTimescaleFaster();
            }
        }
    }
}
