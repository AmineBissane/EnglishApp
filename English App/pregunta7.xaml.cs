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
    public partial class pregunta7 : Page
    {
        private DispatcherTimer timer;
        private int secondsRemaining = 10;
        private int score;

        public pregunta7(int currentScore)
        {
            InitializeComponent();
            score = currentScore;
            StartTimer();
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
            TimerText.Text = $"Time Remaining: {secondsRemaining} seconds";
            TimerProgressBar.Value = 10 - secondsRemaining;

            if (secondsRemaining <= 0)
            {
                timer.Stop();
                NavigateToNextPage();
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            if (YellowRadioButton.IsChecked == true) 
            {
                score++; 
            }

            NavigateToNextPage();
        }

        private void NavigateToNextPage()
        {
            NavigationService?.Navigate(new pregunta6(score)); 
        }
    }
}
