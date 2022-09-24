using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string RotateAxisName = "Horizontal";
    private string SpaceName = "PlayerJump";

    public float X { get; private set; }
    public bool IsPlayerJump { get; private set; }

    void Update()
    {   
        X = 0f;
        IsPlayerJump = false;

        X = Input.GetAxis(RotateAxisName);
        IsPlayerJump = Input.GetButtonDown(SpaceName);
    }
}