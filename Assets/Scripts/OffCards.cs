using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffCards : MonoBehaviour
{
    [SerializeField] private CardSpawner _cardSpawnr;

    private void Start()
    {
        _cardSpawnr = GetComponent<CardSpawner>();
    }

    public void OffClickabilityCards()
    {
        foreach (Card card in _cardSpawnr.CardsOnLevel)
            card.Clickability = false;
    }
}