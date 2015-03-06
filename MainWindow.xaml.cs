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
using Microsoft.Win32;

namespace WPF_TestApp
{
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		BitmapImage zImg = null;
		Zoom zoom = new Zoom();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			String result = "";
			ofd.ShowDialog();
			result = ofd.FileName;
			if (!String.IsNullOrWhiteSpace(result)) {
				BitmapImage pic = new BitmapImage();
				pic.BeginInit();
				pic.UriSource = new Uri(result);
				pic.EndInit();
				imageCtrl.Source = pic;
				zImg = pic;
			}
		}

		private void imageCtrl_MouseMove(object sender, MouseEventArgs e)
		{
			lbPos.Content = e.GetPosition(imageCtrl).ToString();
			zoom.Left = e.GetPosition(imageCtrl).X + this.Left - 80;
			zoom.Top = e.GetPosition(imageCtrl).Y + this.Top - 263;
			Point p = e.GetPosition(imageCtrl);
			p.X = p.X / imageCtrl.Width;
			p.Y = p.Y / imageCtrl.Height;
			zoom.setZoomImg(zImg, p); // PointLocation has to be optimized!
		}

		private void imageCtrl_MouseEnter(object sender, MouseEventArgs e)
		{
			zoom.Show();
		}

		private void imageCtrl_MouseLeave(object sender, MouseEventArgs e)
		{
			zoom.Hide();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			zoom = null;
			zImg = null;
			imageCtrl.MouseEnter -= imageCtrl_MouseLeave;
			imageCtrl.MouseLeave -= imageCtrl_MouseLeave;
			imageCtrl.MouseMove -= imageCtrl_MouseMove;
			Environment.Exit(0);
		}
	}
}
