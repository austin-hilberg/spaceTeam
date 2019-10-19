using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationBoard : HexBoard {
	
	public GameObject baseHex;
	List<int> deck = new List<int>();
	int deckSize = 81;

	void Start () {
		for (int i = 0; i < deckSize; i++) {
			deck.Add(i);
		}
		Debug.Log("Fresh: ");
		foreach(int card in deck){
			Debug.Log(card);
		}
		ShuffleDeck();
		Debug.Log("Shuffled: ");
		foreach(int card in deck){
			Debug.Log(card);
		}
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
}
