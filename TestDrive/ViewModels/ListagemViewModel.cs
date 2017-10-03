using System;
using TestDrive.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TestDrive.ViewModels
{
  public class ListagemViewModel:BaseViewModel
  {
    const string URL_GET_VEICULOS = "https://aluracar.herokuapp.com";
    private Veiculo _veiculoSelecionado { get; set; }
    private bool _aguarde { get; set; }
    public ObservableCollection<Veiculo> Veiculos { get; set; }
    public bool Aguarde { get { return _aguarde; } set { _aguarde = value;OnPropertyChanged();} }
    public Veiculo VeiculoSelecionado { get { return _veiculoSelecionado; } set { _veiculoSelecionado = value; if (value != null) MessagingCenter.Send(_veiculoSelecionado, "VeiculoSelecionado"); } }

    public ListagemViewModel()
    {
      this.Veiculos = new ObservableCollection<Veiculo>();
    }

    public async Task GetVeiculos()
    {
      Aguarde = true;
      HttpClient cliente = new HttpClient();
      var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

      var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);
      foreach (var veiculo in veiculosJson)
      {
        this.Veiculos.Add(
          new Veiculo()
          {
            Nome=veiculo.nome,
            Preco=veiculo.preco
          }
        );
      }
      Aguarde = false;
    }

  }
  class VeiculoJson
  {
    public string nome { get; set; }
    public decimal preco { get; set; }
  }
}
