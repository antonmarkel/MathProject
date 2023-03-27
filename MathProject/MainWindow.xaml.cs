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
using WpfMath.Controls;

namespace MathProject
{

    class ChoiceButton
    {
        public Button button;
        public string ID;

        public ChoiceButton(Button button, string ID)
        {
            this.button = button;
            this.ID = ID;
        }
    }
    public partial class MainWindow : Window
    {
        static ChoiceButton[] Answer_buttons;
        static FormulaControl[] But_formuls;

        void init_buttons()
        {
            Answer_buttons = new ChoiceButton[] {   new ChoiceButton(first_answer,"first_answer"),
                 new ChoiceButton(second_answer,"second_answer"),  new ChoiceButton(third_answer,"third_answer"),  new ChoiceButton(fourth_answer,"fourth_answer") };



            But_formuls = new FormulaControl[] { Formul1, Formul2, Formul3, Formul4, };
        }

        public MainWindow()
        {
            InitializeComponent();
            init_buttons();
            Poll.fast_poll(But_formuls,Question_textBlock);
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
                    Poll.fast_poll(But_formuls, Question_textBlock);
                }
            );

            Console.WriteLine("Ho");
        }
        private void test_change(object sender, RoutedEventArgs e)
        {
            FormulManager forTest = new FormulManager();
            this.Hide();
            forTest.Show();
            this.Close();
        }
        private void choosen(object sender, RoutedEventArgs e)
        {

            Button clickedButton = (Button)sender;
            int index = 0;
            foreach(ChoiceButton but in Answer_buttons)
            {
                if (clickedButton.Name == but.ID) break;
                index++;
            }
            if (index == 4) throw new Exception();
            bool result = Poll.check_answer(index);


            if (result)
            {
              Thread thread = new Thread(test_set_background);
                thread.Start();
            }
            else
            {
                Poll.fast_poll(But_formuls, Question_textBlock);
            }
        }
    }
}
