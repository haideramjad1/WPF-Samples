using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for SarchCustomer1.xaml
    /// </summary>
    public partial class SarchCustomer1 : Window
    {
        private bool IsCapsLockActive = false;
        private bool IsShiftActive = false;

        public SarchCustomer1()
        {
            InitializeComponent();
            SearchTextBox.Focus();
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceholderTextBlock.Visibility = Visibility.Collapsed;
            }
        }



        private void UpdateKeyboardCase()
        {
            UpdateLetterButton(Q_Button, "Q", "q");
            UpdateLetterButton(W_Button, "W", "w");
            UpdateLetterButton(E_Button, "E", "e");
            UpdateLetterButton(R_Button, "R", "r");
            UpdateLetterButton(T_Button, "T", "t");
            UpdateLetterButton(Y_Button, "Y", "y");
            UpdateLetterButton(U_Button, "U", "u");
            UpdateLetterButton(I_Button, "I", "i");
            UpdateLetterButton(O_Button, "O", "o");
            UpdateLetterButton(P_Button, "P", "p");

            UpdateLetterButton(A_Button, "A", "a");
            UpdateLetterButton(S_Button, "S", "s");
            UpdateLetterButton(D_Button, "D", "d");
            UpdateLetterButton(F_Button, "F", "f");
            UpdateLetterButton(G_Button, "G", "g");
            UpdateLetterButton(H_Button, "H", "h");
            UpdateLetterButton(J_Button, "J", "j");
            UpdateLetterButton(K_Button, "K", "k");
            UpdateLetterButton(L_Button, "L", "l");

            UpdateLetterButton(Z_Button, "Z", "z");
            UpdateLetterButton(X_Button, "X", "x");
            UpdateLetterButton(C_Button, "C", "c");
            UpdateLetterButton(V_Button, "V", "v");
            UpdateLetterButton(B_Button, "B", "b");
            UpdateLetterButton(N_Button, "N", "n");
            UpdateLetterButton(M_Button, "M", "m");
        }

        private void SwapAllTextBetweenButtons()
        {
            SwapTextBetweenButtons(ColonText1_Button, ColonText2_Button);
            SwapTextBetweenButtons(QuoteText1_Button, QuoteText2_Button);
            SwapTextBetweenButtons(FlowerParantheses1_Button, SquareParantheses1_Button);
            SwapTextBetweenButtons(FlowerParantheses2_Button, SquareParantheses2_Button);

            SwapTextBetweenButtons(QuestionMark_Button, ForwardSlash_Button);
            SwapTextBetweenButtons(Pipe_Button, BackSlash_Button);
            SwapTextBetweenButtons(TildeText1_Button, BacktickText2_Button);

            SwapTextBetweenButtons(NotText1_Button, OneText2_Button);
            SwapTextBetweenButtons(AtRateText1_Button, TwoText2_Button);
            SwapTextBetweenButtons(HashText1_Button, ThreeText2_Button);
            SwapTextBetweenButtons(DolllarText1_Button, FourText2_Button);

            SwapTextBetweenButtons(PercentText1_Button, FiveText2_Button);
            SwapTextBetweenButtons(CircumflexText1_Button, SixText2_Button);
            SwapTextBetweenButtons(AndText1_Button, SevenText2_Button);

            SwapTextBetweenButtons(SetaricText1_Button, EightText2_Button);
            SwapTextBetweenButtons(LeftParanthesesText1_Button, NineText2_Button);
            SwapTextBetweenButtons(RghtParanthesesText1_Button, ZeroText2_Button);

            SwapTextBetweenButtons(PlusText1_Button, EqualText2_Button);
            SwapTextBetweenButtons(UnderScoreText1_Button, SubtractText2_Button);
            SwapTextBetweenButtons(LessText1_Button, ComaText2_Button);
            SwapTextBetweenButtons(GreaterText1_Button, DotText2_Button);
        }

        private void UpdateLetterButton(Button button, string upperCaseText, string lowerCaseText)
        {
            if (IsCapsLockActive && IsShiftActive)
            {
                button.Content = lowerCaseText; // CapsLock + Shift = Lowercase
            }
            else if (IsShiftActive || IsCapsLockActive)
            {
                button.Content = upperCaseText;
            }
            else
            {
                button.Content = lowerCaseText;
            }
        }

        private void SwapTextBetweenButtons(TextBlock textBlock1, TextBlock textBlock2)
        {
            string tempText = textBlock1.Text;
            textBlock1.Text = textBlock2.Text;
            textBlock2.Text = tempText;
        }

        private void CapsLock_Button_Click(object sender, RoutedEventArgs e)
        {
            IsCapsLockActive = !IsCapsLockActive;
            HighlightButton(CapsLock_Button, IsCapsLockActive);
            UpdateKeyboardCase();
        }

        private void Shift_Button_Click(object sender, RoutedEventArgs e)
        {
            IsShiftActive = !IsShiftActive;
            HighlightButton(Shift_Button, IsShiftActive);
            UpdateKeyboardCase();

            SwapAllTextBetweenButtons();
        }

        private void HighlightButton(Button button, bool isActive)
        {
            if (isActive)
            {
                button.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else
            {
                var brushConverter = new BrushConverter();
                button.Background = (Brush)brushConverter.ConvertFrom("#eee");
            }
        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;


            if (button.Name == "Space_Button")
            {
                int caretIndex = SearchTextBox.CaretIndex;
                SearchTextBox.Text = SearchTextBox.Text.Substring(0, caretIndex) + " " + SearchTextBox.Text.Substring(caretIndex);
                SearchTextBox.CaretIndex = caretIndex + 1;
            }
            else if (button.Name == "Tab_Button")
            {
                int caretIndex = SearchTextBox.CaretIndex;
                SearchTextBox.Text = SearchTextBox.Text.Substring(0, caretIndex) + "\t" + SearchTextBox.Text.Substring(caretIndex);
                SearchTextBox.CaretIndex = caretIndex + 1;
            }
            else if (button.Name == "Back_Button")
            {
                HandleBackButton();
            }
            else if (button.Name == "Close_Button")
            {
                this.Close();
            }

            else if (button.Content is string text)
            {
                string finalText;

                if (IsCapsLockActive && IsShiftActive)
                {
                    finalText = text.ToLower();
                }
                else if (IsCapsLockActive || IsShiftActive)
                {
                    finalText = text.ToUpper();
                }
                else if (IsCapsLockActive && !IsShiftActive)
                {
                    finalText = text.ToUpper();
                }
                else
                {
                    finalText = text.ToLower();
                }

                InsertTextAtCaret(finalText);
            }

            else if (button.Content is Grid grid)
            {
                var selectedChild = IsShiftActive
                    ? grid.Children.OfType<TextBlock>().FirstOrDefault()
                    : grid.Children.OfType<TextBlock>().LastOrDefault();

                if (selectedChild != null)
                {
                    int caretIndex = SearchTextBox.CaretIndex;
                    SearchTextBox.Text = SearchTextBox.Text.Substring(0, caretIndex) + selectedChild.Text + SearchTextBox.Text.Substring(caretIndex);
                    SearchTextBox.CaretIndex = caretIndex + selectedChild.Text.Length;
                }
            }

            SearchTextBox.Focus();

            if (IsShiftActive)
            {
                IsShiftActive = !IsShiftActive;
                HighlightButton(Shift_Button, IsShiftActive);
                UpdateKeyboardCase();
                SwapAllTextBetweenButtons();
            }
        }

        private void InsertTextAtCaret(string newText)
        {
            var caretIndex = SearchTextBox.CaretIndex;
            var currentText = SearchTextBox.Text;

            if (SearchTextBox.SelectionLength > 0)
            {
                SearchTextBox.SelectedText = newText;
            }
            else
            {
                SearchTextBox.Text = currentText.Substring(0, caretIndex) + newText + currentText.Substring(caretIndex);
                SearchTextBox.CaretIndex = caretIndex + newText.Length;
            }
        }

        private void HandleBackButton()
        {
            if (SearchTextBox.SelectionLength > 0)
            {
                SearchTextBox.SelectedText = string.Empty;
            }
            else
            {
                var caretIndex = SearchTextBox.CaretIndex;

                if (caretIndex > 0)
                {
                    SearchTextBox.Text = SearchTextBox.Text.Remove(caretIndex - 1, 1);
                    SearchTextBox.CaretIndex = caretIndex - 1;
                }
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
