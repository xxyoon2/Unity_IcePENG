using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string SpaceName = "PlayerJump";

    public bool IsPlayerJump { get; private set; }

    void Update()
    {
        IsPlayerJump = false;

        IsPlayerJump = Input.GetButtonDown(SpaceName);
    }
}