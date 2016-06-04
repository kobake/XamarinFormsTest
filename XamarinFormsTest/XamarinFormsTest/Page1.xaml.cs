using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinFormsTest
{
	public partial class Page1 : ContentPage
	{
		string m_translatedNumber;
		public Page1()
		{
			InitializeComponent();
		}

		void OnTranslate(object sendor, EventArgs e)
		{
			m_translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
			if (!string.IsNullOrWhiteSpace(m_translatedNumber))
			{
				callButton.IsEnabled = true;
				callButton.Text = "Call " + m_translatedNumber;
			}
			else
			{
				callButton.IsEnabled = false;
				callButton.Text = "Call";
			}
		}

		async void OnCall(object sender, EventArgs e)
		{
			if(await this.DisplayAlert(
				"DIal a Number",
				"Would you like to call " + m_translatedNumber + "?",
				"Yes",
				"No"))
			{
				var dialer = DependencyService.Get<IDialer>();
				if(dialer != null)
				{
					dialer.Dial(m_translatedNumber);
				}
			}
		}
	}
}
