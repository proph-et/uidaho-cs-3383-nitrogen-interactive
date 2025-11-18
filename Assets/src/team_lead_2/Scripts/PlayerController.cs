using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IBCMode
{
    [Header("Random Shit")] Rigidbody rb;
    private Animator _animator;
    private Ability currentAbility;

    [Header("Movement Settings")] public float speed;
    [SerializeField] private Vector2 move;

    [Header("Respawn Settings")] private Transform spawnPoint;
    private float fallThreshold = -5f;

    [Header("Dash Settings")] [SerializeField]
    private float dashSpeed;

    [SerializeField] public float dashDuration;
    [SerializeField] public float dashCooldown;
    private Ability dashAbility;

    [Header("Attack Settings")]
    [SerializeField] private GameObject rightArm;

    [SerializeField] private float attackDuration;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackDamage;
    private Ability attackAbility;

    [Header("Health Settings")]
    [SerializeField] private Health _health;
    private bool isInvincible = false;
    private bool bcMode = false;

    // ------------------
    // Input Events
    // -------------------

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            dashAbility.Activate(gameObject);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            attackAbility.Activate(gameObject);
        }
    }

    // ---------------
    // Unity Functions
    // -----------------

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _health = GetComponent<Health>();
        _animator = GetComponentInChildren<Animator>();

        dashAbility = new DashAbility(this, dashSpeed, dashDuration, dashCooldown);
        attackAbility = new AttackAbility(this, attackDamage, attackRange, attackDuration, attackCooldown);

        _health.AddOnDeathListener(OnDeath);
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        CheckFall();
        if (Keyboard.current.bKey.wasPressedThisFrame) ToggleBCMode();
    }

    /// -----------------
    /// Core Movement
    /// -----------------
    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        Vector2 tilt = GetTiltInput();

        if (tilt != Vector2.zero)
        {
            movement = new Vector3(tilt.x, 0f, tilt.y);
        }

        bool isMoving = movement.sqrMagnitude > 0.001f;

        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);

            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        if (_animator != null)
        {
            _animator.SetBool("isRunning", isMoving);
        }
    }


    ///------------
    /// Tilt Controls
    /// ------------- 
    private Vector2 GetTiltInput()
    {
        Vector3 accel = Input.acceleration;


        Vector2 tilt = new Vector2(accel.x, accel.y);

        if (tilt.magnitude < 0.15f)
        {
            tilt = Vector2.zero;
        }

        float sensitivity = 2.0f;
        tilt *= sensitivity;

        return tilt;
    }

    /// -----------------
    /// The below allow abilities like DashAbility to toggle i-frames.
    /// -------------------
    public void SetInvincible(bool value)
    {
        isInvincible = value;
    }

    public bool IsInvincible()
    {
        return bcMode;
    }

    /// ---------------
    /// Respawn stuff
    /// -----------------
    public void CheckFall()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        Debug.Log("Player has fallen through the map.... respawning player.");
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
        else
        {
            transform.position = new Vector3(0, 1, 0);
        }

        _health.Heal(_health.GetMaxHealth(), respawning: true);
    }

    private void OnDeath()
    {
        Debug.Log("Player had died");
        Respawn();
    }

    ///-----------
    /// BC Mode stuff
    /// ---------
    public void ToggleBCMode()
    {
        bcMode = !bcMode;
        Debug.Log("BC Mode = " + (bcMode ? "ON" : "OFF"));
    }
}
