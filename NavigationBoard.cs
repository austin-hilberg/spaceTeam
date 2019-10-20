using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationBoard : HexBoard {
	
	public GameObject baseHex;
	List<int> deck = new List<int>();
	int deckSize = 81;
	int nParams = 3;

	void Start () {
		for (int i = 0; i < deckSize; i++) {
			deck.Add(i);
		}
		ShuffleDeck();

		for (int r = -1; r < 2; r ++) {
			for (int q = -3; q < (3 - r); q++) {
				GameObject newHex = Draw();
				SetHex(q, r, newHex);
			}
		}
		
		baseHex.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void ShuffleDeck() {
		for (int i = 0; i < deckSize - 1; i++) {
			int currentCard = deck[i];
			int switchWith = Random.Range(i, deckSize);
			deck[i] = deck[switchWith];
			deck[switchWith] = currentCard;
		}
	}

	GameObject Draw() {
		int card = deck[0];
		Debug.Log("Card: " + card);
		GameObject newCard = GenerateCard(card);
		deck.RemoveAt(0);
		return newCard;
	}

	GameObject GenerateCard(int n) {
		GameObject newCard = Object.Instantiate(baseHex, transform);
		NavNode newNode = newCard.GetComponent<NavNode>();
		int ring = n % nParams;
		int position = (n / nParams) % nParams;
		int color = ((n / nParams) / nParams) % nParams;
		int shape = (((n / nParams) / nParams) / nParams) % nParams;
		newNode.Configure(ring, position, color, shape);

		return newCard;
	}
}
