namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placaVeiculo = Console.ReadLine();
            veiculos.Add(placaVeiculo);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            var placaVeiculo = Console.ReadLine();
            

            int horas = 0;
            decimal valorTotal = 0;
            if (veiculos.Any(x => x.ToUpper() == placaVeiculo.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = Convert.ToInt32(Console.ReadLine());
                valorTotal = precoInicial + Convert.ToDecimal((precoPorHora * horas));

                veiculos.Remove(placaVeiculo);

                Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de: R$ {valorTotal}, qual será a forma de pagamento? \n \n");

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();

                FormaDePagamento(valorTotal);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{veiculo.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void FormaDePagamento(decimal valorTotal)
        {
            Console.Clear();

            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Pix");
            Console.WriteLine("2 - Dinheiro");
            Console.WriteLine("3 - Encerrar");

            switch (Console.ReadLine())
             {
                case "1":
                    Guid guid = Guid.NewGuid();
                    Console.WriteLine($"Chave aleatória do pix: {guid} ");
                    break;

                case "2":
                    Console.WriteLine("Ensira o valor dado em dinheiro");
                    var valorRecebido = Convert.ToInt32(Console.ReadLine());

                    decimal troco = 0;
                    if (valorRecebido > valorTotal)
                        troco = valorTotal - valorRecebido;

                    Console.WriteLine($"{troco.ToString().Replace("-","")}, esse é o valor do troco");
                    break;

                case "3":
                    Console.WriteLine($"Obrigado, volte sempre!");
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
                }
            }
        }
}
