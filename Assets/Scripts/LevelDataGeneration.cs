using System.Collections.Generic;
using UnityEngine;
using Quiz.Data;
using Quiz.Bundle;

public class LevelDataGeneration : MonoBehaviour
{
    private CardTypeFree[] _freeCardsType;

    public List<LevelData> GenerateLevels(GridData[] levels, CardBundleData[] cardBundle)
    {
        _freeCardsType = new CardTypeFree[cardBundle.Length];
        for (int i = 0; i < _freeCardsType.Length; i++)
        {
            _freeCardsType[i] = new CardTypeFree(new List<CardData>(cardBundle[i].CardData));
        }

        List<LevelData> newLevelData = new List<LevelData>();
        int currnetCardBundle = Random.Range(0, cardBundle.Length);

        for (int i = 0; i < levels.Length; i++)
        {
            LevelData levelData = GenerateLevel(levels, currnetCardBundle, i);
            newLevelData.Add(levelData);

            currnetCardBundle++;
            currnetCardBundle = (currnetCardBundle < cardBundle.Length) ? currnetCardBundle : 0;

            if (_freeCardsType[currnetCardBundle].ListFreeCards.Count <= 1)
                break;
        }

        return newLevelData;
    }

    private LevelData GenerateLevel(GridData[] levels, int currentCardBundle, int index)
    {
        CardData targetCard = RandomCard(currentCardBundle);
        _freeCardsType[currentCardBundle].ListFreeCards.Remove(targetCard);

        List<CardData> listLevelData = new List<CardData>();
        listLevelData.Add(targetCard);

        for (int i = 0; i < levels[index].CountCells - 1; i++)
        {
            listLevelData.Add(RandomCard(currentCardBundle));
        }

        return new LevelData(targetCard, listLevelData);
    }

    private CardData RandomCard(int currentCardBundle)
    {
        return _freeCardsType[currentCardBundle].ListFreeCards[Random.Range(0, _freeCardsType[currentCardBundle].ListFreeCards.Count)];
    }
}