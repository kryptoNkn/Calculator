using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorGUI
{
    public partial class MainWindow : Window
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                inputBox.Text += button.Content.ToString();
                PlaceholderText.Visibility = Visibility.Collapsed; 
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (double.TryParse(inputBox.Text, out firstNumber))
                {
                    inputBox.Clear();
                    operation = button.Content.ToString();
                }
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(inputBox.Text, out secondNumber))
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: деление на ноль.");
                            return;
                        }
                        break;
                }

                inputBox.Text = result.ToString();
                operation = string.Empty;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            inputBox.Clear();
            firstNumber = 0;
            secondNumber = 0;
            operation = string.Empty;
            PlaceholderText.Visibility = Visibility.Visible; 
        }

        private void InputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputBox.Text))
            {
                PlaceholderText.Visibility = Visibility.Collapsed; 
            }
        }

        private void InputBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputBox.Text))
            {
                PlaceholderText.Visibility = Visibility.Visible; 
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!inputBox.Text.Contains("."))
            {
                inputBox.Text += ".";
            }
        }

        private void FunctionsButton_Click(object sender, RoutedEventArgs e)
        {
            FunctionsPopup.IsOpen = !FunctionsPopup.IsOpen;
        }

        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                string function = button.Content.ToString();
                if (double.TryParse(inputBox.Text, out firstNumber))
                {
                    double result = 0;

                    switch (function)
                    {
                        case "sqrt":
                            if (firstNumber >= 0)
                                result = Math.Sqrt(firstNumber);
                            else
                                MessageBox.Show("Ошибка: извлечение корня из отрицательного числа.");
                            break;
                        case "log10":
                            if (firstNumber > 0)
                                result = Math.Log10(firstNumber);
                            else
                                MessageBox.Show("Ошибка: логарифм от отрицательного числа.");
                            break;
                        case "ln":
                            if (firstNumber > 0)
                                result = Math.Log(firstNumber);
                            else
                                MessageBox.Show("Ошибка: логарифм от отрицательного числа.");
                            break;
                        case "sin":
                            result = Math.Sin(firstNumber);
                            break;
                        case "cos":
                            result = Math.Cos(firstNumber);
                            break;
                        case "tg":
                            result = Math.Tan(firstNumber);
                            break;
                        case "ctg":
                            result = 1 / Math.Tan(firstNumber);
                            break;
                    }

                    inputBox.Text = result.ToString();
                }
            }
        }
    }
}
