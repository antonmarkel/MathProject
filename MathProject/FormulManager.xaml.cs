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
    
        
        public Button makeButtonOfPriority(Priority_Enum priority,bool chosen)
        {
            switch (priority)
            {
               case Priority_Enum.High:

                      if(chosen)return  new Button()
                      {
                           Style = (Style)this.FindResource("circle_red_chosen"),
                           Content = ""
                      };
                     else return new Button()
                     {
                         Style = (Style)this.FindResource("circle_red"),
                         Content = ""
                     };

                case Priority_Enum.Medium:
                    if(chosen)return new Button()
                    {
                        Style = (Style)this.FindResource("circle_yellow_chosen"),
                        Content = ""
                    };
                    return new Button()
                    {
                        Style = (Style)this.FindResource("circle_yellow"),
                        Content = ""
                    };
                case Priority_Enum.Low:
                    if(chosen)return new Button()
                    {
                        Style = (Style)this.FindResource("circle_green_chosen"),
                        Content = ""
                    };
                    return new Button()
                    {
                        Style = (Style)this.FindResource("circle_green"),
                        Content = ""
                    };
                default:
                    return new Button() { Content = "ERROR" };
                }
            }
        
        Grid CreatenNewGridFormul(Formul parent_formul)
        {

            //Creating the main grid
            Grid grid = new Grid();
            grid.Margin = new Thickness(0,20,0,0);
            grid.ColumnDefinitions.Add(new ColumnDefinition() {Width = new GridLength(6,GridUnitType.Star)});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.Background = new SolidColorBrush(Color.FromRgb(185, 71, 96));
            //Border for the main grid
            Border border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1);

            //Name : Definition - Formula
            FormulaControl formul = new FormulaControl();
            formul.Formula = parent_formul.Name + " : " + parent_formul.Definition;
            formul.Scale = 30;
            formul.Margin = new Thickness(0, 5, 0, 5);
            Grid.SetColumn(formul, 0);

            //Creating Choosing_Option for Priority
            Grid innerGrid = new Grid();
            Grid.SetColumn(innerGrid, 1);
            //Define three Columns(three buttons)
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //Button for making a choice
            Button yellowButton = makeButtonOfPriority(Priority_Enum.Medium,parent_formul.Priority == Priority_Enum.Medium);
            Button greenButton = makeButtonOfPriority(Priority_Enum.Low, parent_formul.Priority == Priority_Enum.Low);
            Button redButton = makeButtonOfPriority(Priority_Enum.High,parent_formul.Priority == Priority_Enum.High);

            //Setting buttons
            Grid.SetColumn(redButton, 0);
            Grid.SetColumn(yellowButton, 1);
            Grid.SetColumn(greenButton, 2);

            //Add buttons to Choosing grid
            innerGrid.Children.Add(redButton);
            innerGrid.Children.Add(yellowButton);
            innerGrid.Children.Add(greenButton);

            //Add main components
            grid.Children.Add(formul);grid.Children.Add(innerGrid);
            grid.Children.Add(border);
            return grid;
        }


        private void test_add (object sender, RoutedEventArgs e)
        {
            Grid new_test = CreatenNewGridFormul(new Formul("test", "test",new string[0],Priority_Enum.Medium));
            stackPannel.Children.Add(new_test);
        }
    }
}
