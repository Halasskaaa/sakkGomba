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

        Image currentPieceImage;
        Random rnd = new Random();

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

		private void btn_start_Click(object sender, RoutedEventArgs e)
		{
            scr_menu.Visibility = Visibility.Collapsed;
            scr_piece.Visibility = Visibility.Visible;
		}

		private void btn_exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void btn_back_Click(object sender, RoutedEventArgs e)
		{
            scr_menu.Visibility = Visibility.Visible;
            scr_piece.Visibility = Visibility.Collapsed;
		}

		private void btn_restart_Click(object sender, RoutedEventArgs e)
		{

		}

        private void cbtn_rook_Click(object sender, RoutedEventArgs e)
        {
            scr_piece.Visibility = Visibility.Collapsed;

            DrawBoard();
            PlaceRook();
        }

        private void PlaceRook()
        {
            if (currentPieceImage != null)
            {
                gameCanvas.Children.Remove(currentPieceImage);
            }

            currentPieceImage = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images/rook.png")),
                Width = CellSize,
                Height = CellSize
            };

            int randomRow = rnd.Next(0, BoardSize);
            int randomColumn = rnd.Next(0, BoardSize);

            Canvas.SetLeft(currentPieceImage, 3 * CellSize);
            Canvas.SetTop(currentPieceImage, 3 * CellSize);

            gameCanvas.Children.Add(currentPieceImage);
        }
    }
}