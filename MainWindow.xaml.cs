using System.Text;
using System.Windows;

namespace Caesar_Cipher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Hook up the event handler
            Plaintext_Btn.Click += Plaintext_Btn_Click;
            Encrypt_Btn.Click += Encrypt_Btn_Click;
            Decrypt_Btn.Click += Decrypt_Btn_Click;
            Clear_Btn.Click += Clear_Btn_Click;
        }

        private void Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Plaintext_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Enable the buttons and text box
            Encrypt_Btn.IsEnabled = true;
            Decrypt_Btn.IsEnabled = true;
            Clear_Btn.IsEnabled = true;
            Txb_EnDecrypt.IsEnabled = true;
        }

        private void Encrypt_Btn_Click(object sender, RoutedEventArgs e)
        {
            string plaintext = Txb_EnDecrypt.Text;
            string encryptedText = Encrypt(plaintext);

            Txb_EnDecrypt.Text = encryptedText;
            Lbl_Info.Content = "Encrypted Successfully";
        }

        private void Decrypt_Btn_Click(object sender, RoutedEventArgs e)
        {
            string ciphertext = Txb_EnDecrypt.Text;
            string decryptedText = Decrypt(ciphertext);

            Txb_EnDecrypt.Text = decryptedText;
            Lbl_Info.Content = "Decrypted Successfully";
        }

        private void Clear_Btn_Click(object sender, RoutedEventArgs e)
        {
            Txb_EnDecrypt.Clear();
            Lbl_Info.Content = "Please Insert Text";
        }

        private string Encrypt(string plaintext)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in plaintext)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = c;

                    if (char.IsLower(c))
                    {
                        // Encrypt lowercase letter
                        encryptedChar = (char)((c - 'a' + 3) % 26 + 'a');
                    }
                    else if (char.IsUpper(c))
                    {
                        // Encrypt uppercase letter
                        encryptedChar = (char)((c - 'A' + 3) % 26 + 'A');
                    }

                    encryptedText.Append(encryptedChar);
                }
                else
                {
                    // Keep non-letter characters as they are
                    encryptedText.Append(c);
                }
            }

            return encryptedText.ToString();
        }

        private string Decrypt(string ciphertext)
        {
            StringBuilder decryptedText = new StringBuilder();

            foreach (char c in ciphertext)
            {
                if (char.IsLetter(c))
                {
                    char decryptedChar = c;

                    if (char.IsLower(c))
                    {
                        // Decrypt lowercase letter
                        decryptedChar = (char)((c - 'a' - 3 + 26) % 26 + 'a');
                    }
                    else if (char.IsUpper(c))
                    {
                        // Decrypt uppercase letter
                        decryptedChar = (char)((c - 'A' - 3 + 26) % 26 + 'A');
                    }

                    decryptedText.Append(decryptedChar);
                }
                else
                {
                    // Keep non-letter characters as they are
                    decryptedText.Append(c);
                }
            }

            return decryptedText.ToString();
        }
    }
}
