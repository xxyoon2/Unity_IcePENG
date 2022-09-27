using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip ItemSoundEffect;
    private SpriteRenderer _sprite;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.CurrentScore += 100;
            _audio.PlayOneShot(ItemSoundEffect);
            _sprite.color = new Color(0, 0, 0, 0);
            Invoke("DisableObject", 2f);
        }
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

}
