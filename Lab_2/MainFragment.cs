using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Lab_2
{
    public class MainFragment : Fragment, View.IOnClickListener
    {

        EditText etQuestion;
        RadioGroup radioGroup;

        public static MainFragment newInstance()
        {
            return new MainFragment(); ;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var view = inflater.Inflate(Resource.Layout.main_fragment, container, false);

            etQuestion = view.FindViewById<EditText>(Resource.Id.et_question);
            radioGroup = view.FindViewById<RadioGroup>(Resource.Id.rg_answers);


            EditText editText = view.FindViewById<EditText>(Resource.Id.et_question);
            Button btnContinue = view.FindViewById<Button>(Resource.Id.btn_continue);
            btnContinue.SetOnClickListener(this);
            return view;
        }



        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.btn_continue:

                    int selectedId = radioGroup.CheckedRadioButtonId;
                    RadioButton radioButton = radioGroup.FindViewById<RadioButton>(selectedId);
                    string text = radioButton.Text;
                    ShowFragment showFragment = ShowFragment.newInstance($"{etQuestion.Text.ToString()} ({text})");
                    FragmentTransaction transaction = this.FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.container, showFragment);
                    etQuestion.Text = "";
                    transaction.AddToBackStack(null);
                    transaction.Commit();
                    break;
            }
        }
    }
}