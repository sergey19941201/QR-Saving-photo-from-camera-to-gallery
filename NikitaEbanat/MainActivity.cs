using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net;
using Android.Content.PM;

namespace NikitaEbanat
{
    [Activity(Label = "NikitaEbanat", ScreenOrientation = ScreenOrientation.Landscape, MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Black.NoTitleBar")]
    public class MainActivity : Activity
    {
        private static bool isOnline;
        private FragmentManager fragmentManager;
        private Fragments.EnterFragment enterFragment;
        
        //checking internet connection
        private void checkInternetConnection()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            isOnline = (activeConnection != null) && activeConnection.IsConnected;
        }
        //checking internet connection ended

        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            checkInternetConnection();

            fragmentManager = this.FragmentManager;
            enterFragment = new Fragments.EnterFragment();
            enterFragment.Show(fragmentManager, "fragmentManager");

            if (isOnline == false)
            {
                Toast.MakeText(this, "No Internet Connection.\nTurn the Internet connection on and try again", ToastLength.Long).Show();
            }
        }
    }
    
}

