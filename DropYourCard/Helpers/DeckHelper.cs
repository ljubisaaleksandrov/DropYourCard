using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropYourCard.Enums;

namespace DropYourCard.Helpers
{
    public static class DeckHelper
    {
        public static string InitializeDeck(GameType gameType)
        {
            string deck = "";
            switch (gameType)
            {
                case GameType.Tablic2:
                case GameType.Tablic3:
                case GameType.Tablic4:
                {
                    deck = Enum.GetNames(typeof (Card)).Where(name => !name.Contains("15")).Aggregate(deck, (current, name) => current + (name + ","));
                    break;
                }
                case GameType.Magarac:
                {
                    deck = Enum.GetNames(typeof (Card)).Where(name => (name.Contains("1") && !name.Contains("10")) || name.Contains("T2")).Aggregate(deck, (current, name) => current + (name + ","));
                    break;
                }
                default:
                {
                    deck = Enum.GetNames(typeof (Card)).Aggregate(deck, (current, name) => current + (name + ","));
                    break;
                }
            }

            return deck;
        }

        public static string RemoveCards(string deck, string[] cards)
        {
            foreach (string card in cards)
            {
                int cardLocation = deck.IndexOf(card, StringComparison.Ordinal); // because of ',' character
                if(cardLocation >= 0)
                    deck = deck.Remove(cardLocation, card.Length + 1);
            }

            return deck;
        }

        public static string AddCards(string deck, string[] cards)
        {
            foreach (string card in cards)
            {
                if (card != "")
                {
                    int cardLocation = deck.IndexOf(card, StringComparison.Ordinal);
                    if (cardLocation < 0)
                        deck += card + ",";
                }
            }

            return deck;
        }

        public static string GetRandomCards(ref string deck, int cardsNumber)
        {
            List<string> cardsList = AsList(deck);
            if (cardsList.Count < cardsNumber)
                return (string)null;
            else
            {
                string cards = "";
                Random random = new Random();
                for (int i = 0; i < cardsNumber; i++)
                {
                    int cardindex = random.Next(cardsList.Count - 1);
                    cards += cardsList[cardindex] + ",";
                    cardsList.RemoveAt(cardindex);
                }

                deck = AsString(cardsList);

                return cards;
            }
        }

        public static List<string> AsList(string cards)
        {
            List<string> cardsList = CsvHelper.TrimNSplitCsv(cards).ToList<string>();
            if (cardsList.Contains(""))
                cardsList.Remove("");
            return cardsList;
        }

        public static string AsString(List<string> cardsList)
        {
            return cardsList.Aggregate("", (current, s) => current + (s + ","));
        }

        public static int GetCardNumber(string card)
        {
            return Int32.Parse(card.Length == 3 ? card.Substring(1, 2) : card.Substring(1, 1));
        }

        public static List<int> GetCardsNumbers(string cards)
        {
            return AsList(cards).Select(card => card.Length == 3 ? Int32.Parse(card.Substring(1, 2)) : Int32.Parse(card.Substring(1, 1))).ToList();
        }
    }
}