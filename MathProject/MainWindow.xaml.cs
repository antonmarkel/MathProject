using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathProject
{
 
    public partial class MainWindow : Window
    {
        static Button[] Answer_buttons;

        void init_buttons()
        {
            Answer_buttons = new Button[] { first_answer, second_answer, third_answer, fourth_answer };
        }

        public MainWindow()
        {
            InitializeComponent();
            Answer_buttons = new Button[] { first_answer, second_answer, third_answer, fourth_answer };
            init_buttons();
            Poll.fast_poll(Answer_buttons,Question_textBlock);
        }

        private void choosen(object sender, RoutedEventArgs e)
        {
            bool result = Poll.check_answer((Button)sender);
            else { Question_textBlock.Background = new SolidColorBrush(Colors.Red); }
            Question_textBlock.Background = new SolidColorBrush(Colors.White);
            Poll.fast_poll(Answer_buttons, Question_textBlock);
        }
    }
}
