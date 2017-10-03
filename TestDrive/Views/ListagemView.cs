using Xamarin.Forms;
using System.Collections.Generic;
using TestDrive.Models;
using TestDrive.ViewModels;
namespace TestDrive.Views
{
  
  public partial class ListagemView : ContentPage
  {
    public ListagemViewModel ListagemViewModel { get; set;}
    public ListagemView()
    {
      InitializeComponent();
      ListagemViewModel=new ListagemViewModel();
      this.BindingContext = ListagemViewModel; //binding via codeBehind

    }
    protected override async void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Subscribe<Veiculo>(this,"VeiculoSelecionado",(msg)=>
      {
        Navigation.PushAsync(new DetalheView(msg));
      });

      await this.ListagemViewModel.GetVeiculos();
    }
    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      MessagingCenter.Unsubscribe<Veiculo>(this,"VeiculoSelecionado");
    }

  }
}
