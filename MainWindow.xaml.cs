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
using System.Threading.Tasks;

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

        List<Point> mushrooms = new List<Point>();
        int currentMushroomIndex = 0;

        int pieceRow;
        int pieceCol;

        string currentPieceType = "rook"; // rook, bishop, knight, queen

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

        //buttons
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
            scr_gameOver.Visibility = Visibility.Collapsed;
            DrawBoard();

            switch (currentPieceType)
            {
                case "rook":
                    PlaceRook();
                    break;
                case "bishop":
                    PlaceBishop();
                    break;
                case "knight":
                    PlaceKnight();
                    break;
                case "queen":
                    PlaceQueen();
                    break;
            }
        }
        private void btn_changePiece_Click(object sender, RoutedEventArgs e)
        {
            scr_gameOver.Visibility = Visibility.Collapsed;
            gameControlsOverlay.Visibility = Visibility.Collapsed;
            scr_piece.Visibility = Visibility.Visible;

            DrawBoard();

            if (currentPieceImage != null)
            {
                gameCanvas.Children.Remove(currentPieceImage);
                currentPieceImage = null;
            }

            mushrooms.Clear();
            currentMushroomIndex = 0;
        }

        //sakkBábuKiválasztása

        private void cbtn_rook_Click(object sender, RoutedEventArgs e)
        {
            currentPieceType = "rook";

            scr_piece.Visibility = Visibility.Collapsed;

            DrawBoard();
            PlaceRook();

            gameControlsOverlay.Visibility = Visibility.Visible;
        }
        private void cbtn_bishop_Click(object sender, RoutedEventArgs e)
        {
            currentPieceType = "bishop";

            scr_piece.Visibility = Visibility.Collapsed;

            DrawBoard();
            PlaceBishop();

            gameControlsOverlay.Visibility = Visibility.Visible;
        }

        private void cbtn_knight_Click(object sender, RoutedEventArgs e)
        {
            currentPieceType = "knight";

            scr_piece.Visibility = Visibility.Collapsed;

            DrawBoard();
            PlaceKnight();

            gameControlsOverlay.Visibility = Visibility.Visible;
        }

        private void cbtn_queen_Click(object sender, RoutedEventArgs e)
        {
            currentPieceType = "queen";

            scr_piece.Visibility = Visibility.Collapsed;

            DrawBoard();
            PlaceQueen();

            gameControlsOverlay.Visibility = Visibility.Visible;
        }

        //in_gameButtons
        private void btn_backGame_Click(object sender, RoutedEventArgs e)
        {
            gameControlsOverlay.Visibility = Visibility.Collapsed;

            scr_piece.Visibility = Visibility.Visible;

            DrawBoard();

            if (currentPieceImage != null)
            {
                gameCanvas.Children.Remove(currentPieceImage);
                currentPieceImage = null;
            }

            mushrooms.Clear();
            currentMushroomIndex = 0;
        }
        private void btn_exitGame_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //BábukMűködése
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

            pieceRow = rnd.Next(0, BoardSize);
            pieceCol = rnd.Next(0, BoardSize);

            Canvas.SetLeft(currentPieceImage, pieceCol * CellSize);
            Canvas.SetTop(currentPieceImage, pieceRow * CellSize);

            gameCanvas.Children.Add(currentPieceImage);

            GenerateMushrooms();
        }

        private void PlaceBishop()
        {
            if (currentPieceImage != null)
                gameCanvas.Children.Remove(currentPieceImage);

            currentPieceImage = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images/bishop.png")),
                Width = CellSize,
                Height = CellSize
            };

            pieceRow = rnd.Next(0, BoardSize);
            pieceCol = rnd.Next(0, BoardSize);

            Canvas.SetLeft(currentPieceImage, pieceCol * CellSize);
            Canvas.SetTop(currentPieceImage, pieceRow * CellSize);

            gameCanvas.Children.Add(currentPieceImage);

            GenerateMushrooms();
        }
        private void PlaceKnight()
        {
            if (currentPieceImage != null)
                gameCanvas.Children.Remove(currentPieceImage);

            currentPieceImage = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images/knight.png")),
                Width = CellSize,
                Height = CellSize
            };

            pieceRow = rnd.Next(0, BoardSize);
            pieceCol = rnd.Next(0, BoardSize);

            Canvas.SetLeft(currentPieceImage, pieceCol * CellSize);
            Canvas.SetTop(currentPieceImage, pieceRow * CellSize);

            gameCanvas.Children.Add(currentPieceImage);

            GenerateMushrooms();
        }
        private void PlaceQueen()
        {
            if (currentPieceImage != null)
                gameCanvas.Children.Remove(currentPieceImage);

            currentPieceImage = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images/queen.png")),
                Width = CellSize,
                Height = CellSize
            };

            pieceRow = rnd.Next(0, BoardSize);
            pieceCol = rnd.Next(0, BoardSize);

            Canvas.SetLeft(currentPieceImage, pieceCol * CellSize);
            Canvas.SetTop(currentPieceImage, pieceRow * CellSize);

            gameCanvas.Children.Add(currentPieceImage);

            GenerateMushrooms();
        }


        private void GenerateMushrooms()
        {
            mushrooms.Clear();
            currentMushroomIndex = 0;

            Point currentPos = new Point(pieceRow, pieceCol);

            for (int i = 0; i < 5; i++)
            {
                Point next;

                do
                {
                    int r = rnd.Next(0, BoardSize);
                    int c = rnd.Next(0, BoardSize);
                    next = new Point(r, c);

                }
                while (
                    !IsValidMove(currentPos, next) || mushrooms.Contains(next) || (next.X == pieceRow && next.Y == pieceCol)
                );

                mushrooms.Add(next);
                currentPos = next;

                PlaceMushroomImage(next, i);
            }
        }

        private void PlaceMushroomImage(Point pos, int index)
        {
            Image img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images/mushroom.png")),
                Width = CellSize,
                Height = CellSize,
                Tag = index
            };

            img.MouseLeftButtonDown += Mushroom_Click;

            Canvas.SetLeft(img, pos.Y * CellSize);
            Canvas.SetTop(img, pos.X * CellSize);

            gameCanvas.Children.Add(img);
        }

        private void Mushroom_Click(object sender, MouseButtonEventArgs e)
        {
            Image clicked = sender as Image;
            int index = (int)clicked.Tag;

            Point target = mushrooms[index];
            Point currentPos = new Point(pieceRow, pieceCol);

            if (index == currentMushroomIndex && IsValidMove(currentPos, target))
            {
                ShowSmile(true);

                pieceRow = (int)target.X;
                pieceCol = (int)target.Y;

                MovePiece();
                gameCanvas.Children.Remove(clicked);

                currentMushroomIndex++;

                if (currentMushroomIndex == 5)
                {
                    scr_gameOver.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ShowSmile(false);
            }
        }

        private void MovePiece()
        {
            Canvas.SetLeft(currentPieceImage, pieceCol * CellSize);
            Canvas.SetTop(currentPieceImage, pieceRow * CellSize);
        }

        private async void ShowSmile(bool good)
        {
            Image feedback = new Image
            {
                Source = new BitmapImage(new Uri(
                    good
                    ? "pack://application:,,,/images/smile.png"
                    : "pack://application:,,,/images/sad.png")),
                Width = 100,
                Height = 100
            };

            Canvas.SetLeft(feedback, (BoardSize * CellSize) / 2 - 50);
            Canvas.SetTop(feedback, (BoardSize * CellSize) / 2 - 50);

            gameCanvas.Children.Add(feedback);

            await Task.Delay(800);

            gameCanvas.Children.Remove(feedback);
        }

        private bool IsValidMove(Point from, Point to)
        {
            int dr = (int)Math.Abs(to.X - from.X);
            int dc = (int)Math.Abs(to.Y - from.Y);

            switch (currentPieceType)
            {
                case "rook":
                    return dr == 0 || dc == 0;

                case "bishop":
                    return dr == dc;

                case "queen":
                    return dr == 0 || dc == 0 || dr == dc;

                case "knight":
                    return (dr == 2 && dc == 1) || (dr == 1 && dc == 2);
            }

            return false;
        }
    }
}