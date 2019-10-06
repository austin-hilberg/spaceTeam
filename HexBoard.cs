using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexBoard : MonoBehaviour
{
    public GameObject baseHex;
    Dictionary<int, Dictionary<int, GameObject>> diagonals = new Dictionary<int, Dictionary<int, GameObject>>();
    
    float gridScale = 0.5f;
    float rootThree = Mathf.Sqrt(3);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void AddBigHex(int radius, int qCenter, int rCenter) {

        for (int q = -radius; q <= radius; q ++) {
            for (int r = -radius; r <= radius; r++) {
                if (HexDistance(q, r, qCenter, rCenter) <= radius) {
                    AddHex(q, r, baseHex);
                }
            }
        }
        baseHex.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetX(int q, int r) {
        return gridScale * (2 * q + r);
    }

    public float GetY(int r) {
        return gridScale * rootThree * r * (-1f);
    }

    public int HexDistance(int q1, int r1, int q2, int r2) {
        return CubeDistance(AxialToCube(q1, r1), AxialToCube(q2, r2));
    }

    public int HexDistance(Vector2 hexCoord1, Vector2 hexCoord2) {
        return HexDistance((int) hexCoord1.x, (int)  hexCoord1.y, (int)  hexCoord2.x, (int)  hexCoord2.y);
    }

    public int HexDistance(int q, int r){
        return HexDistance(q, r, 0, 0);
    }

    public int HexDistance(Vector2 hexCoord) {
        return HexDistance((int) hexCoord.x, (int) hexCoord.y);
    }

    public Vector2 HexRound(float q, float r) {
        return CubeToAxial(CubeRound(AxialToCube(q, r)));
    }

    public Vector2 HexRound(Vector2 hexCoord) {
        return HexRound(hexCoord.x, hexCoord.y);
    }

    public Vector3 AxialToCube(float q, float r) {
        float b = -1f * (q + r);
        return new Vector3(q, b, r);
    }

    public Vector3 AxialToCube(Vector2 hexCoord) {
        return AxialToCube(hexCoord.x, hexCoord.y);
    }

    public Vector2 CubeToAxial(float a, float c) {
        return new Vector2(a, c);
    }

    public Vector2 CubeToAxial(Vector3 cubeCoord) {
        return CubeToAxial(cubeCoord.x, cubeCoord.z);
    }

    public int CubeDistance(int a1, int b1, int c1, int a2, int b2, int c2) {
        return (Mathf.Abs(a1 - a2) + Mathf.Abs(b1 - b2) + Mathf.Abs(c1 - c2)) / 2;
    }

    public int CubeDistance(Vector3 cubeCoord1, Vector3 cubeCoord2) {
        return CubeDistance((int) cubeCoord1.x, (int) cubeCoord1.y, (int) cubeCoord1.z, (int) cubeCoord2.x, (int) cubeCoord2.y, (int) cubeCoord2.z);
    }

    public int CubeDistance(int a, int b, int c) {
        return CubeDistance(a, b, c, 0, 0, 0);
    }

    public int CubeDistance(Vector3 cubeCoord) {
        return CubeDistance((int) cubeCoord.x, (int)  cubeCoord.y, (int)  cubeCoord.z);
    }

    public Vector3 CubeRound(float a, float b, float c) {
        int roundA = Mathf.RoundToInt(a);
        int roundB = Mathf.RoundToInt(b);
        int roundC = Mathf.RoundToInt(c);
        
        float deltaA = Mathf.Abs(roundA - a);
        float deltaB = Mathf.Abs(roundB - b);
        float deltaC = Mathf.Abs(roundC - c);

        if (deltaA > deltaB && deltaA > deltaC) {
            roundA = -1 * (roundB + roundC);
        }
        else if (deltaB > deltaC) {
            roundB = -1 * (roundA + roundC);
        }
        else {
            roundC = -1 * (roundA + roundB);
        }
        return new Vector3(roundA, roundB, roundC);
    }

    public Vector3 CubeRound(Vector3 cubeCoord) {
        return CubeRound(cubeCoord.x, cubeCoord.y, cubeCoord.z);
    }

    public bool CheckHex(int q, int r) {
        return diagonals.ContainsKey(q) && diagonals[q].ContainsKey(r);
    }

    public GameObject GetHex(int q, int r) {
        return diagonals[q][r];
    }

    protected void AddHex(int q, int r, GameObject hex) {
        
        Dictionary<int, GameObject> diagonal;
        if (diagonals.ContainsKey(q)) {
            diagonal = diagonals[q];
        }
        else {
            diagonal = new Dictionary<int, GameObject>();
            diagonals.Add(q, diagonal);
        }
        diagonal.Add(r, Instantiate(hex, new Vector3(GetX(q, r), GetY(r), 0f), new Quaternion()));
    }

}
