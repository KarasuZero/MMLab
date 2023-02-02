using System;
using System.Collections.Generic;
using MasterMindLibrary;


namespace MasterMind
{
    class Program
    {
        static List<Peg> pegList = new List<Peg>()
        {
            new Peg(ConsoleColor.White, ConsoleColor.Red),
            new Peg(ConsoleColor.White, ConsoleColor.Blue),
            new Peg(ConsoleColor.Black, ConsoleColor.Green),
            new Peg(ConsoleColor.Black, ConsoleColor.Yellow),
            new Peg(ConsoleColor.Black, ConsoleColor.Cyan),
            new Peg(ConsoleColor.White, ConsoleColor.Magenta),
            new Peg(ConsoleColor.White, ConsoleColor.DarkGray),
            new Peg(ConsoleColor.White, ConsoleColor.DarkRed)
        };

        static void Main(string[] args)
        {
            List<Attempt> allAttempts = new List<Attempt>();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Mastermind!");
            Console.ResetColor();

            //ask for difficulty
            List<String> difficultyOptions = new List<string>()
            {
                "Easy",
                "Medium",
                "Hard"
            };

            int difficulty = MMLib.GetConsoleMenu(difficultyOptions);

            //ask for maxTurns of turns to guess it
            int maxTurns = MMLib.GetConsoleInt("How many turns would you like to guess the answer?", 1, 100);

            //store the maxPegs based on difficulty
            int maxPegs = 0;
            switch (difficulty)
            {
                case 1:
                    maxPegs = 4;
                    break;
                case 2:
                    maxPegs = 6;
                    break;
                case 3:
                    maxPegs = 8;
                    break;
            }
            //Generate an answer
            List<int> answer = MMLib.GenerateAnswer(maxPegs);

            //show cheat? 
            switch (MMLib.GetConsoleMenu(new List<string>() { "Yes", "No" }))
            {
                case 1:
                        MMLib.Cheat(answer, pegList);
                        break;
                case 2:
                        break;
                
            }
            
            bool gameWon = false;
            while (!gameWon && maxTurns != 0)
            {
                //get user attempt
                Attempt attempt = GetAttemptFromUser(maxPegs, allAttempts, maxTurns);
                //Check the attempt for a correct guess
                CheckAttempt(attempt, answer);
                //add the attempt to the attempt list
                allAttempts.Add(attempt);
                //determin if the game has been won or not
                gameWon = attempt.CorrectAnswerCount == maxPegs;
                //reduce the maxTurns
                maxTurns--;
            }
            

            //If won, display Game Won!
            //If lost, show game loss
            //show the correct answer
        }

        static Attempt GetAttemptFromUser(int maxPegs, List<Attempt> allAttempts, int maxTurns)
        {
            //Create a new Attempt
            Attempt attempt = new Attempt();
            
            //Get color options based on maxPegs
            List<String> colorOptions = new List<string>();
            for (int i = 0; i < maxPegs; i++)
            {
                colorOptions.Add(pegList[i].PegColor.ToString());
            }
            
            //Loop through the maxPegs
            for (int i = 0; i < maxPegs; i++)
            {
                //      clear console
                Console.Clear();
                
                //      Display # of attempts left
                Console.WriteLine($"You have {maxTurns} attempts left.");
                
                //      Show all previous attempts
                foreach (Attempt a in allAttempts)
                {
                    Console.WriteLine($"Attempt: {a.AttemptList.Count} Correct: {a.CorrectAnswerCount}");
                }
                
                //      Show pegs they have chosen already in this attempt
                //      Ask them to pick a peg color from a menu of options
                //      Add the chosen peg to the Attempt.AttemptList
            }
            
            //Return the attempt when done

            return attempt;
        }


        static void CheckAttempt(Attempt attempt, List<int> answer)
        {
            //Check the attempt.AttemptList to see if they got a match to the answer
            //If a peg is correct, increment the attempt.CorrectAnswerCount
        }
    }
}
