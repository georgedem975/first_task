using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1.Properties
{
    public class Reader
    {
        public void read()
        {
            List<Task> tasks = new List<Task>();
            List<GroupTask> groupTasks = new List<GroupTask>();

            while (true)
            {
                String path = "C:\\Users\\user\\Desktop\\ConsoleApplication1\\ConsoleApplication1\\Properties\\import.txt";
                String str = Console.In.ReadLine();
                if (str == "/exit")
                {
                    return;
                }
                
                String name = "", info = "";
                int day, month, year;
                int subtaskId;

                switch (str)
                {
                    //создание новой задачи
                    case "/create_task":
                        Console.Out.WriteLine("enter name and info of task");
                        Console.Out.Write("name: ");
                        name = Console.In.ReadLine();
                        Console.Out.Write("info: ");
                        info = Console.In.ReadLine();
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (tasks[i].getName() == name)
                            {
                                Console.Out.WriteLine("You have task with that name");
                                break;
                            }
                        }
                        tasks.Add(new Task(name, info));
                        break;
                    
                    //просмотр всех созданных задач
                    case "/all_tasks":
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.Out.WriteLine(tasks[i].information());
                        }
                        break;
                    
                    //отметить задачу как выполненную
                    case "/done":
                        Console.Out.WriteLine("enter name of task");
                        name = Console.In.ReadLine();
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (tasks[i].getName() == name)
                            {
                                tasks[i].doneCondition();
                            }
                        }
                        break;
                    
                    //получение всех выполненых задач
                    case "/all_done":
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (tasks[i].conditionIsDone())
                            {
                                Console.Out.WriteLine(tasks[i].information());
                            }
                        }
                        break;
                    
                    //создание задачи с датой
                    case "/create_task_with_date":
                        Console.Out.WriteLine("enter name, info and date of task");
                        Console.Out.Write("name: ");
                        name = Console.In.ReadLine();
                        Console.Out.Write("info: ");
                        info = Console.In.ReadLine();
                        Console.Out.Write("day: ");
                        day = Int32.Parse(Console.In.ReadLine());
                        Console.Out.Write("month: ");
                        month = Int32.Parse(Console.In.ReadLine());
                        Console.Out.Write("year: ");
                        year = Int32.Parse(Console.In.ReadLine());
                        tasks.Add(new Task(name, info, day, month, year));
                        break;
                    
                    //получение задач на сегодня
                    case "/task_today":
                        Console.Out.Write("day: ");
                        day = Int32.Parse(Console.In.ReadLine());
                        Console.Out.Write("month: ");
                        month = Int32.Parse(Console.In.ReadLine());
                        Console.Out.Write("year: ");
                        year = Int32.Parse(Console.In.ReadLine());
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (tasks[i].isToday(day, month, year))
                            {
                                Console.Out.WriteLine(tasks[i].information());
                            }
                        }
                        break;
                    
                    //добавление подзадачи к задаче
                    case "/add_subtask":
                        Console.Out.WriteLine("enter name and info of subtask");
                        Console.Out.Write("name: ");
                        name = Console.In.ReadLine();
                        Console.Out.Write("info: ");
                        info = Console.In.ReadLine();
                        Subtask subtask = new Subtask(name, info);
                        Console.Out.WriteLine("enter number after . of task");
                        subtaskId = Int32.Parse(Console.In.ReadLine());
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (tasks[i].GetId().getId() == subtaskId)
                            {
                                tasks[i].addSubtask(subtask);
                            }
                        }
                        break;
                    
                    //отметка о выполнении подзадачи
                    case "/done_subtask":
                        Console.Out.WriteLine("enter number after . of subtask");
                        subtaskId = Int32.Parse(Console.In.ReadLine());
                        for (int i = 0; i < tasks.Count; i++)
                        {
                                for (int j = 0; j < tasks[i].getCountSubtask(); i++)
                                {
                                    if (subtaskId == tasks[i].GetSubtask(j).getCount())
                                    {
                                        tasks[i].GetSubtask(j).doneCondition();
                                    }
                                }
                        }
                        break;
                    
                    //отображение задачи с подзадачами
                    case "/get_task_with_subtask":
                        Console.Out.WriteLine("enter name of task:");
                        Console.Out.Write("name: ");
                        name = Console.In.ReadLine();
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (name == tasks[i].getName())
                            {
                                Console.Out.WriteLine(tasks[i].information());
                                for (int j = 0; j < tasks[i].getCountSubtask(); j++)
                                {
                                    Console.Out.WriteLine(tasks[i].GetSubtask(j).print());
                                }
                            }
                        }
                        break;
                    
                    //создание группы задач
                    case "/creation_group":
                        Console.Out.WriteLine("enter name and info");
                        name = Console.In.ReadLine();
                        info = Console.In.ReadLine();
                        groupTasks.Add(new GroupTask(name, info));
                        break;
                    
                    //удаление группы задач
                    case "/delete_group":
                        Console.Out.WriteLine("enter name");
                        name = Console.In.ReadLine();
                        for (int i = 0; i < groupTasks.Count; i++)
                        {
                            if (groupTasks[i].getName() == name)
                            {
                                groupTasks.RemoveAt(i);
                            }
                        }
                        break;
                    
                    //добавление задачи в группу
                    case "/add_task_to_group":
                        Console.Out.WriteLine("enter name of group");
                        name = Console.In.ReadLine();
                        for (int i = 0; i < groupTasks.Count; i++)
                        {
                            if (groupTasks[i].getName() == name)
                            {
                                Console.Out.WriteLine("enter name of task");
                                name = Console.In.ReadLine();
                                groupTasks[i].add(name);
                                break;
                            }
                        }
                        break;
                    
                    //удаление задачи из группы
                    case "/delete_task_in_group":
                        Console.Out.WriteLine("enter name of group");
                        name = Console.In.ReadLine();
                        for (int i = 0; i < groupTasks.Count; i++)
                        {
                            if (groupTasks[i].getName() == name)
                            {
                                Console.Out.WriteLine("enter name of task");
                                name = Console.In.ReadLine();
                                groupTasks[i].delete(name);
                                break;
                            }
                        }
                        break;
                    
                    //получение списка групп
                    case "/get_groups":
                        Console.Out.WriteLine("List:");
                        for (int i = 0; i < groupTasks.Count; i++)
                        {
                            groupTasks[i].print();
                        }
                        break;
                    
                    //удаление задачи
                    case "/delete_task":
                        Console.Out.WriteLine("enter name");
                        name = Console.In.ReadLine();
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (tasks[i].getName() == name)
                            {
                                tasks.RemoveAt(i);
                            }
                        }
                        break;
                    
                    //запись в файл
                    case "/import":
                        str = "";
                        String slesh = "\n";
                        String t = "tasks:\n";
                        String g = "group:\n";
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            str += "#2";
                            str += tasks[i].getName();
                            str += ",";
                            str += tasks[i].getInfo();
                            for (int j = 0; j < tasks[i].getCountSubtask(); j++)
                            {
                                str += "#1";
                                str += tasks[i].GetSubtask(j).getName();
                                str += ",";
                                str += tasks[i].GetSubtask(j).getInfo();
                            }
                        }

                        for (int i = 0; i < groupTasks.Count; i++)
                        {
                            str += "#3";
                            str += groupTasks[i].getName();
                            str += ",";
                            str += groupTasks[i].getInfo();
                            for (int j = 0; j < groupTasks[i].countTasks(); j++)
                            {
                                str += "#4";
                                str += groupTasks[i].getTaskName(j);
                            }
                        }
                        
                        
                        
                        File.WriteAllText(@path, str);
                        break;
                    
                    //чтение из файла
                    case "/export":
                        String answer = File.ReadAllText(@path);
                        str = "";
                        for (int i = 0; i < answer.Length; i++)
                        {
                            int j = 0;
                            if (answer[i] == '#')
                            {
                                j = i + 1;
                                i += 2;
                            }

                            switch (answer[j])
                                {
                                    case '1':
                                        while (i + 1 < answer.Length && answer[i] != '#')
                                        {
                                            if (answer[i] == ',')
                                            {
                                                name = str;
                                                str = "";
                                                i++;
                                                continue;
                                            }

                                            str += answer[i].ToString();
                                            i++;
                                        }

                                        info = str;

                                        tasks[tasks.Count - 1].addSubtask(new Subtask(name, answer));
                                        i--;
                                        str = "";
                                        break;
                                    case '2':
                                        while (i + 1 < answer.Length && answer[i] != '#')
                                        {
                                            if (answer[i] == ',')
                                            {
                                                name = str;
                                                str = "";
                                                i++;
                                                continue;
                                            }

                                            str += answer[i].ToString();
                                            i++;
                                        }

                                        info = str;

                                        tasks.Add(new Task(name, info));
                                        i--;
                                        str = "";
                                        break;
                                    case '3':
                                        while (i + 1 < answer.Length && answer[i] != '#')
                                        {
                                            if (answer[i] == ',')
                                            {
                                                name = str;
                                                str = "";
                                                i++;
                                                continue;
                                            }

                                            str += answer[i].ToString();
                                            i++;
                                        }

                                        info = str;

                                        groupTasks.Add(new GroupTask(name, info));
                                        i--;
                                        str = "";
                                        break;
                                    case '4':
                                        while (i < answer.Length && answer[i] != '#')
                                        {
                                            str += answer[i].ToString();
                                            i++;
                                        }

                                        name = str;

                                        groupTasks[groupTasks.Count - 1].add(name);
                                        str = "";
                                        i--;
                                        break;
                                }
                            }
                        break;
                }
            }
        }
    }
}