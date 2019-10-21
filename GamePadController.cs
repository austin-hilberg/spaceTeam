using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadController : MonoBehaviour {

	string xLeft = "xLeft";
	string yLeft = "yLeft";
	Vector2 leftStickInput = new Vector2();
	float minInput = 0.5f;

	float bounceTime = 0.5f;
	float lastBounce = 0f;

	NavigationBoard navBoard;

	// Use this for initialization
	void Start () {
		navBoard = GameObject.Find("Board").GetComponent<NavigationBoard>();
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time;
		leftStickInput.Set(Input.GetAxis(xLeft), Input.GetAxis(yLeft));
		int direction;
		if (leftStickInput.magnitude <= 0.1f) {
			lastBounce = t - bounceTime;
		}
		else if (leftStickInput.magnitude > minInput && t - lastBounce >= bounceTime) {
			float inputAngle = Vector2.Angle(Vector2.right, leftStickInput);
			if (inputAngle <= 30f) {
				direction = 0;
				Debug.Log("Right");
			}
			else if (inputAngle <= 90f) {
				direction = leftStickInput.y > 0f ? 1 : 5;
				Debug.Log(leftStickInput.y > 0f ? "Top Right" : "Bottom Right");
			}
			else if (inputAngle <= 150f) {
				direction = leftStickInput.y > 0f ? 2 : 4;
				Debug.Log(leftStickInput.y > 0f ? "Top Left" : "Bottom Left");
			}
			else {
				direction = 3;
				Debug.Log("Left");
			}
			if (navBoard.MoveIndicator(direction)) {
				lastBounce = t;
			}
		}
	}

}
