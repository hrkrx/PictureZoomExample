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
using System.Windows.Shapes;

namespace WPF_TestApp
{
	/// <summary>
	/// Interaktionslogik für Zoom.xaml
	/// </summary>
	public partial class Zoom : Window
	{
		public Zoom()
		{
			InitializeComponent();
		}

		public void setZoomImg(BitmapImage src, Point relativetopleft)
		{
			Int32Rect rect = new Int32Rect((int)(relativetopleft.X * src.Width), (int)(relativetopleft.Y * src.Height), (int)(details.Width), (int)(details.Height));
			if (!(rect.X + rect.Width > src.Width) && !(rect.Y + rect.Height > src.Height)) { //Optimize this condition!
				CroppedBitmap cBmp = new CroppedBitmap(src, rect);
				details.Source = cBmp;
			}
		}
	}
}
