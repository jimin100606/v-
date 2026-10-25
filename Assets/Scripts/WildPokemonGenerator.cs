using Unity.VisualScripting;
using UnityEngine;
using static PokemonData;

public class WildPokemonGenerator : MonoBehaviour
{
    [SerializeField] private string pokemonName = "Pikachu";
    [SerializeField] private int minLevel = 3;
    [SerializeField] private int maxLevel = 7;

    public EnemyPokemon GenerateWildPokemon()
    {
        
        EnemyPokemon wildPokemon = new EnemyPokemon();
        wildPokemon.Name = pokemonName;
        wildPokemon.Level = Random.Range(minLevel, maxLevel + 1);
        wildPokemon.Initialize();


        return wildPokemon;


    }
}
