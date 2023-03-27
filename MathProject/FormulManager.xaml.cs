using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfMath;
using WpfMath.Controls;
using XamlMath.Colors;

namespace MathProject
{


   public class DifficultButton : Button
    {
        public Formul ?formul { get; set; }
        public Grid ?grid { get; set; }

        public Priority_Enum priority { get; set; }

    }

    public partial class FormulManager : Window
    {
        public FormulManager()
        {
            InitializeComponent();

            #region Upload Formuls
            foreach (var formul in Formul.ALL_FORMULS ?? new List<Formul>(0))
            {
                Grid gr = CreatenNewGridFormul(formul);
                stackPannel.Children.Add(gr);
            }
            #endregion


        }


        public Style getProperStyle(Priority_Enum priority, bool chosen)
        {
            switch (priority)
            {
                case Priority_Enum.High:
                    if (chosen) return (Style)this.FindResource("circle_red_chosen");
                    else return (Style)this.FindResource("circle_red");

                case Priority_Enum.Medium:
                    if (chosen) return (Style)this.FindResource("circle_yellow_chosen");
                    else return (Style)this.FindResource("circle_yellow");

                case Priority_Enum.Low:
                    if (chosen) return (Style)this.FindResource("circle_green_chosen");
                    else return (Style)this.FindResource("circle_green");
                default:
                    return (Style)this.FindResource("circle_red_chosen");
            }
        }


        public DifficultButton makeButtonOfPriority(Priority_Enum priority, bool chosen)
        {
            switch (priority)
            {
                case Priority_Enum.High:

                    if (chosen) return new DifficultButton()
                    {
                        priority = Priority_Enum.High,
                        Style = (Style)this.FindResource("circle_red_chosen"),
                        Content = ""
                    };
                    else return new DifficultButton()
                    {
                        priority = Priority_Enum.High,
                        Style = (Style)this.FindResource("circle_red"),
                        Content = ""
                    };

                case Priority_Enum.Medium:
                    if (chosen) return new DifficultButton()
                    {
                        priority = Priority_Enum.Medium,
                        Style = (Style)this.FindResource("circle_yellow_chosen"),
                        Content = ""
                    };
                    return new DifficultButton()
                    {
                        priority = Priority_Enum.Medium,
                        Style = (Style)this.FindResource("circle_yellow"),
                        Content = ""
                    };
                case Priority_Enum.Low:
                    if (chosen) return new DifficultButton()
                    {
                        priority = Priority_Enum.Low,
                        Style = (Style)this.FindResource("circle_green_chosen"),
                        Content = ""
                    };
                    return new DifficultButton()
                    {
                        priority = Priority_Enum.Low,
                        Style = (Style)this.FindResource("circle_green"),
                        Content = ""
                    };
                default:
                    return new DifficultButton() { Content = "ERROR" };
            }
        }

        Grid CreatenNewGridFormul(Formul parent_formul)
        {

            //Creating the main grid
            Grid grid = new Grid();
            grid.Margin = new Thickness(0, 20, 0, 0);
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(6, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.Background = new SolidColorBrush(Color.FromRgb(185, 71, 96));
            //Border for the main grid
            Border border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1);

            //Name : Definition - Formula
            FormulaControl formul = new FormulaControl();
            formul.Formula = parent_formul.Name + " = " + parent_formul.Definition;
            formul.Scale = 30;
            formul.Margin = new Thickness(5, 5, 0, 5);
            Grid.SetColumn(formul, 0);

            //Creating Choosing_Option for Priority
            Grid innerGrid = new Grid();
            Grid.SetColumn(innerGrid, 1);
            //Define three Columns(three buttons)
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //Button for making a choice
            DifficultButton yellowButton = makeButtonOfPriority(Priority_Enum.Medium, parent_formul.Priority == Priority_Enum.Medium);
            DifficultButton greenButton = makeButtonOfPriority(Priority_Enum.Low, parent_formul.Priority == Priority_Enum.Low);
            DifficultButton redButton = makeButtonOfPriority(Priority_Enum.High, parent_formul.Priority == Priority_Enum.High);
            yellowButton.formul = greenButton.formul = redButton.formul = parent_formul;
            yellowButton.grid = greenButton.grid = redButton.grid = innerGrid;
            yellowButton.Click += difficultButtonClick; greenButton.Click += difficultButtonClick;
            redButton.Click += difficultButtonClick;

            //Delete-Button
            DifficultButton deleteButton = new DifficultButton()
            {
                Style = (Style)this.FindResource("circle_delete"),
            };

            //Setting buttons
            Grid.SetColumn(redButton, 2);
            Grid.SetColumn(yellowButton, 1);
            Grid.SetColumn(greenButton, 0);
            Grid.SetColumn(deleteButton, 3);

            //Add buttons to Choosing grid
            innerGrid.Children.Add(greenButton);
            innerGrid.Children.Add(yellowButton);
            innerGrid.Children.Add(redButton);
            innerGrid.Children.Add(deleteButton);
           
            

            //Add main components
            grid.Children.Add(formul); grid.Children.Add(innerGrid);
            grid.Children.Add(border);
            return grid;
        }

        private void difficultButtonClick(object sender, RoutedEventArgs e)
        {
            DifficultButton cur = (DifficultButton)sender;

            if (cur.formul != null) { cur.formul.Priority = cur.priority; }
            else MessageBox.Show("Error Null");

            if (cur.grid != null)
            {
                foreach (var child in cur.grid.Children)
                {
                    if (((DifficultButton)child).priority != cur.priority) ((DifficultButton)child).Style = getProperStyle(((DifficultButton)child).priority, false);
                    else ((DifficultButton)child).Style = getProperStyle(((DifficultButton)child).priority, true);
                }
            }
            else MessageBox.Show("Error Null");

        }

        private void test_add(object sender, RoutedEventArgs e)
        {
            if (new_formul_formul.Text == "Formul : LaTex style or name" ||
                new_formul_definition.Text == "Definition : LaTex style")
            {
                MessageBox.Show("Don't be stupid,kid");
            }
            else
            {
                Formul dick = new Formul(new_formul_formul.Text.Replace("\\", "\\"), new_formul_definition.Text, new string[0], Priority_Enum.Medium);
                Grid new_test = CreatenNewGridFormul(dick);
                stackPannel.Children.Insert(0, new_test);
                Formul.ALL_FORMULS.Insert(0, dick);
            }

        }

        private void save_formuls(object sender, RoutedEventArgs e)
        {
            INIT.SAVE_DATA();
        }

        private void back_to_main(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            Formul.update_formuls();
            mainWindow.Show();
            this.Close();
        }
    }
}
