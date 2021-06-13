using System;

namespace BlackJack
{
    public class Game
    {
        public void Start()
        {

            Deck deck = new Deck();
            User player = new Player("Player");
            User computer = new Computer("Computer");
            int[] SuffleDeck = deck.SuffleCards();
                                    
            int _сardNumber = 0;
            bool isPlayerContinue = true;
            bool isComputerContinue = true;
            bool isGameContinue = true;

            do
            {
                Console.WriteLine("Do you want get to card?: y/n");
                string _playerDecision = Console.ReadLine();

                if (_playerDecision == "y" && _playerDecision != "n")
                {
                    player.GetToCard(SuffleDeck, _сardNumber);
                    player.GetToScore();
                }

                if (_playerDecision == "n")
                {
                    isPlayerContinue = player.Pass();
                }

                if (computer.UserScore <= 15)
                {
                    computer.GetToCard(SuffleDeck, _сardNumber);
                    computer.GetToScore();
                }

                if (computer.UserScore >= 15)
                {
                    isComputerContinue = computer.Pass();
                }

                if (player.UserScore > 21)
                {
                    isGameContinue = false;
                }

                if (isPlayerContinue == false && isComputerContinue == false)
                {
                    isGameContinue = false;
                }

                Console.WriteLine($"User: {player.UserName} Score: {player.UserScore}");
                Console.WriteLine($"User: {computer.UserName} Score: {computer.UserScore} ");

                _сardNumber++;
            }
            while (isGameContinue == true);

            DetermineTheWinner(player, computer);

        }

        protected void DetermineTheWinner(User player, User computer)
        {
            if (player.UserScore >= 21 && computer.UserScore <= 21)
            {
                Console.WriteLine($"User: {computer.UserName} win!");
            }

            if (computer.UserScore >= 21 && player.UserScore <= 21)
            {
                Console.WriteLine($"User: {player.UserName} win!");
            }

            if (player.UserScore == computer.UserScore && player.UserScore >= 21 && computer.UserScore >= 21)
            {
                Console.WriteLine("Next raund!");
            }

            if (player.UserScore > computer.UserScore && player.UserScore <= 21)
            {
                Console.WriteLine($"User: {player.UserName} win!");
            }
        }
    }

}
