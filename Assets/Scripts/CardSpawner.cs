using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Quiz.Bundle;
using Quiz.Data;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private Transform _backgroundGridSize;
    [SerializeField] private ColorBundle _color;
    [SerializeField] private UnityEvent _endSpawn;
    [SerializeField] private UnityEvent _firstLoad;

    private List<Vector2> _positionCells = new List<Vector2>();
    private List<Card> _cardsOnLevel = new List<Card>();

    private string _targetCard;
    public string TargetCard => _targetCard;
    public List<Card> CardsOnLevel => _cardsOnLevel;

    private float _sizeBorderGrid = .05f;

    public void Spawn(GridData gridData, LevelData levelData, UnityEvent findCardEvent, bool firstLoad)
    {
        ClearGrid();

        _positionCells = GetPosition(gridData);

        for (int i = 0; i < levelData.CardsInLevel.Count; i++)
        {
            Vector2 randomPosition = _positionCells[Random.Range(0, _positionCells.Count)];
            _positionCells.Remove(randomPosition);
            Card card = Instantiate(_cardPrefab, randomPosition, Quaternion.identity, transform);
            _cardsOnLevel.Add(card);
            
            bool target = false;
            if(i == 0)
            {
                target = true;
                _targetCard = levelData.TargetCard.Identifier;
            }

            if (firstLoad)
            {
                card.FirstLoad();
                _firstLoad.Invoke();
            }

            card.SetDataCard(levelData.CardsInLevel[i], target, _color.Color[Random.Range(0, _color.Color.Length)], findCardEvent);

        }

        _backgroundGridSize.localScale = new Vector2(gridData.Colums + _sizeBorderGrid, gridData.Rows + _sizeBorderGrid);

        _endSpawn.Invoke();
    }

    private void ClearGrid()
    {
        foreach (Card card in _cardsOnLevel)
            Destroy(card.gameObject);

        _cardsOnLevel.Clear();
    }

    public List<Vector2> GetPosition(GridData gridData)
    {
        List<Vector2> positions = new List<Vector2>();
        Vector2 offset = new Vector2(gridData.Colums, gridData.Rows) - Vector2.one;
        offset /= 2;

        for (int y = 0; y < gridData.Rows; y++)
        {
            for (int x = 0; x < gridData.Colums; x++)
                positions.Add(new Vector2(x, y) - offset);
        }

        return positions;
    }
}