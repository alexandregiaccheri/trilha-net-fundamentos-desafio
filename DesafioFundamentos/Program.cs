using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

string ObterDecimal()
{
    return Console.ReadLine().Trim().Replace(",", ".");
}

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
    "Digite o preço inicial:");
Console.Write("\nR$: ");

decimal precoInicial = 0;
string precoInicialInput = ObterDecimal();
Decimal.TryParse(precoInicialInput, out precoInicial);

while (precoInicial == 0)
{
    Console.Clear();
    Console.WriteLine("Entrada invalida! Tente novamente.\n" +
    "Digite o preço inicial:");
    Console.Write("\nR$: ");
    precoInicialInput = ObterDecimal();
    Decimal.TryParse(precoInicialInput, out precoInicial);
}

Console.Clear();
Console.WriteLine("Agora digite o preço por hora:");
Console.Write("\nR$: ");

decimal precoPorHora = 0;
string precoPorHoraInput = ObterDecimal();
Decimal.TryParse(precoPorHoraInput, out precoPorHora);

while (precoPorHora == 0)
{
    Console.Clear();
    Console.WriteLine("Entrada invalida! Tente novamente.\n" +
    "Agora digite o preço por hora:");
    Console.Write("\nR$: ");
    precoPorHoraInput = ObterDecimal();
    Decimal.TryParse(precoPorHoraInput, out precoPorHora);
}


// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    Console.Write("\n> ");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("\nOpção inválida");
            break;
    }

    Console.WriteLine("\nPressione ENTER para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
