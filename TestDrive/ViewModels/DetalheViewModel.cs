using System;
using TestDrive.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestDrive.ViewModels
{
  public class DetalheViewModel:BaseViewModel
  {
		public Veiculo Veiculo { get; set; }


		public string TextoFreioAbs
		{
			get
			{
				return string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS);
			}
		}
		public string TextoArCondicionado
		{
			get
			{
				return string.Format("Ar Condicionado - R$ {0}", Veiculo.AR_CONDICIONADO);
			}
		}
		public string TextoMp3
		{
			get
			{
				return string.Format("MP3 Player - R$ {0}", Veiculo.MP3);
			}
		}

		public bool TemFreioABS
		{
			get
			{
				return Veiculo.TemFreioABS;
			}
			set
			{
				Veiculo.TemFreioABS = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}

		public bool TemArcondicionado
		{
			get
			{
				return Veiculo.TemArCondicionado;
			}
			set
			{
				Veiculo.TemArCondicionado = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}

		public bool TemMP3
		{
			get
			{
				return Veiculo.TemMP3;
			}
			set
			{
				Veiculo.TemMP3 = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}

		public string ValorTotal
		{
			get { return Veiculo.PrecoTotalFormatado; }

		}

    public DetalheViewModel(Veiculo veiculo)
    {
      this.Veiculo = veiculo;
    }

  }
}
