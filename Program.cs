
namespace ByteBank_Lettycia
{
    public class Program
    {
        //------------ FUNÇÕES DE CORES E TITULOS -------------//

        static string bemvindo = @"            ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
            ██ ▄▄▀█ ██ █▄ ▄█ ▄▄██ ▄▄▀█ ▄▄▀█ ▄▄▀█ █▀██
            ██ ▄▄▀█ ▀▀ ██ ██ ▄▄██ ▄▄▀█ ▀▀ █ ██ █ ▄▀██
            ██ ▀▀ █▀▀▀▄██▄██▄▄▄██ ▀▀ █▄██▄█▄██▄█▄█▄██
            ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
         ";

        static string titleMenuFuncionario = @"
             █▀ █ █ █▄ █ ▄▀▀ █ ▄▀▄ █▄ █ ▄▀▄ █▀▄ █ ▄▀▄
             █▀ ▀▄█ █ ▀█ ▀▄▄ █ ▀▄▀ █ ▀█ █▀█ █▀▄ █ ▀▄▀";

        static string titleMenuCliente = @"
                  ▄▀▀ █   █ ██▀ █▄ █ ▀█▀ ██▀
                  ▀▄▄ █▄▄ █ █▄▄ █ ▀█  █  █▄▄";

        static void CorEntradaDeDados()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        static void CorTexto()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        static void CorEnunciado()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        // FUNÇÃO PARA ESCREVER QUANDO NAO HA NENHUMA CONTA CADASTRADA
        static void NaoHaConta()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNão há nenhuma conta cadastrada!");
            Console.WriteLine("Cadastre um usuário ou procure um funcionário \n" +
                "para realizar o seu cadastro.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
            Console.ReadKey();
            Console.Clear();
        }

        // FUNÇÃO PARA ESCREVER QUANDO NAO ENCONTROU UMA CONTA 
        static void ContaNaoEncontrada()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("ATENÇÃO!");
            Console.WriteLine("Não foi possível efetuar essa ação.");
            Console.WriteLine("Motivo: Conta não encontrada.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
            Console.ReadKey();
            Console.Clear();
        }

        //FUNCAO ENCERRAR O PROGRAMA
        static void Encerrar()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Encerrando o programa...Volte sempre!");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.Clear();
        }

        // FUNÇÃO PARA ESCREVER QUANDO SALDO FOR INSUFICIENTE PARA A OPERAÇÃO
        static void SaldoInsuficiente()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Não foi possível efetuar essa ação.");
            Console.WriteLine("Motivo: Saldo Insuficiente.");

        }

        // FUNÇÃO PARA ESCREVER QUANDO FOR INSERIDO VALORES MENORES OU IGUAL A ZERO
        static void ValorNulo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Não foi possível efetuar essa ação.");
            Console.WriteLine("Motivo: Valor inserido é nulo ou menor que zero.");
            Console.WriteLine("");
        }

        // FUNÇÃO PARA ESCREVER QUANDO A CONFIRMACAO FOR DIFERENTE DE S OU N
        static void Confirmacao_incorreta()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Digite S para SIM ou N para NÃO: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        // FUNÇÃO PARA SENHA INCORRETA 
        static void Senha_Incorreta()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Senha incorreta!");
            CorTexto();
            Console.Write("\nDigite a senha novamente: ");
            CorEntradaDeDados();
        }

        static void Usuario_Block()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Usuário BLOQUEADO por limite de tentativas!");
            Console.WriteLine("Procure um funcionário para desbloquear sua conta.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
            Console.ReadKey();
            Console.Clear();
        }

        //------------ FUNÇÃO MENU PRINCIPAL-------------//
        static void MenuApresentacao()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n");
            Console.Write(new string(' ', 27));
            Console.WriteLine("Bem vindo ao");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(bemvindo);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nOlá, informe se você é:\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 - Funcionário");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("2 - Cliente ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nOu pressione zero[0] para sair do programa");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('-', 30));
        }


        //------------ OPÇÕES DE FUNCIONARIO-------------//
        static void EntradaDeFuncionario()
        {
            string senhadeacesso = "0123";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(titleMenuFuncionario);
            CorEnunciado();
            Console.Write(new string(' ', 22));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- ÁREA DO FUNCIONÁRIO -");
            CorTexto();

            Console.Write("\nInsira a senha de acesso ao sistema: ");
            CorEntradaDeDados();
            string senha_inserida = GetPassword();
            Console.WriteLine("");

            while (senha_inserida != senhadeacesso)
            {
                Senha_Incorreta();
                senha_inserida = GetPassword();
                Console.WriteLine("");
            }

            if (senha_inserida == senhadeacesso)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Acesso Permitido à Área do Funcionário!");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                Console.Clear();
                MenuFuncionario();
            }

        }

        static void MenuFuncionario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(titleMenuFuncionario);
            CorEnunciado();
            Console.Write(new string(' ', 22));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- ÁREA DO FUNCIONÁRIO -");
            Console.Write(new string(' ', 16));
            CorTexto();

            Console.WriteLine("Veja abaixo as opções disponíveis:");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 - Inserir novo usuário/conta");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("2 - Deletar um usuário");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3 - Detalhes de um usuário");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("4 - Desbloquear um usuário");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("5 - Total armazenado no banco");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("6 - Listar todas as contas registradas");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("7 - Voltar ao Menu Principal");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("0 - Encerrar o Programa");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('-', 30));
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [1] Inserir novo Usuário");
            Console.WriteLine("Insira abaixo os dados da nova conta:");

            CorTexto();
            Console.WriteLine("");
            Console.Write("Digite o CPF: ");
            CorEntradaDeDados();
            string cpf_inserido = Console.ReadLine();

            while (cpf_inserido.Length != 11)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O CPF deve possuir 11 digítos!");
                CorTexto();
                Console.Write("\nDigite o CPF novamente: ");
                CorEntradaDeDados();
                cpf_inserido = Console.ReadLine();
            }

            cpfs.Add(cpf_inserido);
            CorTexto();

            Console.Write("Digite o nome do titular: ");
            CorEntradaDeDados();
            titulares.Add(Console.ReadLine().ToUpper());
            CorTexto();

            Console.Write("Insira uma senha (4 digítos): ");
            CorEntradaDeDados();
            string senhaconta = GetPassword();

            while (senhaconta.Length != 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: A senha deve possuir 4 digítos!");
                CorTexto();

                Console.Write("\nInsira uma senha (4 digítos): ");
                CorEntradaDeDados();
                senhaconta = GetPassword();
            }

            CorTexto();
            Console.Write("Confirme a senha inserida: ");
            CorEntradaDeDados();
            string confir_senha = GetPassword();
            Console.WriteLine("");
            CorTexto();

            while (senhaconta != confir_senha)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Senhas não conferem, digite as senhas novamente.");
                Console.WriteLine("");

                CorTexto();
                Console.Write("Insira uma senha (4 digítos): ");
                CorEntradaDeDados();
                senhaconta = GetPassword();

                while (senhaconta.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: A senha deve possuir 4 digítos!");
                    CorTexto();

                    Console.Write("\nInsira uma senha (4 digítos): ");
                    CorEntradaDeDados();
                    senhaconta = GetPassword();
                }

                CorTexto();
                Console.Write("Confirme a senha inserida: ");
                CorEntradaDeDados();
                confir_senha = GetPassword();
                Console.WriteLine("");
                CorTexto();
            }

            senhas.Add(senhaconta);

            Console.Write("Digite o saldo inicial: R$ ");
            CorEntradaDeDados();
            saldos.Add(double.Parse(Console.ReadLine()));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Usuário Cadastrado com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Retornando ao Menu...");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine("");
            Console.Clear();
        }

        static void DeletarUmUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)

        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [2] Deletar um usuário.");
            Console.WriteLine("Para encerrar uma conta, forneça os dados a seguir: \n");

            if (cpfs.Count == 0)
            {
                NaoHaConta();
            }

            else
            {
                CorTexto();
                Console.Write("Digite o CPF do titular da conta: ");
                CorEntradaDeDados();
                string cpfParaDeletar = Console.ReadLine();
                int indexParaDeletar = cpfs.FindIndex(d => d == cpfParaDeletar);

                if (indexParaDeletar == -1)
                {
                    ContaNaoEncontrada();
                }

                else
                {
                    CorTexto();
                    Console.WriteLine("\nPor gentileza, verifique os dados informados:\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string('+', 20));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"CPF: {cpfParaDeletar}");
                    Console.WriteLine($"Titular: {titulares[indexParaDeletar]}");
                    Console.WriteLine($"Saldo: R$ {saldos[indexParaDeletar]:F2}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string('+', 20));

                    CorTexto();
                    Console.WriteLine("\nDeseja prosseguir e deletar a conta informada?");

                    string confirmacao = " ";

                    while ((confirmacao != "s" && confirmacao != "S") && (confirmacao != "n" && confirmacao != "N"))
                    {
                        Confirmacao_incorreta();
                        confirmacao = Console.ReadLine();
                    }

                    if (confirmacao == "s" || confirmacao == "S")
                    {
                        cpfs.Remove(cpfParaDeletar);
                        titulares.RemoveAt(indexParaDeletar);
                        senhas.RemoveAt(indexParaDeletar);
                        saldos.RemoveAt(indexParaDeletar);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine($"Usuário deletado com sucesso.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Retornando ao Menu...");
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }
        }

        static void DetalhesDeUmUsuario(List<string> cpfs, List<string> bloqueados, string status, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [3] Detalhes de um usuário.");
            Console.WriteLine("");

            if (cpfs.Count == 0)
            {
                NaoHaConta();
            }

            else
            {
                CorTexto();
                Console.Write("Digite o CPF do titular conta: ");
                CorEntradaDeDados();
                string cpfParaDetalhar = Console.ReadLine();
                int indexParaDetalhar = cpfs.FindIndex(d => d == cpfParaDetalhar);

                if (indexParaDetalhar == -1)
                {
                    ContaNaoEncontrada();
                }
                else
                {
                    int indexStatus = bloqueados.FindIndex(d => d == cpfParaDetalhar);

                    if (indexStatus == -1)
                    {
                        status = "ATIVO";
                    }
                    else
                    {
                        status = "BLOQUEADO";
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    ApresentaConta(indexParaDetalhar, cpfs, titulares, saldos);
                    Console.WriteLine($"Status = {status}");
                    CorTexto();
                    Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
                    Console.ReadKey();
                }
            }
        }

        static void DesbloquearUmUsuario(List<string> bloqueados)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [4] Desbloquear um usuário.");
            Console.WriteLine("");

            if (bloqueados.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão há nenhum usuário bloqueado no momento");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nRetornando ao Menu ...");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Console.Clear();
            }
            else
            {

                Console.Write("Informe o CPF do usuário que deseja desbloquear: ");
                CorEntradaDeDados();
                string cpfParaDesbloquear = Console.ReadLine();

                int indexParaDesbloquear = bloqueados.FindIndex(d => d == cpfParaDesbloquear);

                if (indexParaDesbloquear == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("Este usuário não está bloqueado!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Retornando ao Menu...");
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    Console.Clear();
                }
                else
                {
                    bloqueados.RemoveAt(indexParaDesbloquear);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine($"Usuário desbloqueado com sucesso.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Retornando ao Menu...");
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    Console.Clear();
                }
            }
        }

        static void SomaValores(List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [5] Valor armazenado no banco.");
            saldos.Aggregate(0.0, (valorInicial, valorInserido) => valorInicial + valorInserido);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Total acumulado no banco: R$ {saldos.Aggregate(0.0, (valorInicial, valorInserido) => valorInicial + valorInserido):F2}");
            CorTexto();
            Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
            Console.ReadKey();
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [6] Listar todas as contas cadastradas.");
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
                CorTexto();
                Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
                Console.ReadKey();
            }
            Console.WriteLine("");

        }


        //------------ OPÇÕES DE CLIENTE -------------//

        static void EntradaDoCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(titleMenuCliente);
            CorEnunciado();
            Console.Write(new string(' ', 22));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- ÁREA DO CLIENTE -");
            CorTexto();
            Console.Write("\nDigite o CPF do titular da conta: ");
        }

        static void MenuCliente(List<string> cpfs, string cpfParaAcesso, List<string> titulares)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(titleMenuCliente);
            CorEnunciado();
            Console.Write(new string(' ', 22));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- ÁREA DO CLIENTE -");
            Console.Write(new string(' ', 14));
            CorTexto();
            Console.WriteLine("Veja abaixo as opções disponíveis:");
            Console.WriteLine("");

            int indexParaApresentar = cpfs.FindIndex(d => d == cpfParaAcesso);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"USUÁRIO: {titulares[indexParaApresentar]}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 - Depósito");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("2 - Saque");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3 - Transferência");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("4 - Saldo");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("5 - Voltar ao Menu Principal / Logout");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("0 - Encerrar o Programa");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('-', 30));
        }

        static void DepositarValor(List<string> cpfs, string cpfParaAcesso, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [1] Depósito");
            Console.WriteLine("");

            int indexParaManipular = cpfs.FindIndex(d => d == cpfParaAcesso);

            if (indexParaManipular == -1)
            {
                ContaNaoEncontrada();
            }
            else
            {
                CorTexto();
                Console.Write("Insira o valor do depósito: R$ ");
                CorEntradaDeDados();
                double valor_deposito = Double.Parse(Console.ReadLine());

                while (valor_deposito <= 0)
                {
                    ValorNulo();
                    CorTexto();
                    Console.Write("Insira o valor do depósito: R$ ");
                    CorEntradaDeDados();
                    valor_deposito = Double.Parse(Console.ReadLine());
                }

                string escrever = cpfParaAcesso;

                CorTexto();
                Console.WriteLine("\nPor gentileza, verifique os dados informados:\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(new string('+', 20));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("      DEPÓSITO");
                Console.WriteLine($"CPF: {escrever}");
                Console.WriteLine($"Titular: {titulares[indexParaManipular]}");
                Console.WriteLine($"Valor: R$ {valor_deposito:F2}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(new string('+', 20));

                CorTexto();
                Console.WriteLine("\nDeseja prosseguir com o depósito?");
                string confirmacao = " ";

                while ((confirmacao != "s" && confirmacao != "S") && (confirmacao != "n" && confirmacao != "N"))
                {
                    Confirmacao_incorreta();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    confirmacao = Console.ReadLine();
                }

                if (confirmacao == "s" || confirmacao == "S")
                {
                    saldos[indexParaManipular] += valor_deposito;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine("Depósito efetuado com sucesso!");
                }
                else
                {
                    Console.WriteLine("");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void SacarValor(List<string> cpfs, string cpfParaAcesso, List<string> senhas, List<double> saldos, List<string> titulares)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [2] Saque");
            Console.WriteLine("");

            CorTexto();
            int indexParaManipular = cpfs.FindIndex(d => d == cpfParaAcesso);

            if (indexParaManipular == -1)
            {
                ContaNaoEncontrada();
            }

            else
            {
                CorTexto();
                Console.Write("Insira a senha da conta: ");
                CorEntradaDeDados();
                string senha_inserida = GetPassword();
                Console.WriteLine("");

                while (senha_inserida != senhas[indexParaManipular])
                {
                    Senha_Incorreta();
                    CorEntradaDeDados();
                    senha_inserida = GetPassword();
                    Console.WriteLine("");
                }

                CorTexto();
                Console.Write("Insira o valor do saque: R$ ");
                CorEntradaDeDados();
                double valor_saque = Double.Parse(Console.ReadLine());

                if (valor_saque > saldos[indexParaManipular])
                {
                    SaldoInsuficiente();
                }
                else
                {
                    while (valor_saque <= 0)
                    {
                        ValorNulo();
                        CorTexto();
                        Console.Write("Insira o valor do saque: R$ ");
                        CorEntradaDeDados();
                        valor_saque = Double.Parse(Console.ReadLine());
                    }

                    CorTexto();
                    Console.WriteLine("\nPor gentileza, verifique os dados informados:\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string('+', 20));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("      SAQUE");
                    Console.WriteLine($"CPF: {cpfParaAcesso}");
                    Console.WriteLine($"Titular: {titulares[indexParaManipular]}");
                    Console.WriteLine($"Valor: R$ {valor_saque:F2}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string('+', 20));

                    CorTexto();
                    Console.WriteLine("\nDeseja prosseguir com o depósito?");
                    string confirmacao = " ";

                    while ((confirmacao != "s" && confirmacao != "S") && (confirmacao != "n" && confirmacao != "N"))
                    {
                        Confirmacao_incorreta();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
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
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
                Console.ReadKey();
            }


        }

        static void TransfValor(List<string> cpfs, string cpfParaAcesso, List<string> senhas, List<double> saldos, List<string> titulares)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [3] Transferência entre contas");
            Console.WriteLine("");
            int indexParaManipular = cpfs.FindIndex(d => d == cpfParaAcesso);

            CorTexto();
            Console.Write("Digite o CPF do titular da conta destinatária: ");
            CorEntradaDeDados();
            string cpfParaManipular2 = Console.ReadLine();
            int indexParaManipular2 = cpfs.FindIndex(c => c == cpfParaManipular2);

            if (indexParaManipular2 == -1)
            {
                ContaNaoEncontrada();
            }
            else if (indexParaManipular == indexParaManipular2)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão foi possível continuar.");
                Console.WriteLine("Motivo: Conta remetente e destinatária são iguais.");
                Console.WriteLine("");
            }
            else
            {
                CorTexto();
                Console.Write("Insira a senha da conta: ");
                CorEntradaDeDados();
                string senha_inserida = GetPassword();
                Console.WriteLine("");

                while (senha_inserida != senhas[indexParaManipular])
                {
                    Senha_Incorreta();
                    CorEntradaDeDados();
                    senha_inserida = GetPassword();
                    Console.WriteLine("");
                }

                CorTexto();
                Console.Write("Insira o valor da transferência: R$ ");
                CorEntradaDeDados();
                double valor_transferencia = Double.Parse(Console.ReadLine());

                while (valor_transferencia <= 0)
                {
                    ValorNulo();
                    CorTexto();
                    Console.Write("Insira o valor da transferência: R$ ");
                    CorEntradaDeDados();
                    valor_transferencia = Double.Parse(Console.ReadLine());
                }

                if (valor_transferencia > saldos[indexParaManipular])
                {
                    SaldoInsuficiente();
                }
                else
                {
                    Console.WriteLine("");
                    CorTexto();
                    Console.WriteLine("Confirme os dados de transferência:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string('+', 53));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                       TRANSFERÊNCIA");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"Valor: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"R$ {valor_transferencia:F2}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Remetente: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"CPF: {cpfs[indexParaManipular]}  |  Nome: {titulares[indexParaManipular]}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Destinatário: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"CPF: {cpfs[indexParaManipular2]}  |  Nome: {titulares[indexParaManipular2]}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string('+', 53));

                    CorTexto();
                    Console.WriteLine("\nDeseja prosseguir com a transferência?");
                    string confirmacao = " ";

                    while ((confirmacao != "s" && confirmacao != "S") && (confirmacao != "n" && confirmacao != "N"))
                    {
                        Confirmacao_incorreta();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        confirmacao = Console.ReadLine();
                    }

                    if (confirmacao == "s" || confirmacao == "S")
                    {
                        saldos[indexParaManipular] -= valor_transferencia;
                        saldos[indexParaManipular2] += valor_transferencia;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine("Transferência entre contas efetuada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
            Console.ReadKey();
        }
            

        static void VerSaldo(List<string> cpfs, string cpfParaAcesso, List<string> senhas, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("");
            CorEnunciado();
            Console.WriteLine("Opção escolhida: [4] Saldo");
            Console.WriteLine("");

            CorTexto();
            Console.WriteLine("Para ver o saldo da conta, confirme os dados abaixo:\n");
            CorEntradaDeDados();

            int indexParaSaldo = cpfs.FindIndex(d => d == cpfParaAcesso);

            CorTexto();
            Console.Write("Insira a senha da conta: ");
            CorEntradaDeDados();
            string senha_inserida = GetPassword();
            Console.WriteLine("");

            while (senha_inserida != senhas[indexParaSaldo])
            {
                Senha_Incorreta();
                CorEntradaDeDados();
                senha_inserida = GetPassword();
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('+', 20));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("      SALDO");
            Console.WriteLine($"CPF: {cpfParaAcesso}");
            Console.WriteLine($"Titular: {titulares[indexParaSaldo]}");
            Console.WriteLine($"Saldo: R$ {saldos[indexParaSaldo]:F2}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('+', 20));

            CorTexto();
            Console.Write("\nPressione qualquer tecla para voltar ao Menu.");
            Console.ReadKey();
        }


        //------------ FUNÇÃO MAIN -------------//
        public static void Main(string[] args)
        {
            //LISTAS DE ENTRADA DE DADOS
            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();
            List<string> bloqueados = new List<string>();

            string status = "";
            int opcao_escolhida, opcao1, opcao2;
            int i = 0;

        iniciar:
            do
            {
                MenuApresentacao();
                do
                {
                    CorEntradaDeDados();
                    Console.Write("Digite a opção desejada: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    opcao_escolhida = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string('-', 30));

                    if (opcao_escolhida == 1)
                    {
                        EntradaDeFuncionario();

                        do
                        {
                            Console.Clear();
                            MenuFuncionario();
                            CorEntradaDeDados();
                            Console.Write("Digite a opção desejada: ");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            opcao1 = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(new string('-', 30));

                            switch (opcao1)
                            {
                                case 0:
                                    goto encerrar;

                                case 1:
                                    RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                                    MenuFuncionario();
                                    break;

                                case 2:
                                    DeletarUmUsuario(cpfs, titulares, senhas, saldos);
                                    MenuFuncionario();
                                    break;

                                case 3:
                                    DetalhesDeUmUsuario(cpfs, bloqueados, status, titulares, saldos);
                                    MenuFuncionario();
                                    break;

                                case 4:
                                    DesbloquearUmUsuario(bloqueados);
                                    MenuFuncionario();
                                    break;

                                case 5:
                                    SomaValores(saldos);
                                    MenuFuncionario();
                                    break;

                                case 6:
                                    ListarTodasAsContas(cpfs, titulares, saldos);
                                    MenuFuncionario();
                                    break;

                                case 7:
                                    Console.Clear();
                                    goto iniciar;
                            }


                        } while (opcao1 != 0 || opcao1 > 7);
                    }

                    else if (opcao_escolhida == 2)
                    {
                        if (cpfs.Count == 0)
                        {
                            NaoHaConta();
                            goto iniciar;
                        }
                        else
                        {
                            EntradaDoCliente();
                            CorEntradaDeDados();
                            string cpfParaAcesso = Console.ReadLine();

                            int indexParaBloquear = bloqueados.FindIndex(d => d == cpfParaAcesso);
                            int indexParaAcesso = cpfs.FindIndex(d => d == cpfParaAcesso);

                            if (indexParaBloquear == -1)
                            {
                                i = 0;

                                if (indexParaAcesso == -1)
                                {
                                    ContaNaoEncontrada();
                                    goto iniciar;
                                }

                                else
                                {
                                    CorTexto();
                                    Console.Write("Insira a senha da conta: ");
                                    CorEntradaDeDados();
                                    string senha_inserida = GetPassword();
                                    CorEntradaDeDados();
                                    Console.WriteLine("");

                                    while (senhas[indexParaAcesso] != senha_inserida)
                                    {
                                        Senha_Incorreta();
                                        CorEntradaDeDados();
                                        senha_inserida = GetPassword();
                                        Console.WriteLine("");
                                        i++;

                                        if (i >= 4)
                                        {
                                            indexParaBloquear = cpfs.FindIndex(d => d == cpfParaAcesso);

                                            bloqueados.Add(cpfParaAcesso);
                                            Usuario_Block();
                                            goto iniciar;
                                        }
                                    }


                                    if (senha_inserida == senhas[indexParaAcesso])
                                    {
                                        i = 0;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Acesso Permitido à Área do Cliente!");
                                        Thread.Sleep(TimeSpan.FromSeconds(3));
                                        Console.Clear();

                                        do
                                        {
                                            Console.Clear();
                                            MenuCliente(cpfs, cpfParaAcesso, titulares);
                                            Console.Write("Digite a opção desejada: ");
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            opcao2 = int.Parse(Console.ReadLine());
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine(new string('-', 30));

                                            switch (opcao2)
                                            {
                                                case 0:
                                                    goto encerrar;

                                                case 1:
                                                    DepositarValor(cpfs, cpfParaAcesso, titulares, saldos);
                                                    MenuCliente(cpfs, cpfParaAcesso, titulares); break;

                                                case 2:
                                                    SacarValor(cpfs, cpfParaAcesso, senhas, saldos, titulares);
                                                    MenuCliente(cpfs, cpfParaAcesso, titulares); break;

                                                case 3:

                                                    TransfValor(cpfs, cpfParaAcesso, senhas, saldos, titulares);
                                                    MenuCliente(cpfs, cpfParaAcesso, titulares); break;

                                                case 4:
                                                    VerSaldo(cpfs, cpfParaAcesso, senhas, titulares, saldos);
                                                    MenuCliente(cpfs, cpfParaAcesso, titulares);
                                                    break;

                                                case 5:
                                                    Console.Clear();
                                                    goto iniciar;

                                            }
                                        } while (opcao2 != 0 || opcao2 > 5);

                                    }


                                }
                            }
                            else
                            {
                                Usuario_Block();
                                Console.Clear();
                                goto iniciar;

                            }
                        }
                    }

                } while (opcao_escolhida > 2);

            } while (opcao_escolhida != 0);

        encerrar:
            Encerrar();
        }

    }
}
