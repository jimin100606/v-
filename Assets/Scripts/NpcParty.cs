using UnityEngine;

public class NpcParty : MonoBehaviour
{
    [SerializeField]private EnemyPokemon[] Party = new EnemyPokemon[6];
    private void Start()
    {
        foreach (EnemyPokemon pokemon in Party)
        {
            if (pokemon != null && !string.IsNullOrEmpty(pokemon.Name))
            {
                pokemon.Initialize();
            }
        }
    }
}
