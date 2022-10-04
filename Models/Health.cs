using System.Collections.Generic;
namespace Allegies.Models
{
    public class Health
    {
        public int Score{get ; set ;}
        private Dictionary<int , string> _allergenScore = new Dictionary<int, string>{{1 , "eggs"} , {2 , "peanuts"} , {4 , "shellfish"} , {8 , "strawberries"} , {16 , "tomatoes"} , {32 , "chocolate"} , {64 , "pollen"} , {128 , "cats"}};
        private int [] _scoreNo = {1 , 2 , 4 , 8 , 16 , 32 , 64 , 128};
        public Health(int score)
        {
            Score = score;
        }
        private List<string> _allegies = new List<string>(){};

        public List<string> GetAllegies()
        {
            List<int> lessAllergiesScore = new List<int>(0);
            if(_allergenScore.ContainsKey(Score))
            {
                _allegies.Add(_allergenScore[Score]);
            }
            else
            {
               foreach(int number in _scoreNo)
               {
                   if(number < Score)
                   {
                       lessAllergiesScore.Add(number);
                   }
               }
               
                lessAllergiesScore.Reverse();
                int [] newLessAlleg = lessAllergiesScore.ToArray();
                int secondScore = this.Score;
                int numberScore = 0;
               for(int i = 0 ; i < newLessAlleg.Length ; i ++)
               {
                   int mod = secondScore % newLessAlleg[i];
                   if( mod %  2 == 0 && secondScore > 0)
                   {
                       numberScore += newLessAlleg[i];
                       secondScore -= newLessAlleg[i];
                       if(numberScore > Score)
                       {
                           i++;
                       }
                       _allegies.Add(_allergenScore[newLessAlleg[i]]);
                       
                   }
                   
               }
            }
            return _allegies;
        }
    }
}