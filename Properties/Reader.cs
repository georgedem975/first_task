using System;

namespace ConsoleApplication1.Properties
{
    public static class Reader
    {
        public static void Read()
        {
            var writer = new Writer();
            
            const string path = "C:\\Users\\user\\Desktop\\ConsoleApplication1\\ConsoleApplication1\\Properties\\import.txt";

            while (true)
            {
                var str = Console.In.ReadLine();
                
                if (str == "/exit")
                {
                    return;
                }

                string name, info;
                int day, month, year, subtaskId;
                switch (str)
                {
                    //Cоздание новой задачи.
                    case "/create_task":
                        Console.Out.WriteLine("enter name and info of task");
                        Console.Out.Write("name: ");
                        name = Console.In.ReadLine();
                        Console.Out.Write("info: ");
                        info = Console.In.ReadLine();
                        writer.CreateTask(name, info);
                        break;

                    //Просмотр всех созданных задач.
                    case "/all_tasks":
                        writer.AllTasks();
                        break;
                    
                    //Отметить задачу как выполненную.
                    case "/done":
                        Console.Out.WriteLine("enter name of task");
                        name = Console.In.ReadLine();
                        writer.Done(name);
                        break;
                    
                    //Получение всех выполненых задач.
                    case "/all_done":
                        writer.AllDone();
                        break;
                    
                    //Создание задачи с датой.
                    case "/create_task_with_date":
                        Console.Out.WriteLine("enter name, info and date of task");
                        Console.Out.Write("name: ");
                        name = Console.In.ReadLine();
                        Console.Out.Write("info: ");
                        info = Console.In.ReadLine();
                        Console.Out.Write("day: ");
                        day = Int32.Parse(Console.In.ReadLine() ?? String.Empty);
                        Console.Out.Write("month: ");
                        month = Int32.Parse(Console.In.ReadLine() ?? String.Empty);
                        Console.Out.Write("year: ");
                        year = Int32.Parse(Console.In.ReadLine() ?? String.Empty);
                        writer.CreateTaskWithDate(name, info, day, month, year);
                        break;
                    
                    //Получение задач на сегодня.
                    case "/task_today":
                        Console.Out.Write("day: ");
                        day = Int32.Parse(Console.In.ReadLine() ?? String.Empty);
                        Console.Out.Write("month: ");
                        month = Int32.Parse(Console.In.ReadLine() ?? String.Empty);
                        Console.Out.Write("year: ");
                        year = Int32.Parse(Console.In.ReadLine() ?? String.Empty);
                        writer.TaskToday(day, month, year);
                        break;
                    
                    //Добавление подзадачи к задаче.
                    case "/add_subtask":
                        Console.Out.WriteLine("enter name and info of subtask");
                        Console.Out.Write("name: ");
                        name = Console.In.ReadLine();
                        Console.Out.Write("info: ");
                        info = Console.In.ReadLine();
                        Console.Out.WriteLine("enter number after . of task");
                        subtaskId = Int32.Parse(Console.In.ReadLine() ?? String.Empty);
                        writer.AddSubtask(name, info, subtaskId);
                        break;
                    
                    //Отметка о выполнении подзадачи.
                    case "/done_subtask":
                        Console.Out.WriteLine("enter number after . of subtask");
                        subtaskId = Int32.Parse(Console.In.ReadLine() ?? String.Empty);
                        writer.DoneSubtask(subtaskId);
                        break;
                    
                    //Отображение задачи с подзадачами.
                    case "/get_task_with_subtask":
                        Console.Out.WriteLine("enter name of task:");
                        Console.Out.Write("name: ");
                        name = Console.In.ReadLine();
                        writer.GetTaskWithSubtask(name);
                        break;
                    
                    //Создание группы задач.
                    case "/creation_group":
                        Console.Out.WriteLine("enter name and info");
                        name = Console.In.ReadLine();
                        info = Console.In.ReadLine();
                        writer.CreationGroup(name, info);
                        break;
                    
                    //Удаление группы задач.
                    case "/delete_group":
                        Console.Out.WriteLine("enter name");
                        name = Console.In.ReadLine();
                        writer.DeleteGroup(name);
                        break;
                    
                    //Добавление задачи в группу.
                    case "/add_task_to_group":
                        Console.Out.WriteLine("enter name of group");
                        name = Console.In.ReadLine();
                        writer.AddTaskToGroup(name);
                        break;
                    
                    //Удаление задачи из группы.
                    case "/delete_task_in_group":
                        Console.Out.WriteLine("enter name of group");
                        name = Console.In.ReadLine();
                        writer.DeleteTaskInGroup(name);
                        break;
                    
                    //Получение списка групп.
                    case "/get_groups":
                        Console.Out.WriteLine("List:");
                        writer.GetGroups();
                        break;
                    
                    //Удаление задачи.
                    case "/delete_task":
                        Console.Out.WriteLine("enter name");
                        name = Console.In.ReadLine();
                        writer.DeleteTask(name);
                        break;
                    
                    //Запись в файл.
                    case "/import":
                        writer.Import(path);
                        break;
                    
                    //Чтение из файла.
                    case "/export":
                        writer.Export(path);
                        break;
                }

            }
        }
    }
}