using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
    // Very simple object that handles placement of tiles in the game space

    // A temporary local GameObject to test tile placement TODO: remove this after testing
    // Start is called before the first frame update
    void Start()
    {
    }

    public void PlaceTile(GameObject tile, float x, float y)
    {
        Instantiate(tile, new Vector2(x, y), Quaternion.identity);
    }
}
