using Windows.ApplicationModel.Calls;
using XamarinFormTest.UWP;
using Xamarin.Forms;
using XamarinFormsTest;

[assembly: Dependency(typeof(PhoneDialer))]
namespace XamarinFormTest.UWP
{
	public class PhoneDialer : IDialer
	{
		public bool Dial(string number)
		{
			PhoneCallManager.ShowPhoneCallUI(number, "Phoneword");
			return true;
		}
	}
}
