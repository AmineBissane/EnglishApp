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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace English_App
{
    /// <summary>
    /// Lógica de interacción para pregunta6.xaml
    /// </summary>
    public partial class pregunta6 : Page
    {
        private DispatcherTimer timer;
        private int secondsRemaining = 10;
        private int score;

        public pregunta6(int currentScore)
        {
            InitializeComponent();
            score = currentScore;
            StartTimer();
            QuestionImage.Source = new BitmapImage(new Uri("imgs/334289821-Baltimore_Oriole-Matthew_Plante.jpg", UriKind.Relative));
            Option1.Content = "A cat";
            Option2.Content = "A dog";
            Option3.Content = "A bird";
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;
            TimerText.Text = $"Tiempo restante: {secondsRemaining} segundos";
            TimerProgressBar.Value = 10 - secondsRemaining;

            if (secondsRemaining <= 0)
            {
                timer.Stop();
                NavigateToNextPage();
            }
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            if (sender is Button selectedButton && selectedButton.Content.ToString() == "A bird")
            {
                score++; 
            }

            NavigateToNextPage();
        }

        private void NavigateToNextPage()
        {
            NavigationService?.Navigate(new pregunta7(score));
        }
    }
}
