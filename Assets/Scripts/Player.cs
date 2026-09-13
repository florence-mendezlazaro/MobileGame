using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputSystemActions isa;

    [Header("Player Properties")]
    [SerializeField] private float player_speed = 5f;
    private Rigidbody player_rb;
    private Vector2 player_input;
    
    [Header("Laser Stuff")]
    [SerializeField] private GameObject laser_prefab;
    [SerializeField] private Transform laser_spawn;


    private void Awake()
    {
        isa = new InputSystemActions();

        player_rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(player_input.x, player_input.y, 0f) * player_speed * Time.fixedDeltaTime;

        player_rb.MovePosition(player_rb.position + movement);
    }

    private void OnEnable()
    {
        isa.Enable();

        isa.Player.Move.performed += OnMove;
        isa.Player.Move.canceled += OnMove;

        isa.Player.Shoot.performed += OnShoot;
    }

    private void OnDisable()
    {
        isa.Player.Move.performed -= OnMove;
        isa.Player.Move.canceled -= OnMove;

        isa.Player.Shoot.performed -= OnShoot;

        isa.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        player_input = ctx.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext ctx)
    {
        GameObject laser = Instantiate(laser_prefab, laser_spawn.position, Quaternion.identity);
        laser.GetComponent<Laser>().SetLaserDirection(Vector3.up);
    }
}