using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIA;

namespace ScannerApp
{
    public partial class ScannerForm : Form
    {
        private DeviceManager deviceManager = new DeviceManager();
        private DeviceInfo selectedDeviceInfo;
        private Device connectedScanner;
        private ImageFile scannedImage;
        private int dpi = 150;
        private int brightness = 0;
        private int contrast = 0;
        private int X = 0;
        private int Y = 0;
        private int width = 210;
        private int height = 1600;

        private ComboBox scannersComboBox;
        private ComboBox formatComboBox;
        private ComboBox colorModeComboBox;
        private PictureBox previewPictureBox;
        private TrackBar dpiTrackBar;
        private TrackBar brightnessTrackBar;
        private TrackBar contrastTrackBar;
        private Label dpiLabel;
        private Label brightnessLabel;
        private Label scannerStatusLabel;
        private Label contrastLabel;
        private Button connectButton;
        private Button scanButton;
        private Button saveButton;
        private Button rotateLeftButton;
        private Button rotateRightButton;
        private Button searchDevicesButton;

        public ScannerForm()
        {
            InitializeComponent();
            InitializeParameters();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScannerForm());
        }

        private void InitializeComponent()
        {
            this.scannersComboBox = new ComboBox();
            this.formatComboBox = new ComboBox();
            this.colorModeComboBox = new ComboBox();
            this.previewPictureBox = new PictureBox();
            this.dpiTrackBar = new TrackBar();
            this.brightnessTrackBar = new TrackBar();
            this.contrastTrackBar = new TrackBar();
            this.dpiLabel = new Label();
            this.brightnessLabel = new Label();
            this.contrastLabel = new Label();
            this.connectButton = new Button();
            this.scanButton = new Button();
            this.saveButton = new Button();
            this.rotateLeftButton = new Button();
            this.rotateRightButton = new Button();
            this.searchDevicesButton = new Button();
            this.scannerStatusLabel = new Label();

            // Form settings
            this.Text = "Scanner App";
            this.Size = new Size(1000, 700);

            // scannersComboBox
            this.scannersComboBox.Location = new Point(20, 20);
            this.scannersComboBox.Size = new Size(200, 20);
            this.Controls.Add(this.scannersComboBox);

            // formatComboBox
            this.formatComboBox.Location = new Point(240, 20);
            this.formatComboBox.Size = new Size(100, 20);
            this.formatComboBox.Items.AddRange(new string[] { "jpeg", "png", "bmp", "tiff", "rle" });
            this.formatComboBox.SelectedIndex = 0;
            this.Controls.Add(this.formatComboBox);

            // colorModeComboBox
            this.colorModeComboBox.Location = new Point(360, 20);
            this.colorModeComboBox.Size = new Size(100, 20);
            this.colorModeComboBox.Items.AddRange(new string[] { "Color", "Grayscale", "Black & White" });
            this.colorModeComboBox.SelectedIndex = 0;
            this.Controls.Add(this.colorModeComboBox);

            // previewPictureBox
            this.previewPictureBox.Location = new Point(20, 60);
            this.previewPictureBox.Size = new Size(600, 400);
            this.previewPictureBox.BorderStyle = BorderStyle.Fixed3D;
            this.previewPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(this.previewPictureBox);

            // dpiTrackBar
            this.dpiTrackBar.Location = new Point(650, 60);
            this.dpiTrackBar.Minimum = 100;
            this.dpiTrackBar.Maximum = 1200;
            this.dpiTrackBar.Value = dpi;
            this.dpiTrackBar.TickFrequency = 100;
            this.dpiTrackBar.Scroll += new EventHandler(dpiTrackBar_Scroll);
            this.Controls.Add(this.dpiTrackBar);

            // brightnessTrackBar
            this.brightnessTrackBar.Location = new Point(650, 120);
            this.brightnessTrackBar.Minimum = -100;
            this.brightnessTrackBar.Maximum = 100;
            this.brightnessTrackBar.Value = brightness;
            this.brightnessTrackBar.Scroll += new EventHandler(brightnessTrackBar_Scroll);
            this.Controls.Add(this.brightnessTrackBar);

            // contrastTrackBar
            this.contrastTrackBar.Location = new Point(650, 180);
            this.contrastTrackBar.Minimum = -100;
            this.contrastTrackBar.Maximum = 100;
            this.contrastTrackBar.Value = contrast;
            this.contrastTrackBar.Scroll += new EventHandler(contrastTrackBar_Scroll);
            this.Controls.Add(this.contrastTrackBar);

            // dpiLabel
            this.dpiLabel.Location = new Point(650, 40);
            this.dpiLabel.Text = "DPI: " + dpi;
            this.Controls.Add(this.dpiLabel);

            // brightnessLabel
            this.brightnessLabel.Location = new Point(650, 104);
            this.brightnessLabel.Text = "Brightness: " + brightness;
            this.Controls.Add(this.brightnessLabel);

            // contrastLabel
            this.contrastLabel.Location = new Point(650, 164);
            this.contrastLabel.Text = "Contrast: " + contrast;
            this.Controls.Add(this.contrastLabel);

            // searchDevicesButton
            this.searchDevicesButton.Location = new Point(20, 500);
            this.searchDevicesButton.Size = new Size(100, 30);
            this.searchDevicesButton.Text = "Search Devices";
            this.searchDevicesButton.Click += new EventHandler(searchDevicesButton_Click);
            this.Controls.Add(this.searchDevicesButton);

            // connectButton
            this.connectButton.Location = new Point(140, 500);
            this.connectButton.Size = new Size(100, 30);
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new EventHandler(connectButton_Click);
            this.Controls.Add(this.connectButton);

            // scanButton
            this.scanButton.Location = new Point(260, 500);
            this.scanButton.Size = new Size(100, 30);
            this.scanButton.Text = "Scan";
            this.scanButton.Click += new EventHandler(scanButton_Click);
            this.Controls.Add(this.scanButton);

            // saveButton
            this.saveButton.Location = new Point(380, 500);
            this.saveButton.Size = new Size(100, 30);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new EventHandler(saveButton_Click);
            this.Controls.Add(this.saveButton);

            // rotateLeftButton
            this.rotateLeftButton.Location = new Point(500, 500);
            this.rotateLeftButton.Size = new Size(100, 30);
            this.rotateLeftButton.Text = "Rotate Left";
            this.rotateLeftButton.Click += new EventHandler(rotateLeftButton_Click);
            this.Controls.Add(this.rotateLeftButton);

            // rotateRightButton
            this.rotateRightButton.Location = new Point(620, 500);
            this.rotateRightButton.Size = new Size(100, 30);
            this.rotateRightButton.Text = "Rotate Right";
            this.rotateRightButton.Click += new EventHandler(rotateRightButton_Click);
            this.Controls.Add(this.rotateRightButton);

            // scannerStatusLabel
            this.scannerStatusLabel.Location = new Point(20, 550);
            this.scannerStatusLabel.Size = new Size(400, 30);
            this.scannerStatusLabel.Text = "Status: Disconnected";
            this.Controls.Add(this.scannerStatusLabel);
        }

        private void searchDevicesButton_Click(object sender, EventArgs e)
        {
            try
            {
                scannersComboBox.Items.Clear();
                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType)
                    {
                        scannersComboBox.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                    }
                }

                if (scannersComboBox.Items.Count > 0)
                {
                    scannersComboBox.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No scanners found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for scanners: " + ex.Message);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (scannersComboBox.SelectedIndex >= 0)
            {
                try
                {
                    selectedDeviceInfo = deviceManager.DeviceInfos[scannersComboBox.SelectedIndex + 1];
                    connectedScanner = selectedDeviceInfo.Connect();
                    MessageBox.Show("Connected to scanner: " + scannersComboBox.SelectedItem.ToString());

                    // Dezaktywacja przycisku Connect
                    connectButton.Enabled = false;

                    // Aktywacja pozostałych przycisków po udanym połączeniu
                    scanButton.Enabled = true;
                    saveButton.Enabled = true;
                    rotateLeftButton.Enabled = true;
                    rotateRightButton.Enabled = true;

                    // Zmiana statusu skanera
                    scannerStatusLabel.Text = "Status: Connected to " + scannersComboBox.SelectedItem.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to scanner: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a scanner from the list.");
            }
        }


        private void scanButton_Click(object sender, EventArgs e)
        {
            if (connectedScanner != null)
            {
                try
                {
                    // Blokowanie przycisków podczas skanowania
                    connectButton.Enabled = false;
                    scanButton.Enabled = false;
                    saveButton.Enabled = false;
                    rotateLeftButton.Enabled = false;
                    rotateRightButton.Enabled = false;

                    scannerStatusLabel.Text = "Scanning in progress...";

                    // Scan the image with the specified parameters
                    var scannerItem = connectedScanner.Items[1];
                    SetScannerProperties(scannerItem);

                    // Transfer scanned image to appropriate format
                    switch (formatComboBox.SelectedItem.ToString().ToLower())
                    {
                        case "jpeg":
                            scannedImage = (ImageFile)scannerItem.Transfer("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}");
                            break;
                        case "png":
                            scannedImage = (ImageFile)scannerItem.Transfer("{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}");
                            break;
                        case "bmp":
                        case "tiff":
                        case "rle":
                            scannedImage = (ImageFile)scannerItem.Transfer();
                            break;
                        default:
                            MessageBox.Show("Unsupported format selected.");
                            return;
                    }

                    // Save scanned image and display in preview
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "JPEG|*.jpeg|PNG|*.png|BMP|*.bmp|TIFF|*.tiff|RLE|*.rle",
                        Title = "Save Scanned Image",
                        FileName = "scanned_image"
                    };
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        scannedImage.SaveFile(saveDialog.FileName);
                        previewPictureBox.ImageLocation = saveDialog.FileName;
                    }

                    scannerStatusLabel.Text = "Scan complete.";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while scanning: " + ex.Message);
                }
                finally
                {
                    // Odblokowanie przycisków po skanowaniu
                    connectButton.Enabled = true;
                    scanButton.Enabled = true;
                    saveButton.Enabled = true;
                    rotateLeftButton.Enabled = true;
                    rotateRightButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please connect to a scanner first.");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (scannedImage != null)
            {
                // Inicjalizacja dialogu zapisu
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "BMP|*.BMP|JPG|*.JPG|GIF|*.GIF|PNG|*.PNG|TIFF|*.TIFF|RLE|*.RLE",
                    FileName = "scanned_image"
                };

                // Pokazanie dialogu zapisu
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Próba zapisania pliku
                        scannedImage.SaveFile(saveFileDialog.FileName);
                        MessageBox.Show("Image saved successfully to: " + saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        // Obsługa błędów podczas zapisu pliku
                        MessageBox.Show("An error occurred while saving the image: " + ex.Message);
                    }
                }
            }
            else
            {
                // Brak zeskanowanego obrazu do zapisu
                MessageBox.Show("No image to save. Please scan an image first.");
            }
        }


        private void SetScannerProperties(IItem scannerItem)
        {
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            const string WIA_SCAN_COLOR_MODE = "6146";

            try
            {
                // Walidacja DPI
                if (dpi < 100 || dpi > 1200)
                {
                    MessageBox.Show("DPI value is out of range (100-1200). Setting default DPI to 150.");
                    dpi = 150;
                }

                // Ustawienie parametrów skanowania
                SetProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, dpi);
                SetProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, dpi);
                SetProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, X);
                SetProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, Y);

                // Automatyczne przeliczenie szerokości i wysokości na piksele na podstawie DPI
                width = (int)((210.0 / 25.4) * dpi);   // A4 width in pixels
                height = (int)((297.0 / 25.4) * dpi);  // A4 height in pixels
                SetProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, width);
                SetProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, height);

                // Ustawienie jasności i kontrastu
                SetProperty(scannerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightness);
                SetProperty(scannerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrast);

                // Ustawienie trybu kolorów
                int colorMode = 1; // Default to Color
                if (colorModeComboBox.SelectedIndex == 1)
                {
                    colorMode = 2; // Grayscale
                }
                else if (colorModeComboBox.SelectedIndex == 2)
                {
                    colorMode = 4; // Black & White
                }
                SetProperty(scannerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting scanner properties: " + ex.Message);
            }
        }


        private static void SetProperty(IProperties properties, object propName, object propValue)
        {
            Property property = properties.get_Item(ref propName);
            property.set_Value(ref propValue);
        }

        private void rotateLeftButton_Click(object sender, EventArgs e)
        {
            RotateImage(270);
        }

        private void rotateRightButton_Click(object sender, EventArgs e)
        {
            RotateImage(90);
        }

        private void RotateImage(int angle)
        {
            if (previewPictureBox.Image != null)
            {
                Bitmap bitmap = new Bitmap(previewPictureBox.Image);
                switch (angle)
                {
                    case 90:
                        bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 270:
                        bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                previewPictureBox.Image = bitmap;
            }
        }

        private void dpiTrackBar_Scroll(object sender, EventArgs e)
        {
            dpi = dpiTrackBar.Value;
            dpiLabel.Text = "DPI: " + dpi;
        }

        private void brightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            brightness = brightnessTrackBar.Value;
            brightnessLabel.Text = "Brightness: " + brightness;
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            contrast = contrastTrackBar.Value;
            contrastLabel.Text = "Contrast: " + contrast;
        }

        private void InitializeParameters()
        {
            dpiTrackBar.Minimum = 100;
            dpiTrackBar.Maximum = 1200;
            brightnessTrackBar.Minimum = -100;
            brightnessTrackBar.Maximum = 100;
            contrastTrackBar.Minimum = -100;
            contrastTrackBar.Maximum = 100;
            dpiTrackBar.Value = dpi;
            brightnessTrackBar.Value = brightness;
            contrastTrackBar.Value = contrast;
        }
    }
}
