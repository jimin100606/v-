using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gridSize = 1f;
    [SerializeField] private Tilemap tilemap;

    private Vector2Int currentTilePosition;
    private Vector2Int targetTilePosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Rigidbody2D rb;
    private KeyCode blockedKey = KeyCode.None;

    private void Start()
    {
        currentTilePosition = (Vector2Int)tilemap.WorldToCell(transform.position);
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveToTile(Vector2Int newTargetTilePosition)
    {
        targetPosition = tilemap.CellToWorld(
            (Vector3Int)newTargetTilePosition
        );

        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
            return;
        if (blockedKey != KeyCode.None && !Input.GetKey(blockedKey))
        {
            blockedKey = KeyCode.None;
        }

        targetTilePosition = currentTilePosition;

        if (Input.GetKey(KeyCode.W))
        {
            targetTilePosition.y += 1;
            MoveToTile(targetTilePosition);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetTilePosition.x -= 1;
            MoveToTile(targetTilePosition);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetTilePosition.y -= 1;
            MoveToTile(targetTilePosition);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetTilePosition.x += 1;
            MoveToTile(targetTilePosition);
        }
    }

    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        Vector2 newPosition = Vector2.MoveTowards(
            rb.position,
            targetPosition,
            moveSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPosition);

        if (Vector2.Distance(newPosition, targetPosition) < 0.01f)
        {
            rb.MovePosition(targetPosition);
            currentTilePosition = targetTilePosition;
            isMoving = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = Vector2.zero;

        if (targetTilePosition.x > currentTilePosition.x)
            blockedKey = KeyCode.D;
        else if (targetTilePosition.x < currentTilePosition.x)
            blockedKey = KeyCode.A;
        else if (targetTilePosition.y > currentTilePosition.y)
            blockedKey = KeyCode.W;
        else if (targetTilePosition.y < currentTilePosition.y)
            blockedKey = KeyCode.S;

        targetTilePosition = currentTilePosition;
        targetPosition = tilemap.GetCellCenterWorld(
            (Vector3Int)currentTilePosition
        );

        rb.position = targetPosition;
        isMoving = false;
    }

}
