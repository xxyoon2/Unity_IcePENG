using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlag : MonoBehaviour
{
    private bool _isItemUsed = false;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _renderer.color = new Color(0, 0, 0, 0);
            if (_isItemUsed)
            {
                return;
            }
            else
            {
                _isItemUsed = true;
                GameManager.Instance.PlayGame(true);
                MakeObjectsActiveFalse();
            }
        }
        else
        {
            return;
        }
    }

    private void MakeObjectsActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
