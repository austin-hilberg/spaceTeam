using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationBoard : HexBoard {
	
	public GameObject baseHex;
	List<int> deck = new List<int>();
	int deckSize = 81;
	int nParamValues = 3;
	int nParams = 4;
	int drawSize = 21;
	List<GameObject> cardsOnBoard = new List<GameObject>();

	void Start () {
		for (int i = 0; i < deckSize; i++) {
			deck.Add(i);
		}
		ShuffleDeck();

		for (int r = -1; r < 2; r ++) {
			for (int q = -3; q < (4 - r); q++) {
				GameObject newHex = Draw();
				SetHex(q, r, newHex);
				cardsOnBoard.Add(newHex);
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
		GameObject newCard = GenerateCard(card);
		deck.RemoveAt(0);
		return newCard;
	}

	GameObject GenerateCard(int n) {
		GameObject newCard = Object.Instantiate(baseHex, transform);
		NavNode newNode = newCard.GetComponent<NavNode>();
		int ring = n % nParamValues;
		int position = (n / nParamValues) % nParamValues;
		int color = ((n / nParamValues) / nParamValues) % nParamValues;
		int shape = (((n / nParamValues) / nParamValues) / nParamValues) % nParamValues;
		newNode.Configure(ring, position, color, shape);

		return newCard;
	}

	int[] CompleteCluster(NavNode node1, NavNode node2) {
		int[] props1 = node1.GetProperties();
		int[] props2 = node2.GetProperties();
		int[] props3 = new int[nParams];
		for (int i = 0; i < nParams; i++) {
			props3[i] = (nParamValues - props1[i] - props2[i]) % nParamValues;
		}
		return props3;
	}

	bool CheckCluster(NavNode node1, NavNode node2, NavNode node3) {
		int[] props1 = node1.GetProperties();
		int[] props2 = node2.GetProperties();
		int[] props3 = node3.GetProperties();
		for (int i = 0; i < nParams; i++) {
			if ((props1[i] + props2[i] + props3[i]) % nParamValues != 0) {
				return false;
			}
		}
		return true;
	}
}
