using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content.PM;
using ZXing.Mobile;
using RestSharp;

namespace NikitaEbanat
{
    [Activity(Label = "FourSquaredButtonsActivity", ScreenOrientation = ScreenOrientation.Landscape, Theme = "@android:style/Theme.Black.NoTitleBar")]
    public class FourSquaredButtonsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FourSquaredButtons);

            // Somewhere in your app, call the initialization code:
            MobileBarcodeScanner.Initialize(Application);

            var client = new RestClient("http://timetrackingbackend.azurewebsites.net/api");
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            FindViewById<Button>(Resource.Id.nachatSmenuBn).Click += async delegate
            {
                var result = await scanner.Scan();

                if (result != null)
                {
                    var request = new RestRequest("/StartWorkingDays", Method.POST);
                    request.AddJsonBody(new
                    {
                        Company = Fragments.EnterFragment.company,
                        INN = result.Text,
                        StartDay = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                    });
                    var response = client.Execute(request);
                    string content = response.Content;

                    if (response.StatusCode.ToString() == "Created")
                    {
                        Toast.MakeText(this, "Успех!", ToastLength.Short).Show();
                        StartActivity(typeof(PhotoActivity));
                    }
                }
            };
            FindViewById<Button>(Resource.Id.nachatPererivBn).Click += async delegate
              {
                  var result = await scanner.Scan();

                  if (result != null)
                  {
                      var request = new RestRequest("/StartPauses", Method.POST);
                      request.AddJsonBody(new
                      {
                          Company = Fragments.EnterFragment.company,
                          INN = result.Text,
                          StartPause = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                      });
                      var response = client.Execute(request);
                      string content = response.Content;

                      if (response.StatusCode.ToString() == "OK")
                      {
                          Toast.MakeText(this, "Успех!", ToastLength.Short).Show();
                          StartActivity(typeof(PhotoActivity));
                      }
                  }
              };
            FindViewById<Button>(Resource.Id.ZakonchitSmenuBn).Click += async delegate
              {
                  var result = await scanner.Scan();

                  if (result != null)
                  {
                      var request = new RestRequest("/EndWorkingDays", Method.POST);
                      request.AddJsonBody(new
                      {
                          Company = Fragments.EnterFragment.company,
                          INN = result.Text,
                          EndDay = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                      });
                      var response = client.Execute(request);
                      string content = response.Content;

                      if (response.StatusCode.ToString() == "OK")
                      {
                          Toast.MakeText(this, "Успех!", ToastLength.Short).Show();
                          StartActivity(typeof(PhotoActivity));
                      }
                  }
              };
            FindViewById<Button>(Resource.Id.zakonchitPererivBn).Click += async delegate
              {
                  var result = await scanner.Scan();

                  if (result != null)
                  {
                      var request = new RestRequest("/EndPauses", Method.POST);
                      request.AddJsonBody(new
                      {
                          Company = Fragments.EnterFragment.company,
                          INN = result.Text,
                          EndPause = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                      });
                      var response = client.Execute(request);
                      string content = response.Content;

                      if (response.StatusCode.ToString() == "OK")
                      {
                          Toast.MakeText(this, "Успех!", ToastLength.Short).Show();
                          StartActivity(typeof(PhotoActivity));
                      }
                  }
              };
        }
    }
}