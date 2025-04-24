using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPractice3
{
    internal class Program

    {
        public class Project
        {
            public string NameProject { get; set; }
            public string DescriptionProject { get; set; }
            public DateTime DateStarter { get; set; }
            public DateTime DateEnd { get; set; }
            public int Status { get; set; }

        }

        public class Task
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int Priority { get; set; }
            public int Status { get; set; }
            public DateTime DateCreate { get; set; }
            public DateTime DateLimite { get; set; }
            public string Projects { get; set; }

        }

        public class Members
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string Position { get; set; }
            public List<string> Tasks { get; set; } = new List<string>();
        }

        enum Options { Project = 1, Task = 2, Members = 3, Assign = 4, Update = 5, Dashboard = 6 }
        enum OptionsProject { Create = 1, Update = 2, Delete = 3, Back = 4 }
        enum OptionsTasks { Create = 1, Update = 2, Delete = 3, Back = 4 }
        enum OptionsMembers { Create = 1, Update = 2, Delete = 3, Back = 4 }
        enum OptionsUpdate { Task = 1, Project = 2 }
        enum StatusID { Pending = 1, Progress = 2, Completed = 3, Cancelled = 4 }
        enum SectionContinue { Yes = 1, No = 2 }

        static void Main(string[] args)
        {
            string ReadInput(string message)
            {
                string input;

                do
                {
                    Console.WriteLine(message);
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Entrada Inválida, Tente novamente");
                    }
                } while (string.IsNullOrWhiteSpace(input));
                return input;
            }

            int ReadInputIsNumber(string message)
            {
                int input;
                bool isNumber;

                do
                {
                    Console.WriteLine(message);
                    isNumber = int.TryParse(Console.ReadLine(), out input);
                    if (!isNumber)
                    {
                        Console.WriteLine("Entrada invalida, digite apenas numeros");
                    }

                } while (!isNumber);
                return input;
            }

            var project = new List<Project>();
            var task = new List<Task>();
            var member = new List<Members>();

            Console.WriteLine("Bem vindo ao Task Manager");

            while (true)
            {
                int Option = Convert.ToInt32(ReadInput("Digite a opção que deseja seguir:\n 1 - Aba de Projetos\n 2 - Aba de Taskes\n 3 - Aba de Membros\n 4 - Atribuir tarefas\n 5 - Atualizar o Status\n 6 - Para Dashboard\n 7 - Para sair"));
                Options OptionSelect = (Options)Option;

                if (OptionSelect == Options.Project)
                {
                    Console.WriteLine("Você está na seção de Projetos");
                    while (true)
                    {
                        int OptionProject = Convert.ToInt32(ReadInputIsNumber("Digite a opção que deseja seguir:\n 1 - Criação de Projeto\n 2 - Atualização de Projeto\n 3 - Remoção de Projeto\n 4 - Para voltar ao menu"));
                        OptionsProject OptionProjectSelect = (OptionsProject)OptionProject;

                        if (OptionProjectSelect == OptionsProject.Create)
                        {
                            string NameProjectInsert = ReadInput("Digite o nome do projeto: ");
                            var NameProjectInsertTrue = project.Any(p => p.NameProject == NameProjectInsert);
                            if (NameProjectInsertTrue == false)
                            {

                                string DescriptionProjectInsert = ReadInput("Digite uma descrição do projeto: ");
                                string InputDateTimeStarter = Convert.ToString(ReadInputIsNumber("Digite a data de inicio do projeto: "));
                                DateTime DateStarterInput = DateTime.ParseExact(InputDateTimeStarter, "ddMMyy", null);

                                string IntputDateEnd = Convert.ToString(ReadInputIsNumber("Digite a data limite do projeto: "));
                                DateTime DateEndInput = DateTime.ParseExact(IntputDateEnd, "ddMMyy", null);

                                project.Add(new Project
                                {
                                    NameProject = NameProjectInsert,
                                    DescriptionProject = DescriptionProjectInsert,
                                    DateStarter = DateStarterInput,
                                    DateEnd = DateEndInput,
                                    Status = Convert.ToInt32(StatusID.Pending),
                                });

                            }
                            else
                            {
                                Console.WriteLine("Nome do projeto já existente!");

                            }
                        }
                        else if (OptionProjectSelect == OptionsProject.Update)
                        {
                            string NameProjectInsert = ReadInput("Digite o nome do projeto que deseja atualizar: ");
                            var FindNameProject = project.Any(p => p.NameProject == NameProjectInsert);
                            var UpdateProject = project.FirstOrDefault(p => p.NameProject == NameProjectInsert);
                            if (FindNameProject == true)
                            {
                                int NameProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar o nome do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                SectionContinue sectionContinue = (SectionContinue)NameProjectUpdate;
                                if (sectionContinue == SectionContinue.Yes)
                                {
                                    string UpdateNameProject = ReadInput("Digite o novo nome do projeto: ");
                                    UpdateProject.NameProject = UpdateNameProject;
                                    var UpdateProjectNew = project.FirstOrDefault(p => p.NameProject == UpdateNameProject);
                                    int DescriptionProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a descrição do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                    SectionContinue sectionContinue1 = (SectionContinue)DescriptionProjectUpdate;
                                    if (sectionContinue1 == SectionContinue.Yes)
                                    {
                                        string UpdateDescriptionProject = ReadInput("Digite a nova descrição do projeto: ");
                                        UpdateProjectNew.DescriptionProject = UpdateDescriptionProject;
                                        int DateStartProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data de inicio do projeto?\n Digite 1 - Para Sim e 2 - Para Ñão"));
                                        SectionContinue sectionContinue2 = (SectionContinue)DateStartProjectUpdate;
                                        if (sectionContinue2 == SectionContinue.Yes)
                                        {
                                            string UpdateDateStartProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data de inicio: "));
                                            DateTime UpdateDateStartProject = DateTime.ParseExact(UpdateDateStartProjectInput, "ddMMyy", null);
                                            UpdateProjectNew.DateStarter = UpdateDateStartProject;
                                            int DateEndProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data final do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                            SectionContinue sectionContinue3 = (SectionContinue)DateEndProjectUpdate;
                                            if (sectionContinue3 == SectionContinue.Yes)
                                            {
                                                string UpdateDateEndProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateEndProject = DateTime.ParseExact(UpdateDateEndProjectInput, "ddMMyy", null);
                                                UpdateProjectNew.DateEnd = UpdateDateEndProject;

                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                            else
                                            {
                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                        }
                                        else
                                        {
                                            int DateEndProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data final do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                            SectionContinue sectionContinue3 = (SectionContinue)DateEndProjectUpdate;
                                            if (sectionContinue3 == SectionContinue.Yes)
                                            {
                                                string UpdateDateEndProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateEndProject = DateTime.ParseExact(UpdateDateEndProjectInput, "ddMMyy", null);
                                                UpdateProjectNew.DateEnd = UpdateDateEndProject;

                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                        }
                                    }
                                    else
                                    {
                                        int DateStartProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data de inicio do projeto?\n Digite 1 - Para Sim e 2 - Para Ñão"));
                                        SectionContinue sectionContinue2 = (SectionContinue)DateStartProjectUpdate;
                                        if (sectionContinue2 == SectionContinue.Yes)
                                        {
                                            string UpdateDateStartProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data de inicio: "));
                                            DateTime UpdateDateStartProject = DateTime.ParseExact(UpdateDateStartProjectInput, "ddMMyy", null);
                                            UpdateProjectNew.DateStarter = UpdateDateStartProject;
                                            int DateEndProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data final do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                            SectionContinue sectionContinue3 = (SectionContinue)DateEndProjectUpdate;
                                            if (sectionContinue3 == SectionContinue.Yes)
                                            {
                                                string UpdateDateEndProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateEndProject = DateTime.ParseExact(UpdateDateEndProjectInput, "ddMMyy", null);
                                                UpdateProjectNew.DateEnd = UpdateDateEndProject;

                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                            else
                                            {
                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                        }
                                        else
                                        {
                                            int DateEndProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data final do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                            SectionContinue sectionContinue3 = (SectionContinue)DateEndProjectUpdate;
                                            if (sectionContinue3 == SectionContinue.Yes)
                                            {
                                                string UpdateDateEndProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateEndProject = DateTime.ParseExact(UpdateDateEndProjectInput, "ddMMyy", null);
                                                UpdateProjectNew.DateEnd = UpdateDateEndProject;

                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                            else
                                            {
                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                        }
                                    }
                                }
                                else
                                {

                                    int DescriptionProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a descrição do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                    SectionContinue sectionContinue1 = (SectionContinue)DescriptionProjectUpdate;
                                    if (sectionContinue1 == SectionContinue.Yes)
                                    {
                                        string UpdateDescriptionProject = ReadInput("Digite a nova descrição do projeto: ");
                                        UpdateProject.DescriptionProject = UpdateDescriptionProject;
                                        int DateStartProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data de inicio do projeto?\n Digite 1 - Para Sim e 2 - Para Ñão"));
                                        SectionContinue sectionContinue2 = (SectionContinue)DateStartProjectUpdate;
                                        if (sectionContinue2 == SectionContinue.Yes)
                                        {
                                            string UpdateDateStartProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data de inicio: "));
                                            DateTime UpdateDateStartProject = DateTime.ParseExact(UpdateDateStartProjectInput, "ddMMyy", null);
                                            UpdateProject.DateStarter = UpdateDateStartProject;
                                            int DateEndProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data final do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                            SectionContinue sectionContinue3 = (SectionContinue)DateEndProjectUpdate;
                                            if (sectionContinue3 == SectionContinue.Yes)
                                            {
                                                string UpdateDateEndProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateEndProject = DateTime.ParseExact(UpdateDateEndProjectInput, "ddMMyy", null);
                                                UpdateProject.DateEnd = UpdateDateEndProject;

                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                            else
                                            {
                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                        }
                                        else
                                        {
                                            int DateEndProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data final do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                            SectionContinue sectionContinue3 = (SectionContinue)DateEndProjectUpdate;
                                            if (sectionContinue3 == SectionContinue.Yes)
                                            {
                                                string UpdateDateEndProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateEndProject = DateTime.ParseExact(UpdateDateEndProjectInput, "ddMMyy", null);
                                                UpdateProject.DateEnd = UpdateDateEndProject;

                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                            else
                                            {
                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                        }
                                    }
                                    else
                                    {
                                        int DateStartProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data de inicio do projeto?\n Digite 1 - Para Sim e 2 - Para Ñão"));
                                        SectionContinue sectionContinue2 = (SectionContinue)DateStartProjectUpdate;
                                        if (sectionContinue2 == SectionContinue.Yes)
                                        {
                                            string UpdateDateStartProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data de inicio: "));
                                            DateTime UpdateDateStartProject = DateTime.ParseExact(UpdateDateStartProjectInput, "ddMMyy", null);
                                            UpdateProject.DateStarter = UpdateDateStartProject;
                                            int DateEndProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data final do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                            SectionContinue sectionContinue3 = (SectionContinue)DateEndProjectUpdate;
                                            if (sectionContinue3 == SectionContinue.Yes)
                                            {
                                                string UpdateDateEndProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateEndProject = DateTime.ParseExact(UpdateDateEndProjectInput, "ddMMyy", null);
                                                UpdateProject.DateEnd = UpdateDateEndProject;

                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                        }
                                        else
                                        {
                                            int DateEndProjectUpdate = Convert.ToInt32(ReadInput("Deseja alterar a data final do projeto?\n Digite 1 - Para Sim e 2 - Para Não"));
                                            SectionContinue sectionContinue3 = (SectionContinue)DateEndProjectUpdate;
                                            if (sectionContinue3 == SectionContinue.Yes)
                                            {
                                                string UpdateDateEndProjectInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateEndProject = DateTime.ParseExact(UpdateDateEndProjectInput, "ddMMyy", null);
                                                UpdateProject.DateEnd = UpdateDateEndProject;

                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                            else
                                            {
                                                Console.WriteLine($"O projeto {FindNameProject} foi atualizado!");

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (OptionProjectSelect == OptionsProject.Delete)
                        {
                            string NameProjectInsert = ReadInput("Digite o nome do projeto que deseja remover: ");
                            var FindNameProject = project.Any(p => p.NameProject == NameProjectInsert);
                            if (FindNameProject == false)
                            {
                                Console.WriteLine("Projeto não localizado");
                            }
                            else
                            {
                                int OptionsDeleteProject = Convert.ToInt32(ReadInputIsNumber($"Deseja deletar o projeto {FindNameProject}?\n Digite 1 - Para seguir com a exclusão ou 2 - Para cancelar a exclusão"));
                                SectionContinue sectionContinueDelete = (SectionContinue)OptionsDeleteProject;
                                if (sectionContinueDelete == SectionContinue.Yes)
                                {
                                    project.RemoveAll(p => p.NameProject == NameProjectInsert);
                                    Console.WriteLine("Projeto removido com sucesso");
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                else if (OptionSelect == Options.Task)
                {
                    Console.WriteLine("Você está na seção de Tarefas");
                    while (true)
                    {
                        int OptionsTask = Convert.ToInt32(ReadInputIsNumber("Digite a opção que deseja seguir:\n 1 - Criação de Terefas\n 2 - Atualização de Tarefas\n 3 - Remoção de Tarefas\n 4 - Para voltar ao menu"));
                        OptionsTasks OptionTaskSelection = (OptionsTasks)OptionsTask;
                        if (OptionTaskSelection == OptionsTasks.Create)
                        {
                            string NameTaskInsert = ReadInput("Digite o nome da tarefa que deseja criar: ");
                            var NameTasktInsertTrue = task.Any(p => p.Title == NameTaskInsert);
                            if (NameTasktInsertTrue == false)
                            {
                                string DescriptionInsert = ReadInput("Digite a descrição da tarefa: ");
                                int PriorityInsertMenu = Convert.ToInt16(ReadInputIsNumber("Escolha a prioridade do tarefa:\n 1 - Baixa\n 2 - Média\n 3 - Alta\n 4 - Urgente"));
                                int StatusInsertMenu = Convert.ToInt16(ReadInputIsNumber("Escolha o status da tarefa:\n 1 - Pendente\n 2 - Em progresso\n 3 - Completa\n 4 - Cancelada"));
                                DateTime DateNow = DateTime.Now;
                                string DateLimiteInsertMenu = ReadInput("Digite a data limite da tarefa (formato: ddMMyy): ");
                                DateTime DateLimiteInsert = DateTime.ParseExact(DateLimiteInsertMenu, "ddMMyy", null);
                                string ProjectAssociete = ReadInput("Digite o projeto que deseja assoiciar com a tarefa: ");
                                var ValidadeProcjectAssociete = project.Any(p => p.NameProject == ProjectAssociete);
                                if (ValidadeProcjectAssociete == true)
                                {
                                    task.Add(new Task
                                    {
                                        Title = NameTaskInsert,
                                        Description = DescriptionInsert,
                                        Priority = PriorityInsertMenu,
                                        Status = StatusInsertMenu,
                                        DateCreate = DateNow,
                                        DateLimite = DateLimiteInsert,
                                        Projects = ProjectAssociete,
                                    });
                                    Console.WriteLine("Tarefa Cadastrada com sucesso");
                                }
                                else
                                {
                                    Console.WriteLine("Projeto não encontrado!");
                                }
                            }
                        }
                        else if (OptionTaskSelection == OptionsTasks.Update)
                        {
                            string TitleInsert = ReadInput("Digite o nome da tarefa: ");
                            var TitleInsertTrue = task.Any(t => t.Title == TitleInsert);
                            var UpdateTask = task.FirstOrDefault(t => t.Title == TitleInsert);
                            if (TitleInsertTrue == true)
                            {
                                int DescriptionTaskUpdate = ReadInputIsNumber("Deseja alterar a descrição do projeto?\n Digite 1 - Para Sim e 2 - Para Não");
                                SectionContinue sectionContinue1 = (SectionContinue)DescriptionTaskUpdate;
                                if (sectionContinue1 == SectionContinue.Yes)
                                {
                                    string UpdateTaskDescription = ReadInput("Digite a nova descrição da tarefa: ");
                                    UpdateTask.Description = UpdateTaskDescription;
                                    int PriorityTaskUpdate = ReadInputIsNumber("Deseja alterar a prioridade do projeto?\n Digite 1 - Para sim e 2 - Para não");
                                    SectionContinue sectionContinue2 = (SectionContinue)PriorityTaskUpdate;
                                    if (sectionContinue2 == SectionContinue.Yes)
                                    {
                                        int UpdatePriorityTask = ReadInputIsNumber("Digite 1 - Para Baixa\n 2 - Para Média\n 3 - Para Alta\n 4 - Para Urgente");
                                        UpdateTask.Priority = UpdatePriorityTask;
                                        int StatusTaskUpdate = ReadInputIsNumber("Deseja alterar a prioridade do projeto?\n Digite 1 - Para sim e 2 - Para não");
                                        SectionContinue sectionContinue3 = (SectionContinue)StatusTaskUpdate;
                                        if (sectionContinue3 == SectionContinue.Yes)
                                        {
                                            int UpdateStatusTask = ReadInputIsNumber("Digite 1 - Para Pendente\n 2 - Para em Progresso\n 3 - Para Completo\n 4 - Para Cancellada");
                                            UpdateTask.Status = UpdateStatusTask;
                                            int DateLimiteTaskUpdate = ReadInputIsNumber("Deseja alterar a data limite da tarefa?\n Digite 1 - Para Sim e 2 - Para Não");
                                            SectionContinue sectionContinue4 = (SectionContinue)DateLimiteTaskUpdate;
                                            if (sectionContinue4 == SectionContinue.Yes)
                                            {
                                                string UpdateDateLimiteTaskInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateLimiteTask = DateTime.ParseExact(UpdateDateLimiteTaskInput, "ddMMyy", null);
                                                UpdateTask.DateLimite = UpdateDateLimiteTask;
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                            else
                                            {
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            int DateLimiteTaskUpdate = ReadInputIsNumber("Deseja alterar a data limite da tarefa?\n Digite 1 - Para Sim e 2 - Para Não");
                                            SectionContinue sectionContinue4 = (SectionContinue)DateLimiteTaskUpdate;
                                            if (sectionContinue4 == SectionContinue.Yes)
                                            {
                                                string UpdateDateLimiteTaskInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateLimiteTask = DateTime.ParseExact(UpdateDateLimiteTaskInput, "ddMMyy", null);
                                                UpdateTask.DateLimite = UpdateDateLimiteTask;
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                            else
                                            {
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        int StatusTaskUpdate = ReadInputIsNumber("Deseja alterar a prioridade do projeto?\n Digite 1 - Para sim e 2 - Para não");
                                        SectionContinue sectionContinue3 = (SectionContinue)StatusTaskUpdate;
                                        if (sectionContinue3 == SectionContinue.Yes)
                                        {
                                            int UpdateStatusTask = ReadInputIsNumber("Digite 1 - Para Pendente\n 2 - Para em Progresso\n 3 - Para Completo\n 4 - Para Cancellada");
                                            UpdateTask.Status = UpdateStatusTask;
                                            int DateLimiteTaskUpdate = ReadInputIsNumber("Deseja alterar a data limite da tarefa?\n Digite 1 - Para Sim e 2 - Para Não");
                                            SectionContinue sectionContinue4 = (SectionContinue)DateLimiteTaskUpdate;
                                            if (sectionContinue4 == SectionContinue.Yes)
                                            {
                                                string UpdateDateLimiteTaskInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateLimiteTask = DateTime.ParseExact(UpdateDateLimiteTaskInput, "ddMMyy", null);
                                                UpdateTask.DateLimite = UpdateDateLimiteTask;
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                            else
                                            {
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            int DateLimiteTaskUpdate = ReadInputIsNumber("Deseja alterar a data limite da tarefa?\n Digite 1 - Para Sim e 2 - Para Não");
                                            SectionContinue sectionContinue4 = (SectionContinue)DateLimiteTaskUpdate;
                                            if (sectionContinue4 == SectionContinue.Yes)
                                            {
                                                string UpdateDateLimiteTaskInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateLimiteTask = DateTime.ParseExact(UpdateDateLimiteTaskInput, "ddMMyy", null);
                                                UpdateTask.DateLimite = UpdateDateLimiteTask;
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                            else
                                            {
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    int PriorityTaskUpdate = ReadInputIsNumber("Deseja alterar a prioridade do projeto?\n Digite 1 - Para sim e 2 - Para não");
                                    SectionContinue sectionContinue2 = (SectionContinue)PriorityTaskUpdate;
                                    if (sectionContinue2 == SectionContinue.Yes)
                                    {
                                        int UpdatePriorityTask = ReadInputIsNumber("Digite 1 - Para Baixa\n 2 - Para Média\n 3 - Para Alta\n 4 - Para Urgente");
                                        UpdateTask.Priority = UpdatePriorityTask;
                                        int StatusTaskUpdate = ReadInputIsNumber("Deseja alterar a prioridade do projeto?\n Digite 1 - Para sim e 2 - Para não");
                                        SectionContinue sectionContinue3 = (SectionContinue)StatusTaskUpdate;
                                        if (sectionContinue3 == SectionContinue.Yes)
                                        {
                                            int UpdateStatusTask = ReadInputIsNumber("Digite 1 - Para Pendente\n 2 - Para em Progresso\n 3 - Para Completo\n 4 - Para Cancellada");
                                            UpdateTask.Status = UpdateStatusTask;
                                            int DateLimiteTaskUpdate = ReadInputIsNumber("Deseja alterar a data limite da tarefa?\n Digite 1 - Para Sim e 2 - Para Não");
                                            SectionContinue sectionContinue4 = (SectionContinue)DateLimiteTaskUpdate;
                                            if (sectionContinue4 == SectionContinue.Yes)
                                            {
                                                string UpdateDateLimiteTaskInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateLimiteTask = DateTime.ParseExact(UpdateDateLimiteTaskInput, "ddMMyy", null);
                                                UpdateTask.DateLimite = UpdateDateLimiteTask;
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                            else
                                            {
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            int DateLimiteTaskUpdate = ReadInputIsNumber("Deseja alterar a data limite da tarefa?\n Digite 1 - Para Sim e 2 - Para Não");
                                            SectionContinue sectionContinue4 = (SectionContinue)DateLimiteTaskUpdate;
                                            if (sectionContinue4 == SectionContinue.Yes)
                                            {
                                                string UpdateDateLimiteTaskInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateLimiteTask = DateTime.ParseExact(UpdateDateLimiteTaskInput, "ddMMyy", null);
                                                UpdateTask.DateLimite = UpdateDateLimiteTask;
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                            else
                                            {
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        int StatusTaskUpdate = ReadInputIsNumber("Deseja alterar a prioridade do projeto?\n Digite 1 - Para sim e 2 - Para não");
                                        SectionContinue sectionContinue3 = (SectionContinue)StatusTaskUpdate;
                                        if (sectionContinue3 == SectionContinue.Yes)
                                        {
                                            int UpdateStatusTask = ReadInputIsNumber("Digite 1 - Para Pendente\n 2 - Para em Progresso\n 3 - Para Completo\n 4 - Para Cancellada");
                                            UpdateTask.Status = UpdateStatusTask;
                                            int DateLimiteTaskUpdate = ReadInputIsNumber("Deseja alterar a data limite da tarefa?\n Digite 1 - Para Sim e 2 - Para Não");
                                            SectionContinue sectionContinue4 = (SectionContinue)DateLimiteTaskUpdate;
                                            if (sectionContinue4 == SectionContinue.Yes)
                                            {
                                                string UpdateDateLimiteTaskInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateLimiteTask = DateTime.ParseExact(UpdateDateLimiteTaskInput, "ddMMyy", null);
                                                UpdateTask.DateLimite = UpdateDateLimiteTask;
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                            else
                                            {
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            int DateLimiteTaskUpdate = ReadInputIsNumber("Deseja alterar a data limite da tarefa?\n Digite 1 - Para Sim e 2 - Para Não");
                                            SectionContinue sectionContinue4 = (SectionContinue)DateLimiteTaskUpdate;
                                            if (sectionContinue4 == SectionContinue.Yes)
                                            {
                                                string UpdateDateLimiteTaskInput = Convert.ToString(ReadInputIsNumber("Digite a nova data final do projeto: "));
                                                DateTime UpdateDateLimiteTask = DateTime.ParseExact(UpdateDateLimiteTaskInput, "ddMMyy", null);
                                                UpdateTask.DateLimite = UpdateDateLimiteTask;
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                            else
                                            {
                                                int ProjectTaskUpdate = ReadInputIsNumber("Deseja alterar o projeto associado?\n Digite 1 - Para Sim e 2 - Para Não");
                                                SectionContinue sectionContinue5 = (SectionContinue)ProjectTaskUpdate;
                                                if (sectionContinue5 == SectionContinue.Yes)
                                                {
                                                    string UpdateProjectTaskValidate = ReadInput("Digite o nome do projeto que deseja inserir: ");
                                                    var FindNameProject = project.Any(p => p.NameProject == UpdateProjectTaskValidate);
                                                    if (FindNameProject)
                                                    {
                                                        UpdateTask.Projects = UpdateProjectTaskValidate;
                                                        Console.WriteLine("Tarefa atualizada com sucesso!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Projeto não cadastrado");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tarefa atualizada com sucesso!");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (OptionTaskSelection == OptionsTasks.Delete)
                        {
                            string TitleTaskInsert = ReadInput("Digite o nome da tarefa que deseja remover: ");
                            var FindTitleTask = task.Any(t => t.Title == TitleTaskInsert);
                            if (FindTitleTask == false)
                            {
                                Console.WriteLine("Tarefa não localizado");
                            }
                            else
                            {
                                int OptionsDeleteTask = Convert.ToInt32(ReadInputIsNumber($"Deseja deletar o projeto {TitleTaskInsert}?\n Digite 1 - Para seguir com a exclusão ou 2 - Para cancelar a exclusão"));
                                SectionContinue sectionContinueDelete = (SectionContinue)OptionsDeleteTask;
                                if (sectionContinueDelete == SectionContinue.Yes)
                                {
                                    task.RemoveAll(t => t.Title == TitleTaskInsert);
                                    Console.WriteLine("Tarefa removida com sucesso");
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                else if (OptionSelect == Options.Members)
                {
                    Console.WriteLine("Você está na seção de Membros");
                    while (true)
                    {
                        int OptionsMember = ReadInputIsNumber("Escolha uma das opções:\n 1 - Para Criação de membros\n 2 - Para Atualizar Cargos e Tarefas\n 3 - Para Remover membros\n 4 - Para voltar ao menu");
                        OptionsMembers optionMembers = (OptionsMembers)OptionsMember;
                        if (optionMembers == OptionsMembers.Create)
                        {
                            string MemberInsert = ReadInput("Digite o nome do membro que deseja cadastrar: ").Trim();
                            bool FindMember = member.Any(m => m.Name.ToLower() == MemberInsert.ToLower());
                            if (!FindMember)
                            {
                                string Fuction = ReadInput($"Digite a função do {MemberInsert}: ");
                                int NewId = member.Count + 1;
                                member.Add(new Members
                                {
                                    Name = MemberInsert,
                                    Id = NewId,
                                    Position = Fuction,
                                });
                            }
                            else
                            {
                                Console.WriteLine("Membro já cadastrado");
                            }
                        }
                        else if (optionMembers == OptionsMembers.Update)
                        {
                            string MemberInsert2 = ReadInput("Digite o nome do membro: ");
                            var FindMember = member.Any(m => m.Name == MemberInsert2);
                            if (FindMember == true)
                            {
                                var UpdateMember = member.FirstOrDefault(m => m.Name == MemberInsert2);
                                int PositionUpdate = ReadInputIsNumber("Gostaria de atualizar a função do membro?\n Digite 1 - Para Sim e 2 - Para Não");
                                SectionContinue sectionContinue1 = (SectionContinue)PositionUpdate;
                                if (sectionContinue1 == SectionContinue.Yes)
                                {
                                    string UpdatePosition = ReadInput("Digite a nova função: ");
                                    UpdateMember.Position = UpdatePosition;
                                    int TaskUpdate = ReadInputIsNumber("Gostaroa de atualizar a tarefa atribuida?\n 1 - Para Sim 2 - Para não");
                                    SectionContinue sectionContinue2 = (SectionContinue)TaskUpdate;
                                    if (sectionContinue2 == SectionContinue.Yes)
                                    {
                                        string UpdateTaskMember = ReadInput("Digite o nome da tarefa que deseja atribuir: ");
                                        var TaskValidate = task.Any(t => t.Title == UpdateTaskMember);
                                        if (TaskValidate == true)
                                        {
                                            UpdateMember.Tasks.Add(UpdateTaskMember);
                                            Console.WriteLine("Cadastro atualizado");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Tarefa não localizada");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cadastro atualizado");
                                    }
                                }
                                else
                                {
                                    int TaskUpdate = ReadInputIsNumber("Gostaroa de atualizar a tarefa atribuida?\n 1 - Para Sim 2 - Para não");
                                    SectionContinue sectionContinue2 = (SectionContinue)TaskUpdate;
                                    if (sectionContinue2 == SectionContinue.Yes)
                                    {
                                        string UpdateTaskMember = ReadInput("Digite o nome da tarefa que deseja atribuir: ");
                                        var TaskValidate = task.Any(t => t.Title == UpdateTaskMember);
                                        if (TaskValidate == true)
                                        {
                                            UpdateMember.Tasks.Add(UpdateTaskMember);
                                            Console.WriteLine("Cadastro atualizado");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Tarefa não localizada");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cadastro atualizado");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Membro não localizado");
                            }
                        }
                        else if (optionMembers == OptionsMembers.Delete)
                        {
                            string MemberInsert = ReadInput("Digite o nome do membro: ");
                            var FindMember = member.Any(m => m.Name == MemberInsert);
                            if (FindMember == true)
                            {
                                int DeleteContinue = ReadInputIsNumber($"Tem certeza que deseja deletar o membro {MemberInsert}?\n Digite: 1 - Para Sim e 2 - Para Não");
                                SectionContinue optionSelect = (SectionContinue)DeleteContinue;
                                if (optionSelect == SectionContinue.Yes)
                                {
                                    member.RemoveAll(m => m.Name == MemberInsert);
                                    Console.WriteLine("Membro removido com sucesso!");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Membro não encontrado");
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                else if (OptionSelect == Options.Assign)
                {
                    Console.WriteLine("Você está na seção de Atribuição ");
                    while (true)
                    {
                        string TaskMember = ReadInput("Digite a tarefa que deseja atribuir: ");
                        var FindTask = task.Any(t => t.Title == TaskMember);
                        if (FindTask == true)
                        {
                            string MemberInsert = ReadInput("Digite o nome do membro: ");
                            var FindMember = member.Any(m => m.Name == MemberInsert);
                            if (FindMember == true)
                            {
                                var UpdateMember = member.FirstOrDefault(m => m.Name == MemberInsert);
                                UpdateMember.Tasks.Add(TaskMember);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Membro não localizado");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tarefa não encontrada");
                            break;
                        }
                    }


                }
                else if (OptionSelect == Options.Update)
                {
                    Console.WriteLine("Você está na seção de atualização de status");
                    while (true)
                    {
                        int OptionsUpdates = ReadInputIsNumber("Escolha uma das opções:\n 1 - Para atualização de Tarefas\n 2 - Para atualização de Proejtos\n 3 - Para sair");
                        OptionsUpdate optionsUpdate = (OptionsUpdate)OptionsUpdates;
                        if (optionsUpdate == OptionsUpdate.Task)
                        {
                            string TaskUpdate = ReadInput("Digite a tarefa que deseja atualizar: ");
                            var FindTask = task.Any(t => t.Title == TaskUpdate);
                            if (FindTask == true)
                            {
                                var UpdateTask = task.FirstOrDefault(t => t.Title == TaskUpdate);
                                int OptionTaskStatus = ReadInputIsNumber("Escolha uma das opções:\n 1 - Pendente\n 2- Em progresso\n 3 - Completo\n 4 - Cancelado");
                                UpdateTask.Status = OptionTaskStatus;
                                Console.WriteLine("Atualização concluida");
                            }
                            else
                            {
                                Console.WriteLine("Tarefa não encontrada");
                            }
                        }
                        else if (optionsUpdate == OptionsUpdate.Project)
                        {
                            string ProjectUpdate = ReadInput("Digite o projeto que deseja atualizar");
                            var FindProject = project.Any(p => p.NameProject == ProjectUpdate);
                            if (FindProject == true)
                            {
                                var UpdateProject = project.FirstOrDefault(p => p.NameProject == ProjectUpdate);
                                int OptionProjectStatus = ReadInputIsNumber("Escolha uma das opções:\n 1 - Pendente\n 2- Em progresso\n 3 - Completo\n 4 - Cancelado");
                                UpdateProject.Status = OptionProjectStatus;
                                Console.WriteLine("Atualização concluida");
                            }
                            else
                            {
                                Console.WriteLine("Projeto não encontrada");
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (OptionSelect == Options.Dashboard)
                {
                    Console.WriteLine("\nLista de tarefas concluidas:\n");
                    var TaskCompleted = task.Where(t => t.Status == 3).ToList();
                    var MemberTaskCompleted = member.Where(m => m.Tasks.Any(taskTitle => TaskCompleted.Any(tc => tc.Title == taskTitle))).ToList();
                    if (TaskCompleted.Count > 0)
                    {

                        foreach (var t in TaskCompleted)
                        {
                            var MemberResponse = MemberTaskCompleted.Where(m => m.Tasks.Contains(t.Title)).Select(m => m.Name).ToList();
                            string memberstrue = string.Join(", ", MemberResponse);
                            Console.WriteLine($"Título | Descrição | Status | Membros\n{t.Title} | {t.Description} | {t.Status} | {memberstrue}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma tarefa concluida");
                    }
                    Console.WriteLine("\nLista de projetos atrasados:\n");
                    var ProjectLate = project.Where(p => p.DateEnd < DateTime.Today).OrderBy(p => p.DateEnd).ToList();
                    if (ProjectLate.Count > 0)
                    {
                        foreach (var p in ProjectLate)
                        {
                            int DaysLate = (DateTime.Today - p.DateEnd).Days;
                            Console.WriteLine($"{p.NameProject} - Atasado há {DaysLate} dias(s) (prazo: {p.DateEnd:dd/MM/yy})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhum projeto atrasado");
                    }
                    Console.WriteLine("\nLista de projetos perto do fim:\n");
                    var ProjectFinnalyClose = project.Where(p => p.DateEnd >= DateTime.Today && (p.DateEnd - DateTime.Today).TotalDays <= 3).ToList();
                    foreach (var p in ProjectFinnalyClose)
                    {
                        Console.WriteLine($"O projeto {p.NameProject} está perto do prazo final ({p.DateEnd:dd/MM/yy})");
                    }
                }
                else
                {
                    break;
                }
            }

        }
    }
}
