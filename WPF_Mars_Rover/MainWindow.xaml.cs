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
using Mars_Rover_Project.Enums;

namespace WPF_Mars_Rover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Session _session = Session.GetInstance();
        PlateauSize _instance = PlateauSize.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _session;

            //Hard coded rover for building
            Position position = new(0, 0, Mars_Rover_Project.Enums.Direction.North);
            _session.AddRover(position, 1);
            _session.CurrentRover = _session.Rovers.First();

            CreateMatrix();

            //Rover currentRover = _session.CurrentRover;
            //Rectangle roverAsRectangle = new Rectangle
            //{
            //    Fill = new SolidColorBrush(Colors.DarkBlue),
            //    Stroke = new SolidColorBrush(Colors.White),
            //    StrokeThickness = 2
            //};
            //Grid.SetRow(roverAsRectangle, (_session.Plateau.Height - 1 - currentRover.Position.Y));
            //Grid.SetColumn(roverAsRectangle, currentRover.Position.X); 
            //MatrixGrid.Children.Add(roverAsRectangle);
        }
        private void CreateMatrix()
        {
            MatrixGrid.Children.Clear();
            MatrixGrid.RowDefinitions.Clear();
            MatrixGrid.ColumnDefinitions.Clear();

            int cols = _instance.Width;
            int rows = _instance.Height;

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
                    Rover currentRover = _session.CurrentRover;
                    Rectangle rectangle;
                    if (i == (_session.Plateau.Height - 1 - _session.CurrentRover.Position.Y) && j == _session.CurrentRover.Position.X)
                    {
                        rectangle = new Rectangle
                        {
                            Fill = new SolidColorBrush(Colors.DarkBlue),
                            Stroke = new SolidColorBrush(Colors.White),
                            StrokeThickness = 2
                        };
                    }
                    else
                    {
                        rectangle = new Rectangle
                        {
                            Fill = new SolidColorBrush(Colors.DarkRed),
                            Stroke = new SolidColorBrush(Colors.White),
                            StrokeThickness = 2
                        };
                    }
                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                    MatrixGrid.Children.Add(rectangle);
                }
            }
        }
        private void OnClickMove(object sender, RoutedEventArgs e)
        {
            _session.CurrentRover.Move();
            _session.CurrentRover.Position.PositionString = $"{_session.CurrentRover.Position.X}, {_session.CurrentRover.Position.Y}, {_session.CurrentRover.Position.Direction}";
            CreateMatrix();
        }
        private void OnClickTurnLeft(object sender, RoutedEventArgs e)
        {
            _session.CurrentRover.Instruct(Instruction.L);
            _session.CurrentRover.Position.PositionString = $"{_session.CurrentRover.Position.X}, {_session.CurrentRover.Position.Y}, {_session.CurrentRover.Position.Direction}";
        }
        private void OnClickTurnRight(object sender, RoutedEventArgs e)
        {
            _session.CurrentRover.Instruct(Instruction.R);
            _session.CurrentRover.Position.PositionString = $"{_session.CurrentRover.Position.X}, {_session.CurrentRover.Position.Y}, {_session.CurrentRover.Position.Direction}";
        }
        private void OnClickSelectRover(object sender, RoutedEventArgs e)
        {
            //_session.SetCurrentRover();
        }
    }
}