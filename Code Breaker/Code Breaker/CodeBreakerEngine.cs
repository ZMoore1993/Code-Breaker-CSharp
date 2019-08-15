using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Breaker
{
    class CodeBreakerEngine
    {
        private int round;
        private List<string> user_guesses;
        private int rnd_number;
        private string user_number;
        private Random rnd;

        public CodeBreakerEngine()
        {
            rnd = new Random();
            round = 1;
            user_guesses = new List<string>();
            CreateRandomNumber();
            user_number = "";
        }

        private void CreateRandomNumber()
        {
            while (true)
            {
                rnd_number = rnd.Next(100, 999);
                if (IsValid(rnd_number))
                {
                    break;
                }
            }
        }

        private bool IsValid(int num)
        {
            string temp = num.ToString();
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = i + 1; j < temp.Length; j++)
                {
                    if (temp[i] == temp[j])
                        return false;
                }
            }
            return true;
        }

        public int Round
        {
            set
            {
                round = value;
            }
            get
            {
                return round;
            }
        }

        public string UserNumber
        {
            get { return user_number; }
        }

        public void AddDigitToUserNumber(string digit)
        {
            user_number += digit;
        }


        public void AddUserGuess(string guess)
        {
            user_guesses.Add(guess);
        }

        public List<string> UserGuesses
        {
            get
            {
                return user_guesses;
            }
        }
 
        public string PrintInstructions()
        {
            //NEED TO PAUSE GAME WHEN BUTTON IS CLICKED!
            string s1 = "Enter a 3 digit number and use logic to guess the correct number\n";
            string s2 = "The number after X is number of digits not in the number\n";
            string s3 = "The number after T is number of digits in the number, but not correct digit position\n";
            string s4 = "You get x attempts to guess the number";
            return s1 + s2 + s3 + s4;
            //MessageBox.Show(s1 + s2 + s3 + s4, "Game Instructions", MessageBoxButtons.OK);
        }

        
    }
}
