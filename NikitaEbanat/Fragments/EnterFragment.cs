using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NikitaEbanat.Fragments
{
    public class EnterFragment : DialogFragment
    {
        public static string company;
        EditText CompanyEditText;
        Button EnterButton;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.EnterFragmentLayout, container, false);

            this.Dialog.SetTitle("Здарова!");
            CompanyEditText = rootView.FindViewById<EditText>(Resource.Id.CompanyET);
            EnterButton = rootView.FindViewById<Button>(Resource.Id.EnterBn);

            EnterButton.Click += delegate
              {
                  if (!String.IsNullOrEmpty(CompanyEditText.Text))
                  {
                      company = CompanyEditText.Text;
                      this.Activity.StartActivity(new Intent(this.Activity, typeof(FourSquaredButtonsActivity)));
                      Dismiss();
                  }
                  else
                  {
                      Toast.MakeText(this.Activity, "Ты не ввёл!", ToastLength.Short).Show();
                  }
              };

            return rootView;
        }
    }
}