using System;
using System.Collections.Generic;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
  public partial class MasterView : TabbedPage
  {
    public MasterViewModel _viewModel { get; set; }
    public MasterView(Usuario usuario)
    {
      InitializeComponent();
      this._viewModel = new MasterViewModel(usuario);
      this.BindingContext = _viewModel;
    }
    protected override void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Subscribe<Usuario>(this,"EditarPerfil",(usuario) => {
        this.CurrentPage = this.Children[1];
      });
    }
    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      MessagingCenter.Unsubscribe<Usuario>(this,"EditarPerfil");
    }
  }
}
