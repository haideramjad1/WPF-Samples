using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for Keyboard1.xaml
    /// </summary>
    public partial class Keyboard1 : Window
    {

        private string[] upperCaseKeys = { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P",
                                "A", "S", "D", "F", "G", "H", "J", "K", "L",
                                "Z", "X", "C", "V", "B", "N", "M" };

        private string[] lowerCaseKeys = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p",
                                   "a", "s", "d", "f", "g", "h", "j", "k", "l",
                                   "z", "x", "c", "v", "b", "n", "m" };

        private string[] numberKeys = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                                "@", "#", "$", "%", "&", "*", "(", ")", "-",
                                "+", "=", "!", "?", "/", ",", "." };

        private string[] shiftSpecialKeys = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")",
                                      "~", "`", "|", "\\", "/", ":", ";", "\"", "'",
                                      "<", ">", "[", "]", "{", "}", "_" };

        private bool IsShiftActive = false;
        private bool isNumericMode = false;


        public Keyboard1()
        {
            InitializeComponent();
        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Shift_Button_Click(object sender, RoutedEventArgs e)
        {
            IsShiftActive = !IsShiftActive;
            HighlightButton(Shift_Button, IsShiftActive);
            UpdateKeyboard();
        }

        private void Numeric_Button_Click(object sender, RoutedEventArgs e)
        {
            IsShiftActive = false;
            HighlightButton(Shift_Button, false);
            isNumericMode = !isNumericMode;
            HighlightButton(Numeric_Button, isNumericMode);
            UpdateKeyboard();

            if (Numeric_Button.Content.ToString() == "123")
            {
                Numeric_Button.Content = "abc";
            }
            else
            {
                Numeric_Button.Content = "123";
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void UpdateKeyboard()
        {
            Button[] buttons = { Q_Button, W_Button, E_Button, R_Button, T_Button, Y_Button,
                         U_Button, I_Button, O_Button, P_Button, A_Button, S_Button,
                         D_Button, F_Button, G_Button, H_Button, J_Button, K_Button,
                         L_Button, Z_Button, X_Button, C_Button, V_Button, B_Button,
                         N_Button, M_Button };

            string[] keysToUse;

            if (isNumericMode)
            {
                keysToUse = IsShiftActive ? shiftSpecialKeys : numberKeys;
            }
            else
            {
                keysToUse = IsShiftActive ? upperCaseKeys : lowerCaseKeys;
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Content = keysToUse[i];
            }
        }


        private void HighlightButton(System.Windows.Controls.Button button, bool isActive)
        {
            if (isActive)
            {
                var brushConverter = new BrushConverter();
                button.Background = (Brush)brushConverter.ConvertFrom("#868382");
            }
            else
            {
                var brushConverter = new BrushConverter();
                button.Background = (Brush)brushConverter.ConvertFrom("#2D2825");
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
