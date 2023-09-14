using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class MovementScript : MonoBehaviour
{

    private CharacterController controller;
    public GameObject camera;

    [SerializeField] private float mSpeed = 5f;
    [SerializeField] private float cSpeed = 5f;

    private Vector2 playerInput;
    private Vector2 camerInput;

    private bool jump;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    [Header("Bullet Settings")]
    private bool shoot;
    [SerializeField] private float bulletSpeed = 10;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public void PlayerMove(InputAction.CallbackContext ctx)
    {
        playerInput = ctx.ReadValue<Vector2>();
    }

    public void PlayerJump(InputAction.CallbackContext ctx)
    {
        jump = ctx.action.triggered;
        Debug.Log(jump);
    }

    public void PlayerShoot(InputAction.CallbackContext ctx)
    {
        shoot = ctx.action.triggered;
    }

    public void CameraMove(InputAction.CallbackContext ctx)
    {
        camerInput = ctx.ReadValue<Vector2>().normalized;
        Debug.Log(camerInput);

    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
         groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector3 move = new Vector3(playerInput.x, playerVelocity.y, playerInput.y);
        controller.Move(move * Time.deltaTime * mSpeed);


       
        if (jump && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (shoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);

            Destroy(bullet, 3);

        }


    }

    public void MoveCamera(GameObject camera)
    {
       
       float angle = Mathf.Atan2(camerInput.y, camerInput.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    public void DebugClick()
    {
        Debug.Log("Click");
    }

}
    