using UnityEngine;
using UnityEngine.Tilemaps;
public class TilemapChecker : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;



    

    //통행가능한 일반 통로
    private class NormalTile
    {

    }

    //통행불가능(ex.물)
    private class NoEntryTile
    {

    }

    //인카운트 전투
    private class InCountBattleTile
    {

    }
}
