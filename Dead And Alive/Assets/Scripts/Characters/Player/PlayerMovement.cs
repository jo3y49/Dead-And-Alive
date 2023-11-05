using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private Rigidbody rb;
    private InputActions actions;

    public float walkSpeed = 5;

    private void Awake() {
        actions = new InputActions();
    }

    private void OnEnable() {
        actions.Player.Enable();

        actions.Player.Movement.performed += MoveCharacter;
        actions.Player.Movement.canceled += StopCharacter;
    }

    private void OnDisable() {
        actions.Player.Movement.performed -= MoveCharacter;
        actions.Player.Movement.canceled -= StopCharacter;

        actions.Player.Disable();
    }

    private void MoveCharacter(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        // anim.SetBool("Moving", true);

        Vector3 moveDirection = -new Vector3(moveInput.x, 0, moveInput.y).normalized;

        transform.rotation = Quaternion.LookRotation(moveDirection);

        float speedToUse = walkSpeed;

        rb.velocity = moveDirection * speedToUse;
    }

    private void StopCharacter(InputAction.CallbackContext context)
    {
        rb.velocity = Vector3.zero;
    }

}