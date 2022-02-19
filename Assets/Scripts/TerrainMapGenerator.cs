using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TerrainMapGenerator : MonoBehaviour
{
    [Range(10, 500)]
    [SerializeField] public float MapSize = 50;
    [SerializeField] GameObject BaseTile;
    [SerializeField] GameObject Layer1Tile;
    [SerializeField] GameObject Layer2Tile;
    [SerializeField] GameObject Layer3Tile;
    [SerializeField] GameObject Layer4Tile;

    public List<GameObject> BlockTypes;

    public CinemachineVirtualCamera cm;

    public TilePlacer placer;

    public float NoiseScale = 1f;

    private float xOff;
    private float yOff;

    public GameObject CenterOfMap;

    Vector3 CenterV3;

    public void GenerateElevationData()
    {
        GameObject selection= BaseTile;
        for (float x = 0; x < MapSize; x++)
        {
            for (float y = 0; y < MapSize; y++)
            {
                float elevation = 100 * (Mathf.PerlinNoise((x+xOff)/(MapSize - 1) * NoiseScale, (y+yOff)/(MapSize -1) * NoiseScale));
                if (elevation < 30)
                {
                    selection = BaseTile;
                }
                if (elevation >= 30)
                {
                    selection = Layer1Tile;
                }
                if (elevation >= 40)
                {
                    selection = Layer2Tile;
                }
                if (elevation >= 60)
                {
                    selection = Layer3Tile;
                }
                if (elevation >= 80)
                {
                    selection = Layer4Tile;
                }
                placer.PlaceTile(selection, x, y);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MapSize = PlayerPrefs.GetFloat("mapSize");
        NoiseScale = PlayerPrefs.GetFloat("noiseScale");
        xOff = Random.Range(0,9999);
        yOff = Random.Range(0,9999);
        BlockTypes = new List<GameObject>();
        BlockTypes.Add(Layer1Tile);
        BlockTypes.Add(Layer2Tile);
        BlockTypes.Add(Layer3Tile);
        BlockTypes.Add(Layer4Tile);

        CenterV3 = new Vector3(MapSize / 2, MapSize / 2, -10);
        GenerateElevationData();
        Debug.Log("xOff: " + xOff*NoiseScale + "yOff: " + yOff*NoiseScale);

    }

    // Update is called once per frame
    void Update()
    {
        CenterOfMap.transform.position = new Vector3((MapSize/2)*1.0f, (MapSize/2*1.0f), -10);


    }
}
