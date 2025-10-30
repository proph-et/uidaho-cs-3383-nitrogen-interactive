using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Random Shit")]
    Rigidbody rb;

    [Header("Movement Settings")]
    public float speed;
    [SerializeField] private Vector2 move;

    [Header("Respawn Settings")]
    public Transform spawnPoint;
    public float fallThreshold = -5f;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 16f; //Double Player movement speed
    [SerializeField] public float dashDuration = .2f;
    [SerializeField] public float dashCooldown = 1.0f;
    private bool isDashing = false;
    private bool canDash = true;
    private bool isInvincible = false;
    private Ability currentAbility;

    [Header("Attack Settings")]
    [SerializeField] private GameObject rightArm;
    [SerializeField] private float attackDuration = .1f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 0.2f;
    [SerializeField] private int attackDamage = 10;
    private bool canAttack = true;



    // ------------------
    // Input Events
    // -------------------


    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            currentAbility.Activate(gameObject);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed && canAttack)
        {
            Debug.Log("Player is attacking");
            StartCoroutine(BasicAttack());
        }
    }

    // ---------------
    // Unity Functions
    // -----------------
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentAbility = new DashAbility(dashSpeed, dashDuration);
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            MovePlayer();
        }
    }
    void Update()
    {
        CheckFall();
    }


    /// -----------------
    /// Core Movement
    /// -----------------
    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    ///-------------------------
    /// iFrames/Dash Function
    /// ----------------------

    public IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        isInvincible = true;

        Vector3 dashDirection = transform.forward;

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(dashDirection * dashSpeed, ForceMode.VelocityChange);


        //My attempt at iFrames (shooting for about 11 which seems to be industry standardish)
        yield return new WaitForSeconds(0.18f);
        isInvincible = false;

        yield return new WaitForSeconds(dashDuration - 0.18f);
        rb.linearVelocity = Vector3.zero;
        isDashing = false;

        //Dash Cooldown
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    /// ---------
    /// Public "getter" function for the private Dash function 
    /// for use for enemies, Health, etc
    /// -------------------

    public bool IsInvincible()
    {
        return isInvincible;
    }
    
    /// -----------------
    /// Attack Function
    /// ------------------
    
    private IEnumerator BasicAttack()
    {
        canAttack = false;
        rightArm.SetActive(true);

        Vector3 attackDirection = transform.forward;
        Debug.Log($"Attacking in Direction: { attackDirection}");

        RaycastHit[] hits = Physics.SphereCastAll(transform.position +
        transform.forward,
        0.5f,
        transform.forward, attackRange);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.transform == transform) continue;
                Debug.Log($"Hit {hit.transform.name}! Dealt {attackDamage} damage");
            }
        }
        else
        {
            Debug.Log("No targets hit.");
        }
        
        yield return new WaitForSeconds(attackDuration);
        rightArm.SetActive(false);

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
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
    }
}
