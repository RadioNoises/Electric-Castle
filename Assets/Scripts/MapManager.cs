using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<Vector3, GameObject> TileRefStorage;

    private float gridMovementOffset = 0.3f;

    public void AddTileToStorage (GameObject tile)
    {
        TileRefStorage.Add(tile.transform.position, tile);
    }

    public bool CheckTravesability(Vector3 targetloc)
    {
        foreach (KeyValuePair<Vector3, GameObject> currentloc in TileRefStorage)
        {
            if (
            (targetloc.x - gridMovementOffset <= currentloc.Key.x &&
            targetloc.x + gridMovementOffset >= currentloc.Key.x) &&
            (targetloc.y - gridMovementOffset <= currentloc.Key.y &&
            targetloc.y + gridMovementOffset >= currentloc.Key.y) &&
            (targetloc.z - gridMovementOffset <= currentloc.Key.z &&
            targetloc.z + gridMovementOffset >= currentloc.Key.z)
            )
            {
                foreach (TileData currentTileData in tileDatas)
                {
                    if (currentTileData.tiles != null)
                        foreach (GameObject currentTile in currentTileData.tiles)
                        {
                            if (GameObject.ReferenceEquals(currentTile, currentloc.Value))
                                return currentTileData.traversable;
                        }
                }
            }
            else
            {
                Debug.Log("Traversability check received wrong coordinates.");
                return false;
            }
        }
        return false;
    }

}
