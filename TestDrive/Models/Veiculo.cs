using System;
namespace TestDrive.Models
{
  public class Veiculo
  {
    public const int FREIO_ABS = 800;
    public const int AR_CONDICIONADO = 1000;
    public const int MP3 = 500;

    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public bool TemFreioABS { get; set; }
    public bool TemArCondicionado { get; set; }
    public bool TemMP3 { get; set; }
    public string PrecoTotalFormatado { get{
        return CalculaValorTotal();
      } 
    }
    public string PrecoFormatado
    {
      get { return string.Format("R$ {0}", Preco); }
    }
		private String CalculaValorTotal()
		{
			decimal adicionalFreio = 0;
			decimal adicionalAr = 0;
			decimal adicionalMP3 = 0;
      if (TemFreioABS) adicionalFreio += FREIO_ABS; else adicionalFreio = 0;
      if (TemArCondicionado) adicionalAr += AR_CONDICIONADO; else adicionalAr = 0;
      if (TemMP3) adicionalMP3 += MP3; else adicionalMP3 = 0;


			return string.Format("Valor total  R$ {0}", Preco + (adicionalMP3 + adicionalAr + adicionalFreio));
		}

  }
}
