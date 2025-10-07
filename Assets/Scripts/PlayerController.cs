using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    private Vector2 move;
    public Transform spawnPoint;
    public float fallThreshold = -5f;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
    void Update()
    {
        CheckFall();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
         transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

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
