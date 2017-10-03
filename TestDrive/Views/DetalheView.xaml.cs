
using System;
using System.Collections.Generic;
using TestDrive.Models;
using Xamarin.Forms;
using TestDrive.ViewModels;
namespace TestDrive.Views
{
  public partial class DetalheView : ContentPage
  {
    public Veiculo Veiculo { get; set; }
    public DetalheView(Veiculo veiculo)
    {
      InitializeComponent();
      this.Veiculo = veiculo;
      this.BindingContext = new DetalheViewModel(veiculo);
    }

    void ButtonProximo_clicked(object sender, System.EventArgs e)
    {
      Navigation.PushAsync(new AgendamentoView(Veiculo));
    }


  }
}
