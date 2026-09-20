using UnityEngine;

public class NpcParty : MonoBehaviour
{
    [SerializeField]private EnemyPokemon[] Party = new EnemyPokemon[6];
    private void Awake()
    {
        foreach (EnemyPokemon pokemon in Party)
        {
            if (pokemon != null && !string.IsNullOrEmpty(pokemon.Name))
            {
                pokemon.Initialize();
            }
        }
    }
    public EnemyPokemon GetFirstPokemon()
    {
        return Party[0];
    }
}
