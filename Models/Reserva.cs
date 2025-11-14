namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null) throw new ArgumentNullException(nameof(hospedes));
            if (Suite == null) throw new InvalidOperationException("Nenhuma suite cadastrada");
            if (Suite.Capacidade < hospedes.Count) throw new InvalidOperationException("Capacidade excedida");
                
            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidadeDeHospedes = Hospedes?.Count ?? 0;
            return quantidadeDeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            if(Suite == null) throw new InvalidOperationException("Nenhuma suite cadastrada");
            if(DiasReservados <= 0) throw new InvalidOperationException("Nenhum dia reservado");
            if(ObterQuantidadeHospedes() == 0) throw new InvalidOperationException("Nenhum hospede cadastrado");
            
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor -= valor * 0.1M;
            }

            return valor;
        }
    }
}