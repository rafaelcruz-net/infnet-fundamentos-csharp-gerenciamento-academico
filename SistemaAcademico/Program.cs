using SistemaAcademico;

internal class Program
{
    private static GerenciadorArquivo manager;

    private static void Main(string[] args)
    {
        var stopKey = "0";
        var selectedMenu = "";
        manager = new GerenciadorArquivo(); 
        
        while (stopKey != selectedMenu)
        {
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Cadastrar Disciplina");
            Console.WriteLine("3 - Enturmar Aluno em Disciplina");
            Console.WriteLine("4 - Exibir Quadro de horario de Aluno");
            Console.WriteLine("0 - Sair");

            selectedMenu = Console.ReadLine();

            ExercutarOpcao(selectedMenu);

        }
    }

    private static void ExercutarOpcao(string? selectedMenu)
    {
        switch(selectedMenu)
        {
            case "1":
                CadastrarAluno();
                break;
            case "2":
                CadastrarDisciplina();
                break;
            case "3": 
                EnturmarAluno();
                break;
            case "4":
                ExibirQuadroAluno();
                break;
            case "0":
                manager.SalvarListas();
                Console.WriteLine("Saindo do programa...");
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }

    private static void ExibirQuadroAluno()
    {
        Console.WriteLine("Digite o nome do aluno");
        string nomeAluno = Console.ReadLine();
        Aluno aluno = manager.Alunos.FirstOrDefault(x => x.Nome == nomeAluno);

        if (aluno == null) {
            Console.WriteLine("Não encontrei o aluno");
            return;
        }

        Console.WriteLine($"Nome do aluno: {aluno.Nome}");
        Console.WriteLine($"Matricula do aluno: {aluno.Matricula}");
        Console.WriteLine($"Data de nascimento do aluno: {aluno.DataNascimento}");
        Console.WriteLine($"================= QUADRO DE HORARIO===================");
        foreach (var item in aluno.DisciplinasMatriculadas)
        {
            Console.WriteLine($"Nome da disciplina: {item.Nome}");
            Console.WriteLine($"Professor da disciplina: {item.Professor}");
            Console.WriteLine($"Hora de inicio da disciplina: {item.HoraInicio}");
            Console.WriteLine("");
        }

    }

    private static void EnturmarAluno()
    {
        Console.WriteLine("Digite o nome do aluno");
        string nomeAluno = Console.ReadLine();
        Aluno aluno = manager.Alunos.FirstOrDefault(x => x.Nome == nomeAluno);

        if (aluno == null) {
            Console.WriteLine("Não encontrei o aluno");
            return;
        }

        Console.WriteLine("Digite o nome da disciplina");
        string nomeDisciplina = Console.ReadLine();
        Disciplina disciplina = manager.Disciplinas.FirstOrDefault(x => x.Nome == nomeDisciplina);

        if (disciplina == null) {
            Console.WriteLine("Não encontrei a disciplina");
            return;
        }

        aluno.Enturmar(disciplina);

    }

    private static void CadastrarDisciplina()
    {
        Disciplina disciplina = new Disciplina();

        Console.WriteLine("Digite o nome do disciplina"); 
        disciplina.Nome = Console.ReadLine();

        Console.WriteLine("Digite o professor da disciplina"); 
        disciplina.Professor = Console.ReadLine();

        Console.WriteLine("Digite a hora de inicio"); 
        disciplina.HoraInicio = TimeOnly.Parse(Console.ReadLine());

        Console.WriteLine("Digite a duração"); 
        disciplina.Duracao = TimeOnly.Parse(Console.ReadLine());

        manager.AdicionarDisciplina(disciplina);
    }

    private static void CadastrarAluno()
    {
        Aluno aluno = new Aluno();
        
        Console.WriteLine("Digite o nome do aluno");
        aluno.Nome = Console.ReadLine();

        Console.WriteLine("Digite a matricula do aluno");
        aluno.Matricula = Console.ReadLine();

        Console.WriteLine("Digite a data de nascimento do aluno");
        aluno.DataNascimento = Convert.ToDateTime(Console.ReadLine());

        manager.AdicionarAluno(aluno);
    }
}