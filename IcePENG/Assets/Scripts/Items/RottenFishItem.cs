using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenFishItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Player")
        {
            return;
        }
        
        other.GetComponent<PlayerMovement>().Hit();
        gameObject.SetActive(false);
    }
}
