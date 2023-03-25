using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfMath;
using WpfMath.Controls;

namespace MathProject
{
    static class Poll
    {
        static Random random = new Random();
        public static Formul[] Formuls= new Formul[4];
        public static int right_answer;
        static public void make_poll(int capacity = 4)
        {
            Formuls = Formul.generate_arr(capacity);
            right_answer = random.Next(capacity);
        }
        static public void set_poll(FormulaControl[] for_text, FormulaControl question)
        {

            for(int i = 0;i < Formuls.Length; i++)
            {
                for_text[i].Formula = Formuls[i].Definition;
            }

            question.Formula = Formuls[right_answer].Name;
        }
        static public void fast_poll(FormulaControl [] buttons,FormulaControl question, int capacity = 4)
        {
            make_poll(capacity);
            set_poll(buttons,question);
        }
        static public bool check_answer(int chosen)
        {
            return chosen == right_answer;
        }
    }
}
