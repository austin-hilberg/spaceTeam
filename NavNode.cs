using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavNode : MonoBehaviour {

	public Material color0;
	public Material color1;
	public Material color2;

	GameObject[] rings;
	Material[] materials;
	GameObject sphere;
	GameObject cube;

	int[] properties;

	// Use this for initialization
	void Start () {
		GameObject innerRing = transform.Find("Inner").gameObject;
		GameObject midRing = transform.Find("Mid").gameObject;
		GameObject outerRing = transform.Find("Outer").gameObject;
		rings = new GameObject[] {innerRing, midRing, outerRing};

		materials = new Material[] {color0, color1, color2};

		sphere = transform.Find("Sphere").gameObject;
		cube = transform.Find("Cube").gameObject;
	}

	void Configure(int ring, int position, int color, int shape) {
		properties = new int[4] {ring, position, color, shape};

		rings[ring].GetComponent<MeshRenderer>().material = materials[color];

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
