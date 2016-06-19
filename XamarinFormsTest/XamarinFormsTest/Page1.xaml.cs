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
		int m_networkState = 0;
		public Page1()
		{
			InitializeComponent();
			networkLabel.Text = "";
		}
		
		void OnNetworkTestClicked(object sendor, EventArgs e)
		{
			m_networkState++;
			networkLabel.Text = "Network state: clicked " + m_networkState;

			using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
			{
				networkLabel.Text = httpClient.GetStringAsync("https://www.google.co.jp/").Result.Substring(0, 20);
			}
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
