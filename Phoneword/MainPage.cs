using System;
using Xamarin.Forms;
using Core;

namespace Phoneword
{
	public class MainPage : ContentPage
	{
		private Entry _inTextNumber;
		private Button _btnTranslate, _btnCall;
		double spacing = Device.OnPlatform<double>(40, 20, 20);

		public MainPage(String title)
		{
			Title = title;
			this.Padding = new Thickness(20, Device.OnPlatform<double>(40, 20, 20), 20, 20);
			Content = new StackLayout
			{
				Spacing = this.spacing,
				VerticalOptions = LayoutOptions.Center,
				Children = {
										  new Label { HorizontalTextAlignment = TextAlignment.Center, Text = "Enter a Phoneword:" },
						(_inTextNumber 	= new Entry { Text = "1-855-XAMARIN" }),
						(_btnTranslate 	= new Button { Text = "Translate" }),
						(_btnCall 		= new Button { Text = "Call", IsEnabled = false})	
					}
			};

			_btnTranslate.Clicked += _btnTranslate_Clicked;
		}

		void _btnTranslate_Clicked(object sender, EventArgs e)
		{
			String toTranslate = _inTextNumber.Text;
			String translated = PhoneWordTranslator.ToNumber(toTranslate);
			if (string.IsNullOrEmpty(translated))
			{
				_btnCall.IsEnabled = false;
				_btnCall.Text = "Call";
			}
			else
			{
				_btnCall.IsEnabled = true;
			}

			_btnCall.Text = "Call " + translated ?? string.Empty;
		}
	}
}
