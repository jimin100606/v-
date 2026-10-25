using UnityEngine;

// Encounter Tile에서 포켓몬이 나올 확률을 구하는 스크립트
public class EncounterChance : MonoBehaviour
{
    [SerializeField] private int encounterPercent = 50;

    public bool ChanceEncounter()
    {
        if (Random.Range(0, 100) < encounterPercent)
        {
            return true;
            
        }
        else
        {
            return false;
            
        }
    }
}
