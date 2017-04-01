using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool Quit = false;
            int playCount = 0;
            int fullHouseCount = 0;
            int flushCount = 0;

            while (Quit == false)
            {
                List<Card> deckList = new List<Card>();
                List<Card> pokerHandList = new List<Card>();
                playCount++;

                Console.ForegroundColor = ConsoleColor.White;
                PrintWelcomeText();

                deckList = CreateCardDeck();
                deckList = ShuffleCardDeck(deckList);
                //deckList = SortCards(deckList);

                pokerHandList = DrawAmoutOfCardsFromDeckList(5, deckList);
                pokerHandList = SortCards(pokerHandList);

                //Console.WriteLine("Cards in your deck:");
                //PrintCards(deckList);

                Console.WriteLine("Sorted cards in your hand:");
                PrintCards(pokerHandList);

                if (pokerHandList.Select(x => x.Value).Distinct().ToList().Count == 2)
                {
                    fullHouseCount++;
                }

                if (pokerHandList.Select(x => x.Color).Distinct().ToList().Count == 1)
                {
                    flushCount++;
                }

                Console.WriteLine($"Amount Of Plays: {playCount}");
                Console.WriteLine($"Amount Of Full Houses: {fullHouseCount}");
                Console.WriteLine($"Amount Of Flushes: {flushCount}");
                Console.WriteLine();

                PlayAgainText();

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Quit = true;
                    PrintEndText();
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        private static void PrintWelcomeText()
        {
            Console.WriteLine("Welcome to my PokerHands Generator!");
            Console.WriteLine();
        }

        public static List<Card> CreateCardDeck()
        {
            List<Card> deckList = new List<Card>();
            int cardId = 1;
            string[] value = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            string[] color = { "Clubs", "Diamonds", "Spades", "Hearts" };

            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 13; i++)
                {
                    Card card = new Card()
                    {
                        Id = cardId,
                        Value = value[i],
                        Color = color[k]
                    };
                    deckList.Add(card);
                    cardId++;
                }
            }
            return deckList;
        }

        private static Random r = new Random();

        private static List<Card> ShuffleCardDeck(List<Card> deckList)
        {
            List<Card> ShuffleCardDeck = new List<Card>();

            for (int i = deckList.Count - 1; i > 0; --i)
            {
                int k = r.Next(i + 1);
                Card temp = deckList[i];
                deckList[i] = deckList[k];
                deckList[k] = temp;
            }
            ShuffleCardDeck = deckList;
            return ShuffleCardDeck;
        }

        private static List<Card> DrawAmoutOfCardsFromDeckList(int cards, List<Card> deckList)
        {
            List<Card> pokerHandList = new List<Card>();
            
            for (int c = 0; c < cards; c++)
            {
                pokerHandList.Add(deckList[c]);
            }
            return pokerHandList;
        }

        private static void PrintCards(List<Card> cardList)
        {
            foreach (var card in cardList)
            {
                if (card.Color == "Hearts")
                    Console.ForegroundColor = ConsoleColor.Red;
                if (card.Color == "Spades")
                    Console.ForegroundColor = ConsoleColor.Cyan;
                if (card.Color == "Clubs")
                    Console.ForegroundColor = ConsoleColor.Green;
                if (card.Color == "Diamonds")
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{card.Value} of {card.Color}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static List<Card> SortCards(List<Card> cardList)
        {
            List<Card> sortedCardsList = new List<Card>();
            sortedCardsList = cardList.OrderBy(c => c.Id).ToList();
            return sortedCardsList;
        }

        private static void PlayAgainText()
        {
            Console.WriteLine("Play again?");
            Console.WriteLine("Press any [Key] to restart.");
            Console.WriteLine("Press [Escape] to quit.");
        }

        private static void PrintEndText()
        {
            Console.WriteLine();
            Console.WriteLine("Made by Jacob Gandemo");
            Console.WriteLine("Press any key to Quit...");
            Console.ReadKey();
        }

    }
}
