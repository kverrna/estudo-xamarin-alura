﻿using Xamarin.Forms;
using TestDrive.Views;
using TestDrive.Models;

namespace TestDrive
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      MainPage = new LoginView();

    }

    protected override void OnStart()
    {
      MessagingCenter.Subscribe<Usuario>(this,"SucessoLogin",(usuario) => {
        MainPage = new NavigationPage(new MasterDetailView(usuario));
      });
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}
