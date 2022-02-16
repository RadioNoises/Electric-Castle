using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBaseLogic : MonoBehaviour
{
    private MapManager mapManager;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        mapManager.AddTileToStorage(this.gameObject);
    }


}
