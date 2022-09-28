using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(_isItemUsed)
            {
                return;
            }
            else
            {
                _isItemUsed = true;
                GameManager.Instance.CurrentScore += 100;
                GameManager.Instance.UpdateScore.Invoke(GameManager.Instance.CurrentScore);
                _audio.PlayOneShot(ItemSoundEffect);
                _sprite.color = new Color(0, 0, 0, 0);
                Invoke("DisableObject", 2f);
            }
        }
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

}
