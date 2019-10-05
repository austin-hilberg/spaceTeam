using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexBoard : MonoBehaviour
{
    public GameObject hex;

    int nRows = 3;
    int nCols = 3;
    
    float gridScale = 1f;
    float rootThree = Mathf.Sqrt(3);
    float rootThreeHalf = Mathf.Sqrt(3) / 2f;


    // Start is called before the first frame update
    void Start()
    {
    }

    void SetupBoard() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetX(int q, int r) {
        return gridScale * (rootThree * q + rootThreeHalf * r);
    }

    public float GetY(int r) {
        return gridScale * rootThreeHalf * r;
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

    public Vector3 CubeRound(float a, float b, float c) {
        int roundA = Mathf.RoundToInt(a);
        int roundB = Mathf.RoundToInt(b);
        int roundC = Mathf.RoundToInt(c);
        
        float deltaA = Mathf.Abs(roundA - a);
        float deltaB = Mathf.Abs(roundB - b);
        float deltaC = Mathf.Abs(roundC - c);

        if (deltaA > deltaB & deltaA > deltaAC) {
            roundA = -1f * (roundB + roundC);
        }
        else if (deltaB > deltaC) {
            roundB = -1f * (roundA + roundC);
        }
        else {
            rz = -1f * (roundA + roundB);
        }
        return new Vector3(roundA, roundB, roundC);
    }

    public Vector3 CubeRound(Vector3 cubeCoord) {
        return CubeRound(cubeCoord.x, cubeCoord.y, cubeCoord.z);
    }

}
