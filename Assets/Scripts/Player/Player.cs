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
