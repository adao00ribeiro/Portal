using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Moviment : MonoBehaviour
{
    [Header("Moviment,Jump,croush,sprint")]
    private float Speed = 5f;
    public float Walk = 3f;
    public float Run = 5f;
    public float crouchSpeed = 0.4f;
    public float jumpSpeed = 3.5f;
    public float CrouchHeight = 0.5f;

    private CharacterController CharacterController;
    private Vector3 moveDirection = Vector3.zero;
    private float directionY;
    private InputManager PInputManager;


    public InputManager InputManager
    {
        get
        {
            if (PInputManager == null)
            {
                PInputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
            }
            return PInputManager;
        }
    }
    Transform CameraTransform;
    private void Awake()
    {

        CharacterController = GetComponent<CharacterController>();
        CameraTransform = transform.Find("Main Camera");

    }

    public void EnableCharacterController()
    {
        CharacterController.enabled = true;
    }
    public void DisableCharacterController()
    {
        CharacterController.enabled = false;
    }
    public void UpdateMoviment()
    {
        if (CharacterController.enabled == false)
        {
            return;
        }
        Move();
        Jump();

    }
    private void Move()
    {
        moveDirection = new Vector3(InputManager.GetMoviment().x, 0, InputManager.GetMoviment().y);
        moveDirection = CameraTransform.forward * moveDirection.z + CameraTransform.right * moveDirection.x;
        Speed = Walk;
        Speed = InputManager.GetRun() ? Run : Speed;

        Speed = InputManager.GetCrouch() ? crouchSpeed : Speed;
        CharacterController.height = InputManager.GetCrouch() ? CrouchHeight : 1.8f;
        directionY += Physics.gravity.y * Time.deltaTime;
        moveDirection.y = directionY;
        CharacterController.Move(moveDirection * Speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (InputManager.GetIsJump() && CharacterController.isGrounded)
        {
            directionY = jumpSpeed;
        }
    }

    public bool CheckMovement()
    {
        if (InputManager.GetMoviment().x > 0 || InputManager.GetMoviment().x < 0 || InputManager.GetMoviment().y > 0 || InputManager.GetMoviment().y < 0)
        {
            return true;
        }
        return false;
    }
    public bool isGrounded()
    {
        return CharacterController.isGrounded;
    }

    public bool CheckIsRun()
    {
        return InputManager.GetRun();
    }
}
