using System;
using System.Collections.Generic;

public class DeckCodeDecoder  {
    private static PlayerSession playerSession = PlayerSession.getInstance();

    public static void unpackToDeck(PlayerCardDto playerCard)
    {
        double deckCode = playerCard.deckCode;        
        List<int> deckIndices = new List<int>();    
        int numOfDecks = playerSession.playerDto.numOfDecks;

        for (int k = 0; k < numOfDecks; k++)
        {
            double factor = Math.Pow(2, k);
            double remainder = deckCode % factor;

            if (remainder != 0)
                playerSession.addToDeck(k, playerCard);

            deckCode = Math.Ceiling(deckCode / 2) - remainder;
        }
    }
}
