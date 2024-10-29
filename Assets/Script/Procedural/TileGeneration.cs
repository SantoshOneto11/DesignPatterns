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

        [SerializeField]
        private float heightMultiplier;

        [SerializeField]
        private AnimationCurve heightCurve;

        [SerializeField]
        private Wave[] waves;

        private void Start()
        {
            GenerateTiles();
        }

        void GenerateTiles()
        {
            Vector3[] meshVertices = this.meshFilter.mesh.vertices;
            int tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
            int tileWidth = tileDepth;

            float offsetX = -this.gameObject.transform.position.x;
            float offsetZ = -this.gameObject.transform.position.z;

            float[,] heightMap = this.noiseMapGeneration.GenerateNoiseMap(tileDepth, tileWidth, this.mapScale, offsetX, offsetZ, waves);

            UpdateMeshVerticies(heightMap);
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

                    TerrainType terrainType = ChooseTerrainType(height);

                    colorMap[colorIndex] = terrainType.color;
                }
            }

            Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
            tileTexture.wrapMode = TextureWrapMode.Clamp;
            tileTexture.SetPixels(colorMap);
            tileTexture.Apply();

            return tileTexture;
        }

        TerrainType ChooseTerrainType(float height)
        {
            foreach (TerrainType terrainType in terrainType)
            {
                if (height < terrainType.height)
                {
                    return terrainType;
                }
            }
            return terrainType[terrainType.Length - 1];
        }

        private void UpdateMeshVerticies(float[,] heightMap)
        {
            int tileDepth = heightMap.GetLength(0);
            int tileWidth = heightMap.GetLength(1);

            Vector3[] meshVerticies = this.meshFilter.mesh.vertices;

            int vertexIndex = 0;

            for (int zIndex = 0; zIndex < tileDepth; zIndex++)
            {
                for (int xIndex = 0; xIndex < tileWidth; xIndex++)
                {
                    float height = heightMap[zIndex, xIndex];
                    Vector3 vertex = meshVerticies[vertexIndex];

                    meshVerticies[vertexIndex] = new Vector3(vertex.x, this.heightCurve.Evaluate(height) * heightMultiplier, vertex.z);

                    vertexIndex++;
                }
            }

            this.meshFilter.mesh.vertices = meshVerticies;
            this.meshFilter.mesh.RecalculateBounds();
            this.meshFilter.mesh.RecalculateNormals();

            this.meshCollider.sharedMesh = this.meshFilter.mesh;
        }
    }
}
