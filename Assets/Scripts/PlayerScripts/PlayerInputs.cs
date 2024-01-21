using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputs : MonoBehaviour
{
    public static PlayerInputs Instance { get; private set; }

    private PlayerInputActions _playerInputs;
    public event EventHandler jumpPerformed;
    public event EventHandler placeBuildingPerformed;
    public event EventHandler escapePerformed;
    public event EventHandler moveDownPerformed;

    public event EventHandler button1Performed;
    public event EventHandler button2Performed;
    public event EventHandler button3Performed;
    public event EventHandler button4Performed;
    public event EventHandler button5Performed;



    private void Awake()
    {
        Instance = this;
        _playerInputs = new PlayerInputActions();
        _playerInputs.PlayerActions.Enable();
        _playerInputs.PlayerActions.Jump.performed += Jump_performed;
        _playerInputs.PlayerActions.Escape.performed += Escape_performed;
        _playerInputs.PlayerActions.PlaceBuilding.performed += PlaceBuilding_performed;
        _playerInputs.PlayerActions.MoveDown.performed += MoveDown_performed;
        _playerInputs.PlayerActions.Button1.performed += Button1_performed;
        _playerInputs.PlayerActions.Button2.performed += Button2_performed;
        _playerInputs.PlayerActions.Button3.performed += Button3_performed;
        _playerInputs.PlayerActions.Button4.performed += Button4_performed;
        _playerInputs.PlayerActions.Button5.performed += Button5_performed;
    }

    private void Button5_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        button5Performed?.Invoke(this, EventArgs.Empty);
    }

    private void Button4_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        button4Performed?.Invoke(this, EventArgs.Empty);
    }

    private void Button3_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        button3Performed?.Invoke(this, EventArgs.Empty);
    }

    private void Button2_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        button2Performed?.Invoke(this, EventArgs.Empty);
    }

    private void Button1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        button1Performed?.Invoke(this, EventArgs.Empty);
    }

    private void MoveDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveDownPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void PlaceBuilding_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        placeBuildingPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Escape_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        escapePerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        jumpPerformed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 playerMovement = _playerInputs.PlayerActions.Movements.ReadValue<Vector2>();
        playerMovement = playerMovement.normalized;

        return playerMovement;
    }

    private void OnDestroy()
    {
        _playerInputs.PlayerActions.Jump.performed -= Jump_performed;
        _playerInputs.PlayerActions.Escape.performed -= Escape_performed;
        _playerInputs.PlayerActions.PlaceBuilding.performed -= PlaceBuilding_performed;
        _playerInputs.PlayerActions.MoveDown.performed -= MoveDown_performed;
        _playerInputs.PlayerActions.Button1.performed -= Button1_performed;
        _playerInputs.PlayerActions.Button2.performed -= Button2_performed;
        _playerInputs.PlayerActions.Button3.performed -= Button3_performed;
        _playerInputs.PlayerActions.Button4.performed -= Button4_performed;
        _playerInputs.PlayerActions.Button5.performed -= Button5_performed;
        
    }
}
