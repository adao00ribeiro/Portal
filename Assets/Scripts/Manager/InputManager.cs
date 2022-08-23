﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private GameObject gameobject;
    private PlayerControls playerControls;
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {

            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new PlayerControls();

    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetMoviment()
    {
        return playerControls.Player.Move.ReadValue<Vector2>();
    }
    public bool GetIsJump()
    {
        return playerControls.Player.Jump.triggered;
    }
    public bool GetInventory()
    {
        return playerControls.Player.Inventory.triggered;
    }
    public bool GetEsc()
    {
        return playerControls.Player.Esc.triggered;
    }
    public bool GetRun()
    {

        if (playerControls.Player.Run.ReadValue<float>() == 0)
        {
            return false;
        }

        return true;
    }
    public bool GetCrouch()
    {

        if (playerControls.Player.Crouch.ReadValue<float>() == 0)
        {
            return false;
        }

        return true;

    }
    public bool GetReload()
    {
        return playerControls.Player.Reload.triggered;
    }
    public bool GetLanterna()
    {
        return playerControls.Player.Lanterna.triggered;
    }
    public bool GetFire()
    {
        if (playerControls.Player.Fire.ReadValue<float>() == 0)
        {
            return false;
        }

        return true;

    }
    public bool GetFireModeSingle()
    {
        return playerControls.Player.FiremodeSingle.triggered;
    }
    public bool GetFireModeAuto()
    {
        return playerControls.Player.FiremodeAuto.triggered;
    }
    public bool GetUse()
    {
        return playerControls.Player.Use.triggered;
    }
    public bool GetAim()
    {
        if (playerControls.Player.Aim.ReadValue<float>() == 0)
        {
            return false;
        }

        return true;

    }
    public bool GetDropWeapon()
    {
        return playerControls.Player.DropWeapon.triggered;
    }
    public bool GetLeanLeft()
    {
        return playerControls.Player.LeanLeft.triggered;
    }
    public bool GetLeanRight()
    {
        return playerControls.Player.LeanRight.triggered;
    }
    internal Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
    internal Vector2 GetMousePosition()
    {
        return playerControls.Player.MousePosition.ReadValue<Vector2>();
    }

    #region ALPHAS
    public bool GetAlpha1()
    {
        return playerControls.Player.Alpha1.triggered;
    }
    public bool GetAlpha2()
    {
        return playerControls.Player.Alpha2.triggered;
    }
    public bool GetAlpha3()
    {
        return playerControls.Player.Alpha3.triggered;
    }
    public bool GetAlpha4()
    {
        return playerControls.Player.Alpha4.triggered;
    }
    public bool GetAlpha5()
    {
        return playerControls.Player.Alpha5.triggered;
    }
    public bool GetAlpha6()
    {
        return playerControls.Player.Alpha6.triggered;
    }
    public bool GetAlpha7()
    {
        return playerControls.Player.Alpha7.triggered;
    }
    public bool GetAlpha8()
    {
        return playerControls.Player.Alpha8.triggered;
    }
    public bool GetAlpha9()
    {
        return playerControls.Player.Alpha9.triggered;
    }
    #endregion
}
