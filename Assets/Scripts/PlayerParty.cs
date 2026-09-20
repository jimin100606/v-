using System.Collections.Generic;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerParty;

public class PlayerParty : MonoBehaviour
{
    public class PlayerPokemon
    {
        public PokemonData.Pokemon BaseData;

        public int Level = 5;
        public int CurrentExp = 0;
        public int CurrentHp;

        public int Attack;
        public int Defense;
        public int SpecialAttack;
        public int SpecialDefense;
        public int Speed;
    }
    private void Start()
    {
        PokemonData pokemonData = FindFirstObjectByType<PokemonData>();

        PokemonData.Pokemon pokemon =
            pokemonData.pokemonList.GetPokemonByName("Charmander");

        

        AddPokemon(pokemon);

       
    }
    private List<PlayerPokemon> PlayerPartyList = new List<PlayerPokemon>();
    private int maxCount = 6; // 최대 개수 제한
    private List<PlayerPokemon> PlayerBoxList = new List<PlayerPokemon>();
    private void AddPokemon(PokemonData.Pokemon pokemonData)
    {
        PlayerPokemon playerPokemon = new PlayerPokemon();
        playerPokemon.BaseData = pokemonData;

        ExpTable expTable = FindFirstObjectByType<ExpTable>();
        expTable.SetStats(playerPokemon);
        if (PlayerPartyList.Count < maxCount)
        {
            

            PlayerPartyList.Add(playerPokemon);
        }
        else
        {
            

            PlayerBoxList.Add(playerPokemon);
        }
        

    }
}
