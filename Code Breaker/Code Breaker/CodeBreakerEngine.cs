using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Code_Breaker
{
    class CodeBreakerEngine
    {
        //variables
        private int round;
        private List<string> user_guesses;
        private string rnd_number;
        private string user_number;
        private Random rnd;
        private int char_count;
        private int score;
        

        //constructor
        public CodeBreakerEngine()
        {
            rnd = new Random();
            round = 1;
            user_guesses = new List<string>();
            CreateRandomNumber();
            user_number = "";
            char_count = 0;
            score = 0;
            rnd_number = "";
        }

        //properties
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

        public List<string> UserGuesses
        {
            get
            {
                return user_guesses;
            }
        }

        public int Score
        {
            set { score = value; }
            get { return score; }
        }

        private void CreateRandomNumber()
        {
            while (true)
            {
                int rnd_numb = rnd.Next(100, 999);
                if (IsValid(rnd_numb))
                {
                    break;
                }
                rnd_number = rnd_numb.ToString();
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

        public void AddDigitToUserNumber(string digit)
        {
            user_number += digit;
            char_count++;

            if (char_count == 3)
            {
                //check answer and show round results
                RoundOver();
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

        public void RoundOver()
        {
            //bool has_won = false;
            //compare numbers
            int count_x, count_t, count_o;
            count_o = count_t = count_x = 0;

            for (int i = 0; i < user_number.Length; i++)
            {
                if (rnd_number.Contains(user_number[i]))
                    count_x++;
                else
                {
                    bool match = false;
                    for (int j = 0; j < rnd_number.Length; j++)
                    {
                        if (user_number[i] == rnd_number[j])
                        {
                            match = true;
                            break;
                        }
                    }
                    if (match)
                    {
                        count_o++;
                    }
                    else
                        count_t++;
                }
            }
            //1234 - O 1 | T 1 | X 1
            user_guesses.Add(user_number + " - O " + count_o + " | T " + count_t + " | X " + count_x);
            round++;
            if (round - 1 == 10 || count_o == 3)
                GameOver();
            

        }

        public void GameOver()
        {

        }

        
    }
}
