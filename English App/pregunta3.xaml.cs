﻿using System;
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
    /// Lógica de interacción para pregunta3.xaml
    /// </summary>
    public partial class pregunta3 : Page
    {
        private DispatcherTimer timer;
        private int secondsRemaining = 20;
        private int score;

        public pregunta3(int currentScore)
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
            TimerText.Text = $"Tiempo restante: {secondsRemaining} segundos";
            TimerProgressBar.Value = 20 - secondsRemaining;

            if (secondsRemaining <= 0)
            {
                timer.Stop();
                CheckAnswerAndNavigate();
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            CheckAnswerAndNavigate();
        }

        private void CheckAnswerAndNavigate()
        {
         
            if (AnswerComboBox.SelectedItem is ComboBoxItem selectedItem &&
                selectedItem.Content.ToString().Contains("1. Went"))
            {
                score++;
            }

            NavigationService?.Navigate(new pregunta4(score));
        }
    }
}
