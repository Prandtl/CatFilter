using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace CatFilter.Droid.Views
{
    [Activity(Label = "Cat Filter")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}
