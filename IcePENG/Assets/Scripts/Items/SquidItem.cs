using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidItem : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip ItemSoundEffect;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _audio.PlayOneShot(ItemSoundEffect);
            StartCoroutine(SquidEffect());
        }

        IEnumerator SquidEffect()
        {
            Time.timeScale = 1.5f;
            gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(4f);
            Time.timeScale = 1;
            yield break;
        }
    }
}
