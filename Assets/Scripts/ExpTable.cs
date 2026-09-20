using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using static PokemonData;

public class ExpTable : MonoBehaviour
{
    public int GetNeedExp(int level)
    {
        return level * 100;
    }

    public int GetStat(int baseStat, int level)
    {
        return (2 * baseStat * level) / 100 + 5;
    }
    public int GetHp(int baseHP, int level)
    {
        return (2 * baseHP * level) / 100 + level + 10;
    }

    public void SetStats(PlayerParty.PlayerPokemon pokemon)
    {
        pokemon.CurrentHp = GetHp(pokemon.BaseData.BaseHp, pokemon.Level);
        pokemon.Attack = GetStat(pokemon.BaseData.BaseAttackDamage, pokemon.Level);
        pokemon.Defense = GetStat(pokemon.BaseData.BaseDefense, pokemon.Level);
        pokemon.SpecialAttack = GetStat(pokemon.BaseData.BaseSpecialAttackDamage, pokemon.Level);
        pokemon.SpecialDefense = GetStat(pokemon.BaseData.BaseSpecialDefense, pokemon.Level);
        pokemon.Speed = GetStat(pokemon.BaseData.BaseSpeed, pokemon.Level);

        Debug.Log(
        pokemon.BaseData.Name +
        " Lv." + pokemon.Level +
        " HP:" + pokemon.CurrentHp +
        " 공격:" + pokemon.Attack +
        " 방어:" + pokemon.Defense +
        " 특공:" + pokemon.SpecialAttack +
        " 특방:" + pokemon.SpecialDefense +
        " 스피드:" + pokemon.Speed
        );
    }
}