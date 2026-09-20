using System;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private PlayerParty.PlayerPokemon playerPokemon;
    private EnemyPokemon enemyPokemon;

    
    private void PlayerAttack()
    {
        Debug.Log("플레이어 공격 차례");
    }

    private void EnemyAttack()
    {
        Debug.Log("적 공격 차례");
    }
    public void Start()
    {
        PlayerParty playerParty = FindFirstObjectByType<PlayerParty>();
        NpcParty npcParty = FindFirstObjectByType<NpcParty>();

        StartBattle(
            playerParty.GetFirstPokemon(),
            npcParty.GetFirstPokemon()
        );
    }
    public void StartBattle
       (PlayerParty.PlayerPokemon player,
        EnemyPokemon enemy)
        
    {
     
        playerPokemon = player;
        enemyPokemon = enemy;

        //스피드 비교
        if (playerPokemon.Speed > enemyPokemon.Speed)
        {
            PlayerAttack();
            Debug.Log(" player");
        }
        else if (playerPokemon.Speed < enemyPokemon.Speed)
        {
            EnemyAttack();
            Debug.Log("enemy");
        }
        else
        {
            System.Random random = new System.Random();

            // 0 이상 2 미만의 정수(0 또는 1)를 뽑습니다.
            int chance = random.Next(0, 2);

            if (chance == 0)
            {
                PlayerAttack();
            }
            else
            {
                EnemyAttack();
            }

            Debug.Log("same speed");
        }
    }
    


}
