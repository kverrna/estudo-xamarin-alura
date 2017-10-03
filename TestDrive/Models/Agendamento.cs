using System;
namespace TestDrive.Models
{
  public class Agendamento
  {
		public Veiculo Veiculo { get; set; }
		public string Nome { get; set; }
		public string Fone { get; set; }
		public string Email { get; set; }
		public DateTime DataAgendamento{ get; set; }
		public TimeSpan HoraAgendamento{ get; set; }

		public Agendamento()
    {
      DataAgendamento = DateTime.Today;
      HoraAgendamento = DateTime.Today.TimeOfDay;
    }
  }
}
