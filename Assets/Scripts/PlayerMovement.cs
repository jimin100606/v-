using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gridSize = 1f;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tilemap encounterTilemap;
    [SerializeField] private EncounterChance encounterChance;
    [SerializeField] private WildPokemonGenerator wildPokemonGenerator;

    private Vector2Int currentTilePosition;
    private Vector2Int targetTilePosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Rigidbody2D rb;
    private RaycastHit2D[] castHits = new RaycastHit2D[8];
    private KeyCode blockedKey = KeyCode.None;

    private void Start()
    {
        currentTilePosition = (Vector2Int)tilemap.WorldToCell(transform.position);
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveToTile(Vector2Int newTargetTilePosition)
    {
        Vector3 destination = tilemap.GetCellCenterWorld(
            (Vector3Int)newTargetTilePosition
        );

        Vector2 difference = (Vector2)destination - rb.position;
        float distance = difference.magnitude;

        if (distance < 0.01f)
            return;

        // 플레이어의 Collider로 이동 경로 확인
        int hitCount = rb.Cast(
            difference.normalized,
            castHits,
            distance
        );

        // 앞에 충돌할 물체가 있으면 이동 시작 안 함
        if (hitCount > 0)
            return;

        targetTilePosition = newTargetTilePosition;
        targetPosition = destination;
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
            if (encounterTilemap != null &&
     encounterTilemap.HasTile((Vector3Int)currentTilePosition))
            {
                if(encounterChance.ChanceEncounter())
                {
                    EnemyPokemon wildPokemon = wildPokemonGenerator.GenerateWildPokemon();
                    Debug.Log(
    $"야생 포켓몬 출현!\n" +
    $"이름: {wildPokemon.Name}\n" +
    $"레벨: {wildPokemon.Level}\n" +
    $"HP: {wildPokemon.CurrentHp}\n" +
    $"공격력: {wildPokemon.Attack}\n" + 
    $"방어력: {wildPokemon.Defense}\n" +
    $"특수공격: {wildPokemon.SpecialAttack}\n" +
    $"특수방어: {wildPokemon.SpecialDefense}\n" +
    $"스피드: {wildPokemon.Speed}");

                    BattleManager battleManager = FindFirstObjectByType<BattleManager>();
                    battleManager.StartWildBattle(wildPokemon);
                }

            }

        }
    }
    

}
