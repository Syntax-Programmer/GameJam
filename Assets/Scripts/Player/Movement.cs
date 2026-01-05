using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    private Vector3 playerVel = Vector3.zero;

    private void Update()
    {
        playerVel = Vector3.zero;

        FindMoveDir();
        MovePlayer();
    }

    private void FindMoveDir()
    {
        if (Keyboard.current.aKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed) { playerVel.x -= 1; }
        if (Keyboard.current.dKey.isPressed ||
            Keyboard.current.rightArrowKey.isPressed) { playerVel.x += 1; }
        if (Keyboard.current.wKey.isPressed ||
            Keyboard.current.upArrowKey.isPressed) { playerVel.y += 1; }
        if (Keyboard.current.sKey.isPressed ||
            Keyboard.current.downArrowKey.isPressed) { playerVel.y -= 1; }
    }

    private void MovePlayer()
    {
        playerVel.Normalize();
        transform.position += Time.deltaTime * playerSpeed * playerVel;
    }
}
