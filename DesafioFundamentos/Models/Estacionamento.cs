using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    /// <summary>
    /// Representa o back-end do sistema do estacionamento, com sua lista de carros
    /// estacionados e métodos para manipular e exibir a lista.
    /// </summary>
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private Regex formatoPlaca = new Regex("([A-Za-z]{3})([-]?)([0-9][0-9A-Za-z])([0-9]{2})");

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        /// <summary>
        /// Aguarda a entrada de uma placa via Console, remove espaços no início e fim, 
        /// deixa as letras maiúsculas e retira o hífen de placas brasileiras.
        /// </summary>
        /// <returns>A placa digitada pelo usuário após sanitização.</returns>
        private string ObterPlaca()
        {
            return Console.ReadLine().ToUpper().Trim().Replace("-", "");
        }

        /// <summary>
        /// Pede uma placa no formato brasileiro ou Mercosul, sanitiza e
        /// adiciona a entrada na lista de veículos estacionados.
        /// </summary>
        public void AdicionarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para estacionar\n" +
                "ou \"cancelar\" para voltar ao menu anterior");
            Console.Write("\n> ");

            string placa = ObterPlaca();

            if (placa != "CANCELAR")
            {
                while (placa.Length > 7 || !formatoPlaca.IsMatch(placa))
                {
                    Console.Clear();
                    Console.WriteLine("Placa invalida. Os formatos suportados são \n" +
                        "os de placa brasileira e placa Mercosul. \n");
                    Console.WriteLine("Digite a placa do veículo para estacionar\n" +
                        "ou \"cancelar\" para voltar ao menu anterior");
                    Console.Write("\n> ");

                    placa = ObterPlaca();
                    if (placa == "CANCELAR") break;
                }

                if (placa != "CANCELAR")
                {
                    if (veiculos.Any(x => x == placa.ToUpper()))
                    {
                        Console.WriteLine("\nNão foi possível completar a solicitação pois \n" +
                            "o veículo informado já está estacionado!");
                    }
                    else
                    {
                        veiculos.Add(placa);
                        Console.WriteLine("\nVeículo registrado com sucesso!");
                    }
                }
            }
        }

        /// <summary>
        /// Pede uma entrada com uma placa, verifica se a entrada existe na lista, e caso
        /// a encontre calcula o valor total a ser cobrado baseado no tempo que o carro
        /// permaneceu no estacionamento.
        /// </summary>
        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = ObterPlaca();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Clear();
                Console.WriteLine("Digite a quantidade de horas que " +
                    $"o veículo {placa} permaneceu estacionado:");

                int horas = 0;
                string horasInput = Console.ReadLine();
                Int32.TryParse(horasInput, out horas);

                while (horas == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada invalida!");
                    Console.WriteLine("Digite a quantidade de horas que " +
                        $"o veículo {placa} permaneceu estacionado:");
                    horasInput = Console.ReadLine();
                    Int32.TryParse(horasInput, out horas);
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placa);
                Console.Clear();
                Console.WriteLine($"O veículo {placa} foi removido e o " +
                    $"preço total foi de: R$ {valorTotal.ToString("N2")}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui.\n" +
                    "Confira se digitou a placa corretamente");
            }
        }

        /// <summary>
        /// Exibe todos os veículos registrados na lista do estacionamento
        /// </summary>
        public void ListarVeiculos()
        {
            Console.Clear();
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:\n");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
