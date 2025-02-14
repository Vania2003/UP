using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace EAN13BarcodeGenerator
{
    class Program
    {
        // tablica wzorców kodowania dla L-code (lewa strona)
        static readonly string[] LCode = {
            "0001101", "0011001", "0010011", "0111101", "0100011",
            "0110001", "0101111", "0111011", "0110111", "0001011"
        };

         // tablica wzorców kodowania dla G-code (lewa strona)
        static readonly string[] GCode = {
            "0100111", "0110011", "0011011", "0100001", "0011101",
            "0111001", "0000101", "0010001", "0001001", "0010111"
        };

        // tablica wzorców kodowania dla R-code (prawa strona)
        static readonly string[] RCode = {
            "1110010", "1100110", "1101100", "1000010", "1011100",
            "1001110", "1010000", "1000100", "1001000", "1110100"
        };

        // wzorce parzystości dla pierwszej cyfry
        // określają, które cyfry po lewej stronie są zakodowane L-code, a które G-code
        static readonly string[] ParityPatterns = {
            "LLLLLL", "LLGLGG", "LLGGLG", "LLGGGL", "LGLLGG",
            "LGGLLG", "LGGGLL", "LGLGLG", "LGLGGL", "LGGLGL"
        };

        static void Main(string[] args)
        {   
            // wprowadzenie 12-cyfrowego kodu EAN-13
            Console.Write("Enter 12-digit EAN-13 code: ");
            string inputText = Console.ReadLine().Trim();

            // sprawdzenie, czy kod ma 12 cyfr
            if (string.IsNullOrEmpty(inputText) || inputText.Length != 12 || !inputText.All(char.IsDigit))
            {
                Console.WriteLine("Please enter exactly 12 digits.");
                return;
            }

             // obliczenie pełnego kodu EAN-13 z cyfrą kontrolną
            string ean13Code = inputText + CalculateCheckDigit(inputText);
            Console.WriteLine("Full EAN-13 code with check digit: " + ean13Code);

            // wygenerowanie wzoru binarnego dla kodu kreskowego
            string pattern = GenerateBarcodePattern(ean13Code);

            // parametry graficzne kodu kreskowego
            int moduleWidth = 2; // szerokość pojedynczego paska
            int barcodeWidth = pattern.Length * moduleWidth; // całkowita szerokość kodu kreskowego
            int barcodeHeight = 80; // wysokość samych pasków
            int totalHeight = 130; // całkowita wysokość
            int padding = 20; // odstęp wokół kodu kreskowego

             // tworzenie bitmapy z odpowiednimi wymiarami i odstępami
            Bitmap bitmap = new Bitmap(barcodeWidth + 2 * padding, totalHeight + 2 * padding);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); // wypełnienie tła na biało
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                 // rysowanie wzoru kodu kreskowego
                for (int i = 0; i < pattern.Length; i++)
                {   
                    
                    bool isGuardBar = i < 3 || (i >= 45 && i < 50) || i >= 92;
                    int barHeight = isGuardBar ? barcodeHeight + 10 : barcodeHeight;
                    // rysowanie czarnego paska, jeśli w wzorcu jest '1'
                    if (pattern[i] == '1')
                    {
                        g.FillRectangle(Brushes.Black, padding + i * moduleWidth, padding, moduleWidth, barHeight);
                    }
                }

                 // rysowanie cyfr pod kodem kreskowym
                string firstDigit = ean13Code.Substring(0, 1); // pierwsza cyfra
                string leftDigits = ean13Code.Substring(1, 6);  // nastepne 6 cyfr
                string rightDigits = ean13Code.Substring(7, 6); // 6 cyfr od prawej strony 

                Font font = new Font("Arial", 10);
                StringFormat format = new StringFormat { Alignment = StringAlignment.Center };

                // rysowanie pierwszej cyfry po lewej stronie
                float firstDigitPosition = moduleWidth * 3;
                g.DrawString(firstDigit, font, Brushes.Black, new PointF(padding + firstDigitPosition - 12, padding + barcodeHeight), format);

                // rysowanie cyfr po lewej stronie
                for (int i = 0; i < leftDigits.Length; i++)
                {
                    float x = padding + firstDigitPosition + (7 * moduleWidth * i) + (7 * moduleWidth / 2);
                    g.DrawString(leftDigits[i].ToString(), font, Brushes.Black, new PointF(x, padding + barcodeHeight), format);
                }

                // rysowanie cyfr po prawej
                float rightSideStart = padding + firstDigitPosition + 42 * moduleWidth + 5 * moduleWidth;
                for (int i = 0; i < rightDigits.Length; i++)
                {
                    float x = rightSideStart + (7 * moduleWidth * i) + (7 * moduleWidth / 2);
                    g.DrawString(rightDigits[i].ToString(), font, Brushes.Black, new PointF(x, padding + barcodeHeight), format);
                }
            }

            // zapisz do pliku
            string outputPath = Path.Combine("../../../", "ean13barcode.png");
            bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine($"Barcode image saved to {outputPath}");
        }


        // funkcja obliczająca cyfrę kontrolną
        private static int CalculateCheckDigit(string data)
        {   
            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int digit = data[i] - '0';
                // cyfry na nieparzystych pozycjach są mnożone przez 3
                sum += (i % 2 == 0) ? digit : digit * 3;
            }
            // obliczenie cyfry kontrolnej
            int mod = sum % 10;
            return mod == 0 ? 0 : 10 - mod;
        }

         // funkcja generująca wzorzec binarny kodu kreskowego na podstawie 13-cyfrowego kodu EAN-13
        private static string GenerateBarcodePattern(string ean13Code)
        {   
            if (ean13Code.Length != 13 || !ean13Code.All(char.IsDigit))
                throw new ArgumentException("EAN-13 code must be 13 digits.");

            StringBuilder result = new StringBuilder("101");

            int firstDigitValue = ean13Code[0] - '0';
            string parityPattern = ParityPatterns[firstDigitValue];

            // Kodowanie cyfr po lewej stronie
            for (int i = 1; i <= 6; i++)
            {
                int digit = ean13Code[i] - '0';
                char parity = parityPattern[i - 1];
                string encoded = parity == 'L' ? LCode[digit] : GCode[digit];
                result.Append(encoded);
            }
            // wzorzec środkowy (separator)
            result.Append("01010");
            // kodowanie cyfr po prawej stronie
            for (int i = 7; i <= 12; i++)
            {
                int digit = ean13Code[i] - '0';
                result.Append(RCode[digit]);  // dodanie zakodowanej cyfry
            }
            // wzorzec końcowy (lead)
            result.Append("101");
            return result.ToString();
        }
    }}
