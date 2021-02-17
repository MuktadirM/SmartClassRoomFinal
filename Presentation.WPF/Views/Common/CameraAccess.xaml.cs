using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation.WPF.Views.Common
{
    /// <summary>
    /// Interaction logic for CameraAccess.xaml
    /// </summary>
    public partial class CameraAccess : Window
    {
        public FilterInfoCollection filterInfo;
        public VideoCaptureDevice videoCaptureDevice;

        public CameraAccess()
        {
            InitializeComponent();
            LoadCameraInfo();
        }

        private void LoadCameraInfo()
        {
            filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filter in filterInfo)
            {
                CaremaSourceCombo.Items.Add(filter.Name);
            }
        }

        private void CaptureImage_Click(object sender, RoutedEventArgs e)
        {
            if (video_camera_view.Source != null)
            {
                String filePath = @"C:\Users\MUKTADIR\Desktop\SmartClassRoom\test.jpg";

                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)video_camera_view.Source));
                using FileStream stream = new FileStream(filePath, FileMode.Create);
                encoder.Save(stream);
                MessageBox.Show("Image Saved", "Successfull", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            { MessageBox.Show("null exception"); }
        }

        private void StartCamera_Click(object sender, RoutedEventArgs e)
        {
            if (CaremaSourceCombo.SelectedIndex < 0) {
                MessageBox.Show("No Camera Has been Select", "Camera Selection Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            videoCaptureDevice = new VideoCaptureDevice(filterInfo[CaremaSourceCombo.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }




        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                System.Drawing.Image img = (Bitmap)eventArgs.Frame.Clone();

                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();

                bi.Freeze();
                Dispatcher.BeginInvoke(new ThreadStart(delegate
                {
                    video_camera_view.Source = bi;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Your Camera is Not Supported" + ex.Message, "Camera Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void StopCamera_Click(object sender, RoutedEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true) {
               
            }
        }
    }
}
