using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TerrainMapGenerator : MonoBehaviour
{
    [Range(10, 500)]
    [SerializeField] int MapSize = 50;
    [SerializeField] GameObject BaseTile;
    [SerializeField] GameObject Layer1Tile;

    public TilePlacer placer;

    public float NoiseScale = 0.1f;

    GameObject go;

    public void GenerateElevationData()
    {
        //int[,] positions = new int[MapSize, MapSize];
        for (float x = 0; x < MapSize; x++)
        {
            for (float y = 0; y < MapSize; y++)
            {
                float elevation = 100 * (Mathf.PerlinNoise(x/(MapSize - 1) * NoiseScale, y/(MapSize -1) * NoiseScale));
                Debug.Log("elevation at " + x + "," + y + ": " + elevation);
                int random = Random.Range(1, 100);
                if (elevation >= 40.0f)
                {
                    placer.PlaceTile(Layer1Tile, x, y);
                    Debug.Log("tile placed");
                } else
                {
                    placer.PlaceTile(BaseTile, x, y);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateElevationData();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
