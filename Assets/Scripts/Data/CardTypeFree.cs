using System.Collections.Generic;

namespace Quiz.Data
{
    public class CardTypeFree
    {
        private List<CardData> _listFreeCards;

        public List<CardData> ListFreeCards => _listFreeCards;

        public CardTypeFree (List<CardData> freeCard)
        {
            _listFreeCards = freeCard;
        }
    }
}