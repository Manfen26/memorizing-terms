using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	public UIController uiController;

	[SerializeField] private BoolEvent _scoreAdd = new BoolEvent();

	GameState gameState;

	public CardSelectionState cardSelectionState;
	public PairSelectionState pairSelectionState;
	public MemorizeCardsState memorizeCardsState;
	public MatchingCardsState matchingCardsState;
	public EndGameState endGameState;
	public PauseGameState pauseGameState;

	public GameObject[] selectedCards;

	int cardCount;

	public int CardCount
	{
		set
		{
			cardCount = value;
		}
		get
		{
			return cardCount;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		selectedCards = new GameObject[2];
		selectedCards[0] = null;
		selectedCards[1] = null;

		InitStates();
	}

	void Update()
	{
		gameState.UpdateAction();

		if (cardCount <= 0)
		{
			TransitionState(endGameState);
		}
	}

	void InitStates()
	{
		cardSelectionState = new CardSelectionState(this);
		pairSelectionState = new PairSelectionState(this);
		memorizeCardsState = new MemorizeCardsState(this, 0.5f);
		matchingCardsState = new MatchingCardsState(this, 0.2f);
		pauseGameState = new PauseGameState(this);
		endGameState = new EndGameState(this);

		gameState = cardSelectionState;
	}

	public void TransitionState(GameState newState)
	{
		gameState.EndState();
		gameState = newState;
		gameState.EnterState();
	}

	public void SetSelectedCard(GameObject selectedCard)
	{
		if (selectedCards[0] == null)
		{
			selectedCards[0] = selectedCard;
			TransitionState(pairSelectionState);
		}
		else if (selectedCards[1] == null)
		{
			selectedCards[1] = selectedCard;

			if (MatchSelectedCards())
			{
				TransitionState(matchingCardsState);
				_scoreAdd.Invoke(true);
			}
			else
			{
				TransitionState(memorizeCardsState);
				_scoreAdd.Invoke(false);
			}
		}
	}

	public void RemoveSelectedCards()
	{
		selectedCards[0] = null;
		selectedCards[1] = null;
	}

	bool MatchSelectedCards()
	{
		CardSO first = selectedCards[0].GetComponent<CardController>().cardType;
		CardSO second = selectedCards[1].GetComponent<CardController>().cardType;

		return first != null && second != null && first.cardName == second.pairName && first.pairName == second.cardName; //сравнение карточек
	}
}

[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }
