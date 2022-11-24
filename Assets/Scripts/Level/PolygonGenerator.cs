using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonGenerator : MonoBehaviour
{
    public List<Vector3> newVertices = new List<Vector3>();
    public List<int> newTriangles = new List<int>();
    public List<Vector2> newUV = new List<Vector2>();

    public List<Vector3> colVertices = new List<Vector3>();
    public List<int> colTriangles = new List<int>();
    private int colCount;

    private Mesh mesh;
    private MeshCollider col;

    private float tUnit = 0.25f;
    private Vector2 tStone = new Vector2(0, 0);
    private Vector2 tSoil = new Vector2(0, 1);
    private Vector2 tSnow = new Vector2(0, 2);
    private Vector2 tMetal = new Vector2(1, 0);
    private Vector2 tWood = new Vector2(0, 3);
    private Vector2 tBush = new Vector2(1, 2);
    private Vector2 tIce = new Vector2(1, 1);
    private Vector2 tWorkbench = new Vector2(1, 3);
    private Vector2 tChair = new Vector2(2, 3);
    private Vector2 tTable = new Vector2(3, 3);

    public byte[,] blocks;
    private int squareCount;

    public bool update = false;

    // Start is called before the first frame update
    void Start()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        mesh = GetComponent<MeshFilter>().mesh;
        col = GetComponent<MeshCollider>();

        GenTerrain();
        BuildMesh();
        UpdateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (update) {
            BuildMesh();
            UpdateMesh();
            update = false;
            print(blocks);
        }
    }
    int Noise (int x, int y, float scale, float mag, float exp)
    {
        return (int)(Mathf.Pow((Mathf.PerlinNoise(x / scale, y / scale) * mag), (exp)));
    }
    void GenTerrain()
    {
        blocks = new byte[595, 34];

        for (int px = 0; px < blocks.GetLength(0); px++) {
            int stone = Noise(px, 0, 20, 4, 1);
            stone += Noise(px, 0, 13, 8, 1);
            stone += Noise(px, 0, 3, 3, 1);
            stone += 19;

            print(stone);

            int soil = Noise(px, 0, 25, 9, 1);
            soil += Noise(px, 0, 13, 8, 1);
            soil += 19;

            int snow = Noise(px, 0, 25, 9, 1);
            snow += Noise(px, 0, 13, 8, 1);
            snow += 20;

            for (int py = 0; py < blocks.GetLength(1); py++) {
                if (py < stone)
                {
                    blocks[px, py] = 1;
                    if (Noise(px, py, 10, 16, 1) > 10)
                    {
                        blocks[px, py] = 4;
                    }
                }
                else if (py < soil)
                {
                    blocks[px, py] = 2;
                    if (Noise(px/8, py * 13, 60, 16, 1) > 9)
                    {
                        blocks[px, py] = 7;
                    }
                }
                else if (py < snow)
                {
                    blocks[px, py] = 3;
                    if (Noise(px * 8, py / 32, 10, 18, 1) > 10)
                    {
                        blocks[px, py] = 6;
                    }
                }
                else if (Noise(px*8,py/32,16,14,1)>10) {
                    blocks[px, py] = 5;
                }
            }
        }
    }
    void BuildMesh() {
        for (int px = 0; px < blocks.GetLength(0); px++) {
            for (int py = 0; py < blocks.GetLength(1); py++) {
                
                if (blocks[px, py] != 0) {
                    GenCollider(px, py);
                }
                if (blocks[px, py] == 1)
                {
                    GenSquare(px, py, tStone);
                }
                else if (blocks[px, py] == 2)
                {
                    GenSquare(px, py, tSoil);
                }
                else if (blocks[px, py] == 3)
                {
                    GenSquare(px, py, tSnow);
                }
                else if (blocks[px, py] == 4)
                {
                    GenSquare(px, py, tMetal);
                }
                else if (blocks[px, py] == 5)
                {
                    GenSquare(px, py, tWood);
                }
                else if (blocks[px, py] == 6)
                {
                    GenSquare(px, py, tBush);
                }
                else if (blocks[px, py] == 7)
                {
                    GenSquare(px, py, tIce);
                }
                else if (blocks[px, py] == 8)
                {
                    GenSquare(px, py, tWorkbench);
                }
                else if (blocks[px, py] == 9)
                {
                    GenSquare(px, py, tChair);
                }
                else if (blocks[px, py] == 10)
                {
                    GenSquare(px, py, tTable);
                }
            }
        }
    }
    byte Block(int x, int y)
    {
        if (x == -1 || x == blocks.GetLength(0) || y == -1 || y == blocks.GetLength(1)) {
            return (byte)1;
        }
        return blocks[x, y];
    }
    void GenCollider(int x, int y){
        if (Block(x, y + 1) == 0)
        {
            colVertices.Add(new Vector3(x, y, 1));
            colVertices.Add(new Vector3(x + 1, y, 1));
            colVertices.Add(new Vector3(x + 1, y, 0));
            colVertices.Add(new Vector3(x, y, 0));

            ColliderTriangles();

            colCount++;
        }
        if (Block(x, y - 1) == 0)
        {
            colVertices.Add(new Vector3(x, y - 1, 1));
            colVertices.Add(new Vector3(x + 1, y - 1, 1));
            colVertices.Add(new Vector3(x + 1, y - 1, 0));
            colVertices.Add(new Vector3(x, y - 1, 0));

            ColliderTriangles();

            colCount++;
        }
        if (Block(x - 1, y) == 0)
        {
            colVertices.Add(new Vector3(x, y - 1, 1));
            colVertices.Add(new Vector3(x, y, 1));
            colVertices.Add(new Vector3(x, y, 0));
            colVertices.Add(new Vector3(x, y - 1, 0));

            ColliderTriangles();

            colCount++;
        }
        if (Block(x + 1, y) == 0)
        {
            colVertices.Add(new Vector3(x + 1, y, 1));
            colVertices.Add(new Vector3(x + 1, y - 1, 1));
            colVertices.Add(new Vector3(x + 1, y - 1, 0));
            colVertices.Add(new Vector3(x + 1, y, 0));

            ColliderTriangles();

            colCount++;
        }
    }
    void ColliderTriangles() {
        colTriangles.Add(colCount * 4);
        colTriangles.Add((colCount * 4) + 1);
        colTriangles.Add((colCount * 4) + 3);
        colTriangles.Add((colCount * 4) + 1);
        colTriangles.Add((colCount * 4) + 2);
        colTriangles.Add((colCount * 4) + 3);
    }
    void GenSquare(int x, int y, Vector2 texture)
    {
        newVertices.Add(new Vector3(x, y));
        newVertices.Add(new Vector3(x + 1, y));
        newVertices.Add(new Vector3(x + 1, y - 1));
        newVertices.Add(new Vector3(x, y - 1));

        newTriangles.Add(squareCount * 4);
        newTriangles.Add((squareCount * 4) + 1);
        newTriangles.Add((squareCount * 4) + 3);
        newTriangles.Add((squareCount * 4) + 1);
        newTriangles.Add((squareCount * 4) + 2);
        newTriangles.Add((squareCount * 4) + 3);

        newUV.Add(new Vector2(tUnit * texture.x, tUnit * texture.y + tUnit));
        newUV.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y + tUnit));
        newUV.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y));
        newUV.Add(new Vector2(tUnit * texture.x, tUnit * texture.y));

        squareCount++;
    }
    void UpdateMesh ()
    {
        mesh.Clear();
        mesh.vertices = newVertices.ToArray();
        mesh.triangles = newTriangles.ToArray();
        mesh.uv = newUV.ToArray();
        mesh.RecalculateNormals();

        squareCount = 0;
        newVertices.Clear();
        newTriangles.Clear();
        newUV.Clear();

        Mesh newMesh = new Mesh();
        newMesh.vertices = colVertices.ToArray();
        newMesh.triangles = colTriangles.ToArray();
        col.sharedMesh = newMesh;

        colVertices.Clear();
        colTriangles.Clear();
        colCount = 0;
    }
}