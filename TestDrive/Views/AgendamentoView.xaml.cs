using System;
using System.Collections.Generic;
using TestDrive.Models;
using Xamarin.Forms;
using TestDrive.ViewModels;

namespace TestDrive.Views
{
  public partial class AgendamentoView : ContentPage
  {
    public AgendamentoViewModel ViewModel { get; set; }
    public AgendamentoView(Veiculo veiculo)
    {
      InitializeComponent();
      this.ViewModel = new AgendamentoViewModel(veiculo);
      this.BindingContext = this.ViewModel;

    }
    protected  override void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
      {
        var confirma = await DisplayAlert("Salvar Agendamento", "Deseja mesmo enviar o agendamento?", "Sim", "Não");
        if (confirma)
        {
          this.ViewModel.SalvaAgendamento();
        }

      });
      MessagingCenter.Subscribe<Agendamento>(this,"SucessoAgendamento",(msg) => {
        DisplayAlert("Agendmento","Agendamento Salvo com sucesso!","OK");
      });
      MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) => {
      
        DisplayAlert("Agendmento", "Falha ao agendar o testDrive!", "OK");
	  
      });
    }
    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
      MessagingCenter.Unsubscribe<Agendamento>(this,"SucessoAgendamento");
      MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
    }


  }
}
