using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TestDrive.Models;
using TestDrive.ViewModels;
namespace TestDrive.Views
{
  public partial class LoginView : ContentPage
  {
    public LoginView()
    {
      InitializeComponent();
      this.BindingContext = new LoginModelView(); 
    }
    protected override void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Subscribe<Services.LoginException>(this,"FalhaLogin",async(exc)=>{
        await DisplayAlert("Login",exc.Message,"OK");
      });
    }
    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      MessagingCenter.Unsubscribe<Services.LoginService>(this,"FalhaLogin");
    }

  }
}
