using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;


namespace XamarinEssentials
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Assign Xamarin Essentials to TextViews
            AssignInfo();

            //Handle info changes
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            GetDisplayInfo();
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            GetNetworkInfo();
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            GetBatteryInfo();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void AssignInfo()
        {
            GetAppInfo();
            GetBatteryInfo();
            GetNetworkInfo();
            GetDisplayInfo();
            GetDeviceInfo();
        }

        private void GetAppInfo()
        {
            var AppName = Resources.GetText(Resource.String.AppNameText);
            var LineEnd = Resources.GetText(Resource.String.EndLine);

            var appName = AppInfo.Name;
            var appNameText = FindViewById<TextView>(Resource.Id.appName);
            appNameText.Text = AppName + appName + LineEnd;
        }

        private void GetBatteryInfo()
        {
            var BatteryCharge = Resources.GetText(Resource.String.BatteryChargeLevel);
            var LineEnd = Resources.GetText(Resource.String.EndLine);

            var chargeLevel = Battery.ChargeLevel;
            var chargeLevelText = FindViewById<TextView>(Resource.Id.chargeLevel);
            chargeLevelText.Text = BatteryCharge + chargeLevel + LineEnd;
        }

        private void GetNetworkInfo()
        {
            var NetworkAccess = Resources.GetText(Resource.String.NetworkAccess);
            var LineEnd = Resources.GetText(Resource.String.EndLine);

            var networkAccess = Connectivity.NetworkAccess;
            var networkAccessText = FindViewById<TextView>(Resource.Id.networkAccess);
            networkAccessText.Text = NetworkAccess + networkAccess + LineEnd;
        }

        private void GetDisplayInfo()
        {
            var DisplayDensity = Resources.GetText(Resource.String.DisplayDensity);
            var LineEnd = Resources.GetText(Resource.String.EndLine);

            var displayDensity = DeviceDisplay.MainDisplayInfo.Density;
            var displayDensityText = FindViewById<TextView>(Resource.Id.displayDensity);
            displayDensityText.Text = DisplayDensity + displayDensity + LineEnd;
        }

        private void GetDeviceInfo()
        {
            var DevicePlatform = Resources.GetText(Resource.String.DisplayDensity);
            var LineEnd = Resources.GetText(Resource.String.EndLine);

            var devicePlatform = DeviceInfo.Platform;
            var devicePlatformText = FindViewById<TextView>(Resource.Id.devicePlatform);
            devicePlatformText.Text = DevicePlatform + devicePlatform + LineEnd;
        }
    }
}
