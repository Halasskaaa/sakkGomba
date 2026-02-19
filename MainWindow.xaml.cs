using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sakkGomba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int BoardSize = 8;
        const int CellSize = 60;
        public MainWindow()
        {
            InitializeComponent();
            DrawBoard();
        }

        public void DrawBoard()
        {
            gameCanvas.Children.Clear();

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Rectangle square = new Rectangle
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Fill = (row + col) % 2 == 0 ? Brushes.White : Brushes.DarkGray
                    };
                    Canvas.SetLeft(square, col * CellSize);
                    Canvas.SetTop(square, row * CellSize);

                    gameCanvas.Children.Add(square);
                }
            }
        }

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void RestartButton_Click(object sender, RoutedEventArgs e)
		{

		}
		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{

		}

	}
}