using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavNode : MonoBehaviour {

	public Material color0;
	public Material color1;
	public Material color2;

	GameObject[] rings;
	Material[] materials;
	GameObject[] shapes;

	float baseRotation = 90f;
	float positionDelta = 120f;

	int[] properties;

	// Use this for initialization
	void Start () {
	}

	public void Configure(int ring, int position, int color, int shape) {
		GameObject innerRing = transform.Find("Inner").gameObject;
		GameObject midRing = transform.Find("Mid").gameObject;
		GameObject outerRing = transform.Find("Outer").gameObject;
		rings = new GameObject[] {innerRing, midRing, outerRing};

		GameObject sphere = transform.Find("Sphere").gameObject;
		GameObject cube = transform.Find("Cube").gameObject;
		GameObject hex = transform.Find("Hex").gameObject;
		shapes = new GameObject[] {sphere, cube, hex};

		materials = new Material[] {color0, color1, color2};

		properties = new int[4] {ring, position, color, shape};

		foreach (GameObject ringObj in rings) {
			ringObj.transform.Rotate(0f, 0f, baseRotation + positionDelta * position, Space.World);
		}

		rings[ring].GetComponent<MeshRenderer>().material = materials[color];

		shapes[shape].GetComponent<MeshRenderer>().material = materials[color];
		for (int i = 0; i < shapes.Length; i++) {
			shapes[i].SetActive(i == shape);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
