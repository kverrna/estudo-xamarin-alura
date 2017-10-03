using System;

using Xamarin.Forms;

namespace TestDrive.Views
{
  public class MasterView : ContentPage
  {
    public MasterView()
    {
      Content = new StackLayout
      {
        Children = {
          new Label { Text = "Hello ContentPage" }
        }
      };
    }
  }
}

