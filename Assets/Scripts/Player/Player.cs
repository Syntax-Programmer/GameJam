using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float playerSpeed = 10;
    
    [Header("Stats")]
    public int wealth = 0;
    public int repo = 50;
    public int food = 10;

    private int fate = 0;
    
    private Vector3 playerVel = new(0, 0, 0);

    [HideInInspector]
    public Vector3 MovementInput { get; private set; }

    private void Update()
    {
        playerVel = Vector3.zero;

        FindMoveDir();
        MovementInput = playerVel;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("NPC"))
    //    {
    //        Debug.Log("Player touched NPC");

    //        SpawnNPC npc = other.GetComponentInParent<SpawnNPC>();
    //        if (npc != null)
    //        {
    //            Debug.Log("NPC detected");
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.name);

        if (other.CompareTag("NPC"))
        {
            Debug.Log("Player collided with NPC");

            SpawnNPC npc = other.GetComponentInParent<SpawnNPC>();
            if (npc != null)
            {
                // interact with NPC here
            }
        }
    }

    private void FindMoveDir()
    {
        if (Keyboard.current.dKey.isPressed ||
            Keyboard.current.rightArrowKey.isPressed) { playerVel.x += 1; }
        playerVel *= Time.deltaTime * playerSpeed;
    }

    private void MovePlayer()
    {
        playerVel.Normalize();
        transform.position += Time.deltaTime * playerSpeed * playerVel;
    }
}
