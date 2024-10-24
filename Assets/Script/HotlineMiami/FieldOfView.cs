using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius = 5f; 
    [Range(0, 360)]
    public float viewAngle = 90f; 

    public Transform player; 
    public LayerMask playerLayer;

    private Mesh mesh;
    private MeshFilter meshFilter;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        CreateFieldOfViewMesh();
    }

    private void CreateFieldOfViewMesh()
    {
        int numOfVertices = 50; 
        Vector3[] vertices = new Vector3[numOfVertices + 1]; 
        int[] triangles = new int[(numOfVertices - 1) * 3]; 

        vertices[0] = Vector3.zero; 

        float angleIncrement = viewAngle / (numOfVertices - 1);


        for (int i = 0; i < numOfVertices; i++)
        {
            float currentAngle = -viewAngle / 2 + angleIncrement * i;
            Vector3 dir = DirFromAngle(currentAngle, false);
            vertices[i + 1] = dir * viewRadius;

            if (i < numOfVertices - 1)
            {

                triangles[i * 3] = 0;     
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }


    public Vector3 DirFromAngle(float angle, bool globalAngle)
    {
        if (!globalAngle)
        {
            angle += transform.eulerAngles.y; 
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }


    public bool IsPlayerInFieldOfView()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, player.position) < viewRadius)
        {
            float angleBetweenEnemyAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleBetweenEnemyAndPlayer < viewAngle / 2)
            {
                return true; 
            }
        }
        return false;
    }
}
