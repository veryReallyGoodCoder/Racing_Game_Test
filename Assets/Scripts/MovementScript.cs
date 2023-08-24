using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class MovementScript : MonoBehaviour
{

    private CharacterController controller;
    [SerializeField] private float mSpeed = 5f;
    private Vector2 playerInput;

    public void PlayerMove(InputAction.CallbackContext ctx)
    {
        playerInput = ctx.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(playerInput.x, 0, playerInput.y);
        controller.Move(move * Time.deltaTime * mSpeed);

    }
}
