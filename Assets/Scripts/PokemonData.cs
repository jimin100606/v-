using UnityEngine;
using System.Collections.Generic;

public class PokemonData : MonoBehaviour
{
    public PokemonList pokemonList = new PokemonList();
    //포켓몬 이름 체력 공격 방어 스피드값 class
    public class Pokemon
    {
        public string Name;
        public int Level;
        public int BaseHp;
        public int BaseAttackDamage;
        public int BaseDefense;
        public int BaseSpecialAttackDamage;
        public int BaseSpecialDefense;
        public int BaseSpeed;

        public Pokemon(string name, int level, int hp, int attackDamage, int defense,int spa,int spd, int speed)
        {
            Name = name;
            Level = level;
            BaseHp = hp;
            BaseAttackDamage = attackDamage;
            BaseDefense = defense;
            BaseSpecialAttackDamage = spa;
            BaseSpecialDefense = spd;
            BaseSpeed = speed;
        }

       
    }
   public class PokemonList
    {
        //포켓몬 데이터 리스트
       public List<Pokemon> Pokemons = new List<Pokemon>();
        //AddPokemon으로 포켓몬 데이터 추가하기
        public void AddPokemon(string name, int level, int hp, int attackDamage, int defense,int spa, int spd, int speed)
        {
            Pokemons.Add(new Pokemon(name, level, hp, attackDamage, defense,spa,spd, speed));
        }
       
        //포켓몬 추가 하는곳
        public PokemonList()
        {
            AddPokemon("Pikachu", 1, 35, 55, 40, 50, 50, 90);
            AddPokemon("Charmander", 1, 39, 52, 43, 60 , 50, 65);



        }
        public Pokemon GetPokemonByName(string name)
        {
            foreach (Pokemon pokemon in Pokemons)
            {
                if (pokemon.Name == name)
                {
                    return pokemon;
                }
            }

            return null;
        }

    }
  

}
    



