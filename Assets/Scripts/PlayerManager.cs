using System.Threading;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player;
    public Transform flashlight;
    public float playerSpeed;
    private Vector2 moveDir = Vector2.zero;
    private Vector2 lastMoveDir = Vector2.down;
    public float timer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.01f)
        {
            timer -= 0.01f;
            PlayerMove();
        }
    }

    void PlayerMove()
    {
        Vector3 playerPos = player.transform.position;
        moveDir = Vector2.zero;

        // Combine input directions
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir.x = -1;
            player.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDir.x = 1;
            player.transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDir.y = 1;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
            
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDir.y = -1;
            player.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        // Normalize diagonal speed (so diagonals aren’t faster)
        if (moveDir.magnitude > 0)
        {
            moveDir.Normalize();
            lastMoveDir = moveDir; // remember direction
        }

        // Move player
        playerPos += (Vector3)(moveDir * playerSpeed);
        player.transform.position = playerPos;

        // Rotate flashlight toward last move direction
        if (flashlight != null)
        {
            float angle = Mathf.Atan2(lastMoveDir.y, lastMoveDir.x) * Mathf.Rad2Deg;
            flashlight.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}
