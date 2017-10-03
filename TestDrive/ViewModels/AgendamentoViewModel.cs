using System;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace TestDrive.ViewModels
{
  public class AgendamentoViewModel:BaseViewModel
  {
    const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";
    public Agendamento Agendamento { get; set; }
    public Veiculo Veiculo { get { return Agendamento.Veiculo; } set { Agendamento.Veiculo = value; } }
    public string Nome { get { return Agendamento.Nome; } set { Agendamento.Nome = value; OnPropertyChanged(); ((Command)AgendarCommand).ChangeCanExecute(); } }
    public string Fone { get { return Agendamento.Fone; } set { Agendamento.Fone = value; OnPropertyChanged(); ((Command)AgendarCommand).ChangeCanExecute(); } }
    public string Email { get { return Agendamento.Email; } set { Agendamento.Email = value; OnPropertyChanged(); ((Command)AgendarCommand).ChangeCanExecute(); } }
    public DateTime DataAgendamento { get { return Agendamento.DataAgendamento; } set { Agendamento.DataAgendamento = value; } }
    public TimeSpan HoraAgendamento { get { return Agendamento.HoraAgendamento; } set { Agendamento.HoraAgendamento = value; } }
    public ICommand AgendarCommand { get; set; }

    public AgendamentoViewModel(Veiculo veiculo)
    {
      this.Agendamento = new Agendamento();
      this.Agendamento.Veiculo = veiculo;
      AgendarCommand = new Command(() =>
      {

        MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendamento");
      }, () =>
      {
        return !string.IsNullOrEmpty(this.Nome) 
                      && !string.IsNullOrEmpty(this.Fone) 
                      && !string.IsNullOrEmpty(this.Email);
      });
    }
    public async void SalvaAgendamento()
    {
      HttpClient cliente = new HttpClient();
      var dataHoraAgendamento = new DateTime(
        DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day, HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds
      );
      var json = JsonConvert.SerializeObject(new
      {
        nome = Nome,
        fone = Fone,
        email = Email,
        carro = Veiculo.Nome,
        dataAgendamento = dataHoraAgendamento
      });

      var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
      var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);

      if (resposta.IsSuccessStatusCode)
      {
        MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
      }
      else
      {
        MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
      }
    }

  }
}
