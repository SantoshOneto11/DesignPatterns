using UnityEngine;
namespace floatinIsland
{
    public class Grid : MonoBehaviour
    {
        private float scale = 0.1f;
        private float waterLevel = 0.4f;
        private int gridSize = 100;
        Cell[,] cells;

        private void Start()
        {
            float[,] noiseMap = new float[gridSize, gridSize];
            float xOffset = Random.Range(-1000, 1000);
            float yOffset = Random.Range(-1000, 1000);

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
                    if (cell.isWater)
                        Gizmos.color = Color.blue;
                    else
                        Gizmos.color = Color.green;

                    Vector3 pos = new Vector3(i, j, 0);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}
