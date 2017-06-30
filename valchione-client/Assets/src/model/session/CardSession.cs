using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardSession{

    private static CardSession instance;

    private static Dictionary<int, CardDto> _cardDictionary;

    private CardSession() { }


    private static CardDto getCard(int id)
    {
        return cardDictionary[id];
    }

    public static Dictionary<int,CardDto> cardDictionary
    {
        get { return _cardDictionary; }
        private set { _cardDictionary = value;  }
    }
    public static CardSession getInstance()
    {
        if (instance == null) instance = new CardSession();
        return instance;
    }
}
