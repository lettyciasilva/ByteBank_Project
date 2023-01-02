
namespace ByteBank_Lettycia
{
    public class Program
    {
        // FUNÇÃO MAIN
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------ Bem vindo ao ByteBank ------------");
            Console.ForegroundColor = ConsoleColor.Black;

            //LISTAS DE ENTRADA DE DADOS
            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int opcao_escolhida;

            MostrarMenu();
            do
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("Digite a opção desejada: ");
                opcao_escolhida = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(new string('-', 47));
                Console.ForegroundColor = ConsoleColor.Black;

                switch (opcao_escolhida)
                {
                    case 0:
                        Console.WriteLine("");
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("--------- Menu Principal ---------");
                        MostrarMenu();
                        break;

                    case 2:
                        DeletarUmUsuario(cpfs, titulares, senhas, saldos);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("--------- Menu Principal ---------");
                        MostrarMenu();
                        break;

                    case 3:
                        DetalhesDeUmUsuario(cpfs, titulares, saldos);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("--------- Menu Principal ---------");
                        MostrarMenu();
                        break;

                    case 4:
                        SomaValores(saldos);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("--------- Menu Principal ---------");
                        MostrarMenu();
                        break;

                    case 5:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("--------- Menu Principal ---------");
                        MostrarMenu();
                        break;

                    case 6:
                        ManipularUmaConta(cpfs, titulares, senhas, saldos);

                        if (cpfs.Count == 0)
                        {
                            NaoHaConta();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("--------- Menu Principal ---------");
                            MostrarMenu();
                        }

                        else
                        {
                            MostrarMenuSecundario();
                            do
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;

                                Console.Write("Digite a opção desejada: ");
                                opcao_escolhida = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine(new string('-', 47));
                                Console.ForegroundColor = ConsoleColor.Black;

                                switch (opcao_escolhida)
                                {
                                    case 4:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("--------- Menu Principal ---------");
                                        MostrarMenu();
                                        break;

                                    case 1:
                                        DepositarValor(cpfs, titulares, saldos);
                                        break;

                                    case 2:
                                        SacarValor(cpfs, titulares, senhas, saldos);
                                        break;

                                    case 3:
                                        TransfValor(cpfs, titulares, senhas, saldos);
                                        break;
                                }
                            } while (opcao_escolhida != 4);
                        }
                        break;
                }
            } while (opcao_escolhida != 0);

        }

        //------------ FUNÇÕES AUXILIARES -------------//

        // FUNÇÃO PARA ESCONDER CARACTER DE SENHA
        static string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }

        // FUNÇÃO DE ESCREVER DADOS DA CONTA 
        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        // FUNÇÃO PARA ESCREVER QUANDO NAO HA NENHUMA CONTA CADASTRADA
        static void NaoHaConta()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Não há nenhuma conta cadastrada!");
            Console.WriteLine("Selecione a opção [1] para cadastrar uma nova conta.");
            Console.WriteLine("");
        }

        // FUNÇÃO PARA ESCREVER QUANDO NAO ENCONTROU UMA CONTA 
        static void ContaNaoEncontrada()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("ATENÇÃO!");
            Console.WriteLine("Não foi possível efetuar essa ação.");
            Console.WriteLine("Motivo: Conta não encontrada.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // FUNÇÃO PARA ESCREVER QUANDO SALDO FOR INSUFICIENTE PARA A OPERAÇÃO
        static void SaldoInsuficiente()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Não foi possível efetuar essa ação.");
            Console.WriteLine("Motivo: Saldo Insuficiente.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // FUNÇÃO PARA ESCREVER QUANDO FOR INSERIDO VALORES MENORES OU IGUAL A ZERO
        static void ValorNulo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Não foi possível efetuar essa ação.");
            Console.WriteLine("Motivo: Valor inserido é nulo ou menor que zero.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // FUNÇÃO PARA ESCREVER QUANDO A CONFIRMACAO FOR DIFERENTE DE S OU N
        static void Confirmacao_incorreta()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Digite S para SIM ou N para NÃO: ");
        }

        // FUNÇÃO PARA SENHA INCORRETA 
        static void Senha_Incorreta()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Senha incorreta!");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Digite a senha novamente: ");
        }


        //------------ INICIO MENU PRINCIPAL -------------//

        // FUNÇÃO MOSTRAR MENU PRINCIPAL
        static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("1 - Inserir novo usuário/conta");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Detalhes de um usuário");
            Console.WriteLine("4 - Total armazenado no banco");
            Console.WriteLine("5 - Listar todas as contas registradas");
            Console.WriteLine("6 - Manipular uma conta");
            Console.WriteLine("0 - Sair do programa");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('-', 47));
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // FUNÇÃO DE REGISTRAR NOVO USUARIO/CONTA
        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [1] Inserir novo Usuário");
            Console.WriteLine("Insira abaixo os dados da nova conta:");

            Console.WriteLine("");
            Console.Write("Digite o CPF: ");
            cpfs.Add(Console.ReadLine());

            Console.Write("Digite o nome do titular: ");
            titulares.Add(Console.ReadLine());

            Console.Write("Insira uma senha para a conta: ");
            string senhaconta = GetPassword();

            Console.Write("Confirme a senha da conta: ");
            string confir_senha = GetPassword();
            Console.WriteLine("");

            while (senhaconta != confir_senha)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Senhas não conferem, digite as senhas novamente.");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("Insira uma senha para a conta: ");
                senhaconta = GetPassword();

                Console.Write("Confirme a senha da conta: ");
                confir_senha = GetPassword();
                Console.WriteLine("");
            }
  
            senhas.Add(senhaconta);            

            Console.Write("Digite o saldo: R$ ");
            saldos.Add(double.Parse(Console.ReadLine()));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Usuário Cadastrado com sucesso!");
            Console.WriteLine("");          
        }

        // FUNÇÃO DE DELETAR UMA CONTA
        static void DeletarUmUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [2] Deletar um usuário.");
            Console.WriteLine("Para encerrar sua conta, forneça os dados a seguir: \n");

            if (cpfs.Count == 0)
            {
                NaoHaConta();
            }

            else
            {
                Console.Write("Digite o CPF da conta a ser deletada: ");
                string cpfParaDeletar = Console.ReadLine();
                int indexParaDeletar = cpfs.FindIndex(d => d == cpfParaDeletar);

                if (indexParaDeletar == -1)
                {
                    ContaNaoEncontrada();
                }

                else
                {
                    cpfs.Remove(cpfParaDeletar);
                    titulares.RemoveAt(indexParaDeletar);
                    senhas.RemoveAt(indexParaDeletar);
                    saldos.RemoveAt(indexParaDeletar);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine($"Usuário deletado com sucesso.");
                    Console.WriteLine("");
                }
            }
        }

        // FUNÇÃO DE DETALHAR UMA CONTA
        static void DetalhesDeUmUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [3] Detalhes de um usuário.");
            Console.WriteLine("");

            if (cpfs.Count == 0)
            {
                NaoHaConta();
            }

            else
            {
                Console.Write("Digite o CPF da conta: ");
                string cpfParaDetalhar = Console.ReadLine();
                int indexParaDetalhar = cpfs.FindIndex(d => d == cpfParaDetalhar);

                if (indexParaDetalhar == -1)
                {
                    ContaNaoEncontrada();
                }
                else
                {
                    Console.WriteLine("");
                    ApresentaConta(indexParaDetalhar, cpfs, titulares, saldos);
                    Console.WriteLine("");
                }
            }
        }

        // FUNÇÃO DE VALOR TOTAL ARMAZENADO NO BANCO
        static void SomaValores(List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [4] Valor total armazenado no banco.");
            saldos.Aggregate(0.0, (valorInicial, valorInserido) => valorInicial + valorInserido);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Total acumulado no banco: R$ {saldos.Aggregate(0.0, (valorInicial, valorInserido) => valorInicial + valorInserido):F2}");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // FUNÇÃO DE LISTAR TODAS AS CONTAS
        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [5] Listar todas as contas cadastradas.");
            Console.WriteLine("");

            if (cpfs.Count == 0)
            {
                NaoHaConta();
            }

            else
            {
                for (int i = 0; i < cpfs.Count; i++)
                {
                    ApresentaConta(i, cpfs, titulares, saldos);
                }
            }
            Console.WriteLine("");
        }

        // FUNÇÃO DE MANIPULAR UMA CONTA
        static void ManipularUmaConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [6] Manipular uma conta.");
            Console.WriteLine("Veja abaixo as opções disponíveis.");
            Console.WriteLine("");

        }


        //------------ INICIO MENU SECUNDARIO -------------//

        // FUNÇÃO MOSTRAR MENU SECUNDARIO
        static void MostrarMenuSecundario()
        {
            Console.WriteLine("1 - Depositar um valor");
            Console.WriteLine("2 - Sacar um valor");
            Console.WriteLine("3 - Transferir um valor");
            Console.WriteLine("4 - Voltar ao Menu Principal");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('-', 47));
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // FUNÇÃO DE DEPOSITAR
        static void DepositarValor(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [6][1] Depositar um valor.");
            Console.WriteLine("");

            Console.Write("Digite o CPF do titular da conta que deseja depositar: ");
            string cpfParaManipular = Console.ReadLine();
            int indexParaManipular = cpfs.FindIndex(d => d == cpfParaManipular);

            if (indexParaManipular == -1)
            {
                ContaNaoEncontrada();
                MostrarMenuSecundario();
            }
            else
            {
                Console.Write("Insira o valor do depósito: R$ ");
                double valor_deposito = Double.Parse(Console.ReadLine());

                while (valor_deposito <= 0)
                {
                    ValorNulo();
                    Console.Write("Insira o valor do depósito: R$ ");
                    valor_deposito = Double.Parse(Console.ReadLine());
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("");
                Console.WriteLine($"Deseja fazer um depósito de R$ {valor_deposito:F2} na conta de {titulares[indexParaManipular]} ?");

                string confirmacao = " ";

                while ((confirmacao != "s" && confirmacao != "S") && (confirmacao != "n" && confirmacao != "N"))
                {
                    Confirmacao_incorreta();
                    confirmacao = Console.ReadLine();
                }

                if (confirmacao == "s" || confirmacao == "S")
                {
                    saldos[indexParaManipular] += valor_deposito;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine("Depósito efetuado com sucesso!");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Black;

                    MostrarMenuSecundario();

                } 
                else
                {
                    Console.WriteLine("");
                    MostrarMenuSecundario();
                }
            }
        }

        // FUNÇÃO DE SAQUE
        static void SacarValor(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [6][2] Sacar um valor.");
            Console.WriteLine("");

            Console.Write("Digite o CPF do titular da conta que deseja sacar: ");
            string cpfParaManipular = Console.ReadLine();
            int indexParaManipular = cpfs.FindIndex(d => d == cpfParaManipular);

            if (indexParaManipular == -1)
            {
                ContaNaoEncontrada();
                MostrarMenuSecundario();
            }

            else
            {
                Console.Write("Insira a senha da conta: ");
                string senha_inserida = GetPassword();
                Console.WriteLine("");

                while (senha_inserida != senhas[indexParaManipular])
                {
                    Senha_Incorreta();
                    senha_inserida = GetPassword();
                    Console.WriteLine("");
                }

                Console.Write("Insira o valor do saque: R$ ");
                double valor_saque = Double.Parse(Console.ReadLine());

                if (valor_saque > saldos[indexParaManipular])
                {
                    SaldoInsuficiente();
                    MostrarMenuSecundario();
                }
                else
                {
                    while (valor_saque <= 0)
                    {
                        ValorNulo();
                        Console.Write("Insira o valor do saque: R$ ");
                        valor_saque = Double.Parse(Console.ReadLine());
                    }

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("");
                    Console.WriteLine($"Deseja fazer um saque de R$ {valor_saque:F2} na conta de {titulares[indexParaManipular]} ?");
                    Console.ForegroundColor = ConsoleColor.Black;

                    string confirmacao = " ";

                    while ((confirmacao != "s" && confirmacao != "S") && (confirmacao != "n" && confirmacao != "N"))
                    {
                        Confirmacao_incorreta();
                        confirmacao = Console.ReadLine();
                    }


                    if (confirmacao == "s" || confirmacao == "S")
                    {
                        saldos[indexParaManipular] -= valor_saque;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine("Saque efetuado com sucesso!");
                        Console.WriteLine("Retire seu dinheiro.");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Black;

                        MostrarMenuSecundario();
                    }
                    else
                    {
                        Console.WriteLine("");
                        MostrarMenuSecundario();
                    }
                }

            }


        }

        // FUNÇÃO DE TRANSFERENCIA
        static void TransfValor(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção escolhida: [6][3] Transferir um valor entre contas.");
            Console.WriteLine("");

            Console.Write("Digite o CPF do titular da conta remetente: ");
            string cpfParaManipular = Console.ReadLine();
            int indexParaManipular = cpfs.FindIndex(d => d == cpfParaManipular);

            if (indexParaManipular == -1)
            {
                ContaNaoEncontrada();
                MostrarMenuSecundario();
            }
            else
            {
                Console.Write("Digite o CPF do titular da conta destinatária: ");
                string cpfParaManipular2 = Console.ReadLine();
                int indexParaManipular2 = cpfs.FindIndex(c => c == cpfParaManipular2);

                if (indexParaManipular2 == -1)
                {
                    ContaNaoEncontrada();
                    MostrarMenuSecundario();
                }
                else if (indexParaManipular == indexParaManipular2){

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNão foi possível continuar.");
                    Console.WriteLine("Motivo: Conta remetente e destinatária são iguais.");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("");
                    MostrarMenuSecundario();
                }
                else
                {
                    Console.Write("Insira a senha da conta: ");
                    string senha_inserida = GetPassword();
                    Console.WriteLine("");

                    while (senha_inserida != senhas[indexParaManipular])
                    {
                        Senha_Incorreta();
                        senha_inserida = GetPassword();
                        Console.WriteLine("");
                    }

                    Console.Write("Insira o valor da transferência: R$ ");
                    double valor_transferencia = Double.Parse(Console.ReadLine());

                    while (valor_transferencia <= 0)
                    {
                        ValorNulo();
                        Console.Write("Insira o valor da transferência: R$ ");
                        valor_transferencia = Double.Parse(Console.ReadLine());
                    }

                    if (valor_transferencia > saldos[indexParaManipular])
                    {
                        SaldoInsuficiente();
                        MostrarMenuSecundario();
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Confirme os dados de transferência:");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Valor: R$ {valor_transferencia:F2}");
                        Console.WriteLine($"Conta Remetente: CPF: {cpfs[indexParaManipular]}   |   Titular: {titulares[indexParaManipular]}");
                        Console.WriteLine($"Conta Destino: CPF: {cpfs[indexParaManipular2]}   |   Titular: {titulares[indexParaManipular2]}");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Deseja prosseguir com a transferência?");

                        string confirmacao = " ";

                        while ((confirmacao != "s" && confirmacao != "S") && (confirmacao != "n" && confirmacao != "N"))
                        {
                            Confirmacao_incorreta();
                            confirmacao = Console.ReadLine();
                        }

                        if (confirmacao == "s" || confirmacao == "S")
                        {
                            saldos[indexParaManipular] -= valor_transferencia;
                            saldos[indexParaManipular2] += valor_transferencia;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("");
                            Console.WriteLine("Transferência entre contas efetuada com sucesso!");
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Black;
                            MostrarMenuSecundario();
                        }
                        else
                        {
                            Console.WriteLine("");
                            MostrarMenuSecundario();
                        }
                    }
                }
            }

        }

    }
}