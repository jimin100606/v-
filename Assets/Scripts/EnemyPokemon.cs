using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.Overlays;
using UnityEngine;




    [System.Serializable]
    public class EnemyPokemon
    {
        public PokemonData.Pokemon BaseData;
        public string Name;
        public int Level;
        public int CurrentHp;
        public int Attack;
        public int Defense;
        public int SpecialAttack;
        public int SpecialDefense;
        public int Speed;

    public void Initialize()
    {
        PokemonData pokemonData = Object.FindFirstObjectByType<PokemonData>();

        BaseData = pokemonData.pokemonList.GetPokemonByName(Name);

        if (BaseData == null)
        {
            Debug.LogError("포켓몬을 찾을 수 없습니다: " + Name);
            return;
        }
       

        ExpTable expTable = Object.FindFirstObjectByType<ExpTable>();

        CurrentHp = expTable.GetHp(BaseData.BaseHp, Level);
        Attack = expTable.GetStat(BaseData.BaseAttackDamage, Level);
        Defense = expTable.GetStat(BaseData.BaseDefense, Level);
        SpecialAttack = expTable.GetStat(BaseData.BaseSpecialAttackDamage, Level);
        SpecialDefense = expTable.GetStat(BaseData.BaseSpecialDefense, Level);
        Speed = expTable.GetStat(BaseData.BaseSpeed, Level);
    }
}



