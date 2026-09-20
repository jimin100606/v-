using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private PlayerParty.PlayerPokemon playerPokemon;
    private EnemyPokemon enemyPokemon;

    public void StartBattle(
        PlayerParty.PlayerPokemon player,
        EnemyPokemon enemy)
    {
        playerPokemon = player;
        enemyPokemon = enemy;

       
    }
    

}
