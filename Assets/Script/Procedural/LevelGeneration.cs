using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField]
    private int mapWidthInTile, mapDepthInTile;

    [SerializeField]
    private GameObject tilePrefab;

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        Vector3 tileSize = tilePrefab.GetComponent<MeshRenderer>().bounds.size;
        int tileWidth = (int)tileSize.x;
        int tileDepth = (int)tileSize.z;

        for (int xIndex = 0; xIndex < mapWidthInTile; xIndex++)
        {
            for (int zIndex = 0; zIndex < mapDepthInTile; zIndex++)
            {
                Vector3 tilePosition = new Vector3(this.gameObject.transform.position.x + xIndex * tileWidth,
                    this.gameObject.transform.position.y,
                    this.gameObject.transform.position.z + zIndex * tileDepth);

                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as GameObject;
            }
        }
    }
}
