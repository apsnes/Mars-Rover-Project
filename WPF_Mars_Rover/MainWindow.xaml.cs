using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mars_Rover_Project;
using Mars_Rover_Project.Logic;

namespace WPF_Mars_Rover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Session _session = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _session;

            PlateauSize instance = PlateauSize.GetInstance();
            int cols = instance.Width;
            int rows = instance.Height;

            for (int i = 0; i < cols; i++)
            {
                MatrixGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < rows; i++)
            {
                MatrixGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Rectangle rectangle = new Rectangle
                    {
                        Fill = new SolidColorBrush(Colors.DarkRed),
                        Stroke = new SolidColorBrush(Colors.White),
                        StrokeThickness = 2
                    };
                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                    MatrixGrid.Children.Add(rectangle);
                }
            }

            Rover currentRover = _session.CurrentRover;
            Rectangle roverAsRectangle = new Rectangle
            {
                Fill = new SolidColorBrush(Colors.DarkBlue),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 2
            };
            Grid.SetRow(roverAsRectangle, currentRover.Position.X);
            Grid.SetColumn(roverAsRectangle, currentRover.Position.Y);
            MatrixGrid.Children.Add(roverAsRectangle);
        }
        private void OnClickMove(object sender, RoutedEventArgs e)
        {
            _session.Move();
        }
        private void OnClickTurnLeft(object sender, RoutedEventArgs e)
        {
            _session.TurnLeft();
        }
        private void OnClickTurnRight(object sender, RoutedEventArgs e)
        {
            _session.TurnRight();
        }
        private void OnClickSelectRover(object sender, RoutedEventArgs e)
        {
            //_session.SetCurrentRover();
        }
    }
}