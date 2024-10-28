using System.Collections;
using UnityEngine;

namespace floatinIsland
{
    public class Grid : MonoBehaviour
    {
        private float scale = 0.1f;
        private float waterLevel = 0.4f;
        private int gridSize = 100;
        private Vector3 gridCenterOffset;
        Cell[,] cells;

        public GameObject waterPrefab, landPrefab;

        private void Start()
        {
            gridCenterOffset = new Vector3(gridSize / 2f, gridSize / 2f, 0); // Calculate the center offset

            float[,] noiseMap = new float[gridSize, gridSize];
            float xOffset = Random.Range(-100, 100);
            float yOffset = Random.Range(-100, 100);

            for (int i = 0; i < noiseMap.GetLength(0); i++)
            {
                for (int j = 0; j < noiseMap.GetLength(1); j++)
                {
                    float noiseValue = Mathf.PerlinNoise(i * scale + xOffset, j * scale + yOffset);
                    noiseMap[i, j] = noiseValue;
                }
            }

            float[,] fallOffMap = new float[gridSize, gridSize];
            for (int i = 0; i < fallOffMap.GetLength(0); i++)
            {
                for (int j = 0; j < fallOffMap.GetLength(1); j++)
                {
                    float ix = i / (float)gridSize * 2 - 1;
                    float jx = j / (float)gridSize * 2 - 1;

                    float x = Mathf.Max(Mathf.Abs(ix), Mathf.Abs(jx));
                    fallOffMap[i, j] = Mathf.Pow(x, 3f) / (Mathf.Pow(x, 3f) + Mathf.Pow(2.2f - 2.2f * x, 3f));
                }
            }

            cells = new Cell[gridSize, gridSize];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Cell cell = new Cell();
                    float noiseValue = noiseMap[i, j];
                    noiseValue -= fallOffMap[i, j];
                    cell.isWater = noiseValue < waterLevel;
                    cells[i, j] = cell;
                }
            }

            StartCoroutine(SpawnCubesSlowly());
        }

        IEnumerator SpawnCubesSlowly()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Cell cell = cells[i, j];
                    Vector3 pos = new Vector3(i, j, 0) - gridCenterOffset; // Adjusted position with offset

                    GameObject prefab = cell.isWater ? waterPrefab : landPrefab;
                    Instantiate(prefab, pos, Quaternion.identity);

                    yield return new WaitForSeconds(0.01f); // Delay between each spawn for a slower effect
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                return;

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Cell cell = cells[i, j];
                    Vector3 pos = new Vector3(i, j, 0) - gridCenterOffset;

                    Gizmos.color = cell.isWater ? Color.blue : Color.green;
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}
