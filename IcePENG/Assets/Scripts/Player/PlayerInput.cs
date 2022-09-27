using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string RotateAxisName = "Horizontal";
    private string SpaceName = "PlayerJump";
    private string ControlName = "PlayerSlide";

    public float X { get; private set; }
    public bool IsPlayerJump { get; private set; }
    public bool IsPlayerSlide { get; private set; }

    void Update()
    {   
        X = 0f;
        IsPlayerJump = IsPlayerSlide = false;

        X = Input.GetAxis(RotateAxisName);
        IsPlayerJump = Input.GetButtonDown(SpaceName);
        IsPlayerSlide = Input.GetButton(ControlName);
    }
}