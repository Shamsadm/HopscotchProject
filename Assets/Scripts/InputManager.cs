using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    InputSystem inputSystem;
    InputSystem.PlayerActions playerActions;
    bool check;
    public Vector2 movement;
    public static InputManager instance;


    private void Awake()
    {
        // creating a singleton pattern.
        if(instance!=null && instance!=this)
        {
            Destroy(instance);
        }
        else instance = this;
        // creating input system object
        inputSystem = new InputSystem();
        // assigning player actions 
        playerActions = inputSystem.Player;
        // assigning inputs
        playerActions.Movement.performed += ctx =>movement = ctx.ReadValue<Vector2>();
    }
    
    private void OnEnable()
    {
        inputSystem.Enable();
    }
    private void OnDisable()
    {
        inputSystem.Disable();
    }
}
