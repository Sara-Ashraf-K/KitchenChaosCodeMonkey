using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
   public event EventHandler OnInteractAction;
   public event EventHandler OnInteractAlternateAction;

   private PlayerInputActions playerInputActions;

   private void Awake()
   {
      playerInputActions = new PlayerInputActions();
      playerInputActions.Player.Enable();

      playerInputActions.Player.Interact.performed += Interact_performed;
      playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
   }

    private void InteractAlternate_performed(InputAction.CallbackContext context)
    {
      OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
   {
      //anything before the question mark gets checked, and if it is null the rest of the line wont be executed,
      //if it is not null the rest of the line will be executed.
      OnInteractAction?.Invoke(this, EventArgs.Empty);
   }

   public Vector2 GetMovementVectorNormalized()
   {
      Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

      inputVector = inputVector.normalized;
      return inputVector;
   }
}
