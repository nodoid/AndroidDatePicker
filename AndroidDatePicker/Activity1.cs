using System;

using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidDatePicker
{
    [Activity(Label = "AndroidDatePicker", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private TextView dateDisplay;
        private Button pickDate;
        private DateTime date;
        const int DATE_DIALOG_ID = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            date = DateTime.Today;

            dateDisplay = FindViewById<TextView>(Resource.Id.dateDisplay);
            pickDate = FindViewById<Button>(Resource.Id.pickDate);

            pickDate.Click += delegate { ShowDialog(DATE_DIALOG_ID); };

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            dateDisplay.Text = date.Date.ToString("D");
        }

        void OnDateSet(object s, DatePickerDialog.DateSetEventArgs e)
        {
            this.date = e.Date;
            UpdateDisplay();
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case DATE_DIALOG_ID:
                    return new DatePickerDialog(this, OnDateSet, date.Day, date.Month - 1, date.Year);
            }
            return null;
        }
    }
}

