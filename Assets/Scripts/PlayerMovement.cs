using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gridSize = 1f;
    [SerializeField] private Tilemap tilemap;
   

    private Vector2Int currentTilePosition;
    private Vector2Int cellPosition;
    private Vector2Int targetTilePosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    
    

    private void Start()
    {
        currentTilePosition = (Vector2Int)tilemap.WorldToCell(transform.position);
        
    }
   
    //움직임 함수
    public void MoveToTile(Vector2Int newtargetTilePosition)
    {
        targetPosition =  tilemap.CellToWorld((Vector3Int)newtargetTilePosition);
        isMoving = true;

          
    }
    private void Update()
    {
        //움직임 구현
        if (isMoving == false)
        {
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
            else
                
            return;
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            transform.position = targetPosition;
            currentTilePosition = targetTilePosition;
            isMoving = false;
        }
        return;
    }
    
        
}
