using UnityEngine;

namespace ProceduralMap
{
    public class TileGeneration : MonoBehaviour
    {
        [SerializeField]
        NoiseMapGeneration noiseMapGeneration;

        [SerializeField]
        private MeshRenderer tileRenderer;

        [SerializeField]
        private MeshFilter meshFilter;

        [SerializeField]
        private MeshCollider meshCollider;

        [SerializeField]
        private float mapScale;

        [SerializeField]
        private TerrainType[] terrainType;

        private void Start()
        {
            GenerateTiles();
        }

        void GenerateTiles()
        {
            Vector3[] meshVertices = this.meshFilter.mesh.vertices;
            int tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
            int tileWidth = tileDepth;

            float[,] heightMap = this.noiseMapGeneration.GenerateNoiseMap(tileDepth, tileWidth, this.mapScale);

            Texture2D tileTexture = BuildTexture(heightMap);
            this.tileRenderer.material.mainTexture = tileTexture;
        }

        private Texture2D BuildTexture(float[,] heightMap)
        {
            int tileDepth = heightMap.GetLength(0);
            int tileWidth = heightMap.GetLength(1);

            Color[] colorMap = new Color[tileDepth * tileWidth];

            for (int xIndex = 0; xIndex < tileDepth; xIndex++)
            {
                for (int zIndex = 0; zIndex < tileWidth; zIndex++)
                {
                    int colorIndex = zIndex * tileWidth + xIndex;
                    float height = heightMap[zIndex, xIndex];

                    colorMap[colorIndex] = Color.Lerp(Color.black, Color.white, height);
                }
            }

            Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
            tileTexture.wrapMode = TextureWrapMode.Clamp;
            tileTexture.SetPixels(colorMap);
            tileTexture.Apply();

            return tileTexture;
        }
    }
}
