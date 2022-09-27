using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidItem : MonoBehaviour
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
        if(collision.gameObject.tag == "Player")
        {
            _audio.PlayOneShot(ItemSoundEffect);
            _sprite.color = new Color(0,0,0,0);
            StartCoroutine(SquidEffect());
        }

        IEnumerator SquidEffect()
        {
            Time.timeScale = 1.5f;
            yield return new WaitForSecondsRealtime(4f);
            gameObject.SetActive(false);
            Time.timeScale = 1;
            yield break;
        }
    }
}
