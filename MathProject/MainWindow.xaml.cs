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
        private void test_set_background()
        {
         
            this.Dispatcher.BeginInvoke((ThreadStart)delegate()
                {
                    ImageBrush test = new ImageBrush();
                    test.ImageSource = new BitmapImage(new Uri(@"Images\test_background.png", UriKind.Relative));
                    this.Background = test;
                }
            );
            Thread.Sleep(1000);
            this.Dispatcher.BeginInvoke((ThreadStart)delegate()
                {
                    ImageBrush test = new ImageBrush();
                    test.ImageSource = new BitmapImage(new Uri(@"Images\standard_background.png", UriKind.Relative));
                    this.Background = test;

                     Poll.fast_poll(Answer_buttons, Question_textBlock);
                }
            );
        }
        private void choosen(object sender, RoutedEventArgs e)
        {
            bool result = Poll.check_answer((Button)sender);
            if (result)
            {
              Thread thread = new Thread(test_set_background);
                thread.Start();
            }
            else
            {
                Poll.fast_poll(Answer_buttons, Question_textBlock);
            }
        }
    }
}
