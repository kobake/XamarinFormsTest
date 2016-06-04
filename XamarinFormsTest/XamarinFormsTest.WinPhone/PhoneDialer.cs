using Windows.ApplicationModel.Calls;
using XamarinFormsTest.WinPhone;
using Xamarin.Forms;
[assembly: Dependency(typeof(PhoneDialer))]
namespace XamarinFormsTest.WinPhone
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
