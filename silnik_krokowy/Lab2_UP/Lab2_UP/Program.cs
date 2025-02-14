using System;
using FTD2XX_NET;
using System.Threading;

namespace StepMotorControl
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicjalizacja FTDI oraz zmiennych potrzebnych do komunikacji
            FTDI ftdiDevice = new FTDI();
            FTDI.FT_STATUS ftStatus;
            uint bytesWritten = 0;

            // Nawiązanie połączenia z urządzeniem FTDI
            ftStatus = ftdiDevice.OpenByIndex(0);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                Console.WriteLine("Failed to open USB device.");
                return;
            }

            // 1. Wybór akcji: odczyt EEPROM lub sterowanie silnikiem
            Console.WriteLine("Choose action:\n1 - Read EEPROM\n2 - Control Stepper Motor");
            int action = int.Parse(Console.ReadLine());

            if (action == 1)
            {
                // Odczyt EEPROM
                ReadEEPROM(ftdiDevice);
                ftdiDevice.Close();
                return;
            }

            // Ustawienie urządzenia w tryb Bit Bang (tylko dla sterowania silnikiem)
            ftStatus = ftdiDevice.SetBitMode(0xFF, 0x01);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                Console.WriteLine("Failed to set bit mode.");
                ftdiDevice.Close();
                return;
            }

            // 2. Wybór trybu sterowania: falowy, pełnokrokowy, półkrokowy
            Console.WriteLine("Choose mode:\n1 - Wave\n2 - Full Step\n3 - Half Step");
            int mode = int.Parse(Console.ReadLine());

            // 3. Wybór trybu pracy: manualny lub automatyczny
            Console.WriteLine("Choose control mode:\n1 - Manual\n2 - Automatic");
            int controlMode = int.Parse(Console.ReadLine());

            // 4. Wybór silnika: poziomy lub pionowy
            Console.WriteLine("Choose motor orientation:\n1 - Horizontal\n2 - Vertical");
            bool isHorizontal = Console.ReadLine() == "1";

            // Ustawienie odpowiednich sekwencji kroków na podstawie wybranej orientacji i trybu sterowania
            byte[] stepSequence = mode switch
            {
                1 => isHorizontal ? new byte[] { 0x02, 0x08, 0x01, 0x04 } : new byte[] { 0x20, 0x80, 0x10, 0x40 },
                2 => isHorizontal ? new byte[] { 0x06, 0x0A, 0x09, 0x05 } : new byte[] { 0x60, 0xA0, 0x90, 0x50 },
                3 => isHorizontal ? new byte[] { 0x02, 0x0A, 0x08, 0x09, 0x01, 0x05, 0x04, 0x06 } : new byte[] { 0x20, 0xA0, 0x80, 0x90, 0x10, 0x50, 0x40, 0x60 },
                _ => throw new ArgumentException("Invalid mode.")
            };

            // Zmienna śledząca aktualny krok w sekwencji
            int stepIndex = 0;

            // Tryb manualny
            if (controlMode == 1)
            {
                Console.WriteLine("Manual mode selected. Use arrow keys to control:");
                Console.WriteLine("Press 'Esc' to exit.");

                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey(true);

                    // Wybór kroku w zależności od kierunku
                    if (keyInfo.Key == ConsoleKey.RightArrow || keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        // Wybranie odpowiedniego kroku z sekwencji
                        byte singleStep = stepSequence[stepIndex];

                        // Wykonanie jednego kroku
                        StepMotor(ftdiDevice, singleStep, bytesWritten, stepDelay: 100);

                        // Aktualizacja indeksu kroku, aby przesuwać się w sekwencji krok po kroku
                        if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            stepIndex = (stepIndex + 1) % stepSequence.Length; // Przesunięcie do przodu
                        }
                        else if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            stepIndex = (stepIndex - 1 + stepSequence.Length) % stepSequence.Length; // Przesunięcie do tyłu
                        }
                    }

                } while (keyInfo.Key != ConsoleKey.Escape);
            }
            else // Tryb automatyczny
            {
                // W trybie automatycznym wymagamy kierunku, dlatego dodajemy wybór
                Console.WriteLine("Choose direction:\n1 - Right (R)\n2 - Left (L)");
                char direction = Console.ReadLine() == "1" ? 'R' : 'L';

                Console.WriteLine("Automatic mode selected.");
                Console.WriteLine("Enter number of steps:");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter step duration (in ms):");
                int stepDelay = int.Parse(Console.ReadLine());

                Console.WriteLine("Starting motor control...");
                for (int i = 0; i < n; i++)
                {
                    // Wykonanie jednego kroku
                    StepMotor(ftdiDevice, stepSequence[stepIndex], bytesWritten, stepDelay);

                    // Przesunięcie indeksu do następnego kroku
                    stepIndex = (direction == 'R')
                        ? (stepIndex + 1) % stepSequence.Length // Przesunięcie do przodu
                        : (stepIndex - 1 + stepSequence.Length) % stepSequence.Length; // Przesunięcie do tyłu
                }
            }

            // Wysłanie zerowego bajtu, aby zatrzymać przepływ prądu
            ftdiDevice.Write(new byte[] { 0x00 }, 1, ref bytesWritten);

            // Zamknięcie połączenia z urządzeniem
            ftdiDevice.Close();
            Console.WriteLine("Motor control complete.");
        }

        // Funkcja odczytująca dane z EEPROM i wyświetlająca je w konsoli
        static void ReadEEPROM(FTDI device)
        {
            FTDI.FT232B_EEPROM_STRUCTURE eepromData = new FTDI.FT232B_EEPROM_STRUCTURE();
            FTDI.FT_STATUS ftStatus = device.ReadFT232BEEPROM(eepromData);

            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                string eeString = "EEPROM Data:\n";
                eeString += "Vendor ID: 0x" + eepromData.VendorID.ToString("X") + "\n";
                eeString += "Product ID: 0x" + eepromData.ProductID.ToString("X") + "\n";
                eeString += "Manufacturer: " + eepromData.Manufacturer + "\n";
                eeString += "Max Power: " + eepromData.MaxPower + "\n";
                eeString += "Serial Number: " + eepromData.SerialNumber + "\n";

                Console.WriteLine(eeString);
            }
            else
            {
                Console.WriteLine("Failed to read EEPROM data.");
            }
        }

        // Funkcja wykonująca pojedynczy krok dla silnika
        static void StepMotor(FTDI ftdiDevice, byte singleStep, uint bytesWritten, int stepDelay)
        {
            FTDI.FT_STATUS ftStatus;

            // Wykonanie pojedynczego kroku
            ftStatus = ftdiDevice.Write(new byte[] { singleStep }, 1, ref bytesWritten);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                Console.WriteLine("Error writing data to device.");
                ftdiDevice.Close();
                return;
            }

            Thread.Sleep(stepDelay); // Czas trwania kroku
        }
    }
}
