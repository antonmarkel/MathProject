using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MathProject
{
    static class Poll
    {
        static Random random = new Random();
        public static Formul[] Formuls= new Formul[4];
        public static string? Question;
        public static int right_answer;
        static public void make_poll(int capacity = 4)
        {
            Formuls = Formul.generate_arr(capacity);
            right_answer = random.Next(capacity);
        }
        static public void set_poll(Button[] buttons,TextBlock question)
        {
            for(int i = 0;i < Formuls.Length; i++)
            {
                buttons[i].Content = Formuls[i].Definition;
            }
            question.Text = Formuls[right_answer].Name;
        }
        static public void fast_poll(Button[] buttons,TextBlock question, int capacity = 4)
        {
            make_poll(capacity);
            set_poll(buttons,question);
        }
        static public bool check_answer(Button clickedButton)
        {
            return (clickedButton.Content.ToString() == Formuls[right_answer].Definition);
        }
    }
}
