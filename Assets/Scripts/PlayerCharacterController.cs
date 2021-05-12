using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour {
    MainCharacterInputActions inputActions;
    public float walkingSpeed = 5f;

    void Awake() {
        // create instance of actions once on Awake
        this.inputActions = new MainCharacterInputActions();
    }
    
    void OnEnable() {
        // enable input
        this.inputActions.Enable();
    }

    void OnDisable() {
        // Clean up everything in reverse order of OnEnable()
        this.inputActions.Disable();
    }

    // Option 3: read values anywhere else
    void FixedUpdate() {
        var movementInput = this.inputActions.Character.Move.ReadValue<Vector2>();
        var movement = movementInput * walkingSpeed * Time.fixedDeltaTime;
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(movement.x, 0f, movement.y, ForceMode.VelocityChange);
        var animator = GetComponent<Animator>();
        animator.SetFloat("X", rigidBody.velocity.x);
        animator.SetFloat("Y", rigidBody.velocity.z);
        //Debug.Log(movement);
    }
}