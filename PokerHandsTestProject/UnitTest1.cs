using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands;
using System.Collections.Generic;

namespace PokerHandsTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateCardDeck_AmountOfCards_ShouldBe52()
        {
            // Arrange
            var deckList = new List<Card>();
            // Act
            deckList = Program.CreateCardDeck();
            // Assert
            Assert.IsTrue(deckList.Count == 52);
        }

        [TestMethod]
        public void CreateCardDeck_FirstCard_IdShouldBe1()
        {
            // Arrange
            var deckList = new List<Card>();
            // Act
            deckList = Program.CreateCardDeck();
            // Assert
            Assert.IsTrue(deckList[0].Id == 1);
        }

        [TestMethod]
        public void CreateCardDeck_FirstCard_ColorShouldBeClubs()
        {
            // Arrange
            var deckList = new List<Card>();
            // Act
            deckList = Program.CreateCardDeck();
            // Assert
            Assert.IsTrue(deckList[0].Color == "Clubs");
        }

        [TestMethod]
        public void CreateCardDeck_FirstCard_ValueShouldBe2()
        {
            // Arrange
            var deckList = new List<Card>();
            // Act
            deckList = Program.CreateCardDeck();
            // Assert
            Assert.IsTrue(deckList[0].Value == "2");
        }

        [TestMethod]
        public void CreateCardDeck_LastCard_IdShouldBe52()
        {
            // Arrange
            var deckList = new List<Card>();
            // Act
            deckList = Program.CreateCardDeck();
            // Assert
            Assert.IsTrue(deckList[51].Id == 52);
        }

        [TestMethod]
        public void CreateCardDeck_LastCard_ColorShouldBeHearts()
        {
            // Arrange
            var deckList = new List<Card>();
            // Act
            deckList = Program.CreateCardDeck();
            // Assert
            Assert.IsTrue(deckList[51].Color == "Hearts");
        }

        [TestMethod]
        public void CreateCardDeck_LastCard_ValueShouldBeAce()
        {
            // Arrange
            var deckList = new List<Card>();
            // Act
            deckList = Program.CreateCardDeck();
            // Assert
            Assert.IsTrue(deckList[51].Value == "Ace");
        }

        [TestMethod]
        public void SortCards_5Cards_ShouldBeSortedById()
        {
            // Arrange
            var sortedList = new List<Card>();
            var deckList = new List<Card>()
            {
                new Card() { Id = 3, Color = "Something", Value = "SomethingElse" },
                new Card() { Id = 1, Color = "Something", Value = "SomethingElse" },
                new Card() { Id = 5, Color = "Something", Value = "SomethingElse" },
                new Card() { Id = 4, Color = "Something", Value = "SomethingElse" },
                new Card() { Id = 2, Color = "Something", Value = "SomethingElse" },
            };
            // Act
            sortedList = Program.SortCards(deckList);
            // Assert
            Assert.IsTrue(sortedList[0].Id == 1 && sortedList[1].Id == 2 && sortedList[2].Id == 3 && sortedList[3].Id == 4 && sortedList[4].Id == 5);
        }

    }
}
