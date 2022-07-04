using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1.Properties
{
    public class Writer
    {
        private readonly List<Task> _tasks = new List<Task>();
        private readonly List<GroupTask> _groupTasks = new List<GroupTask>();
        
        
        public void CreateTask(string name, string info)
        {
            foreach (var t in _tasks)
            {
                if (t.GetName() != name) continue;
                Console.Out.WriteLine("You have task with that name");
                return;
            }

            _tasks.Add(new Task(name, info));
        }

        public void AllTasks()
        {
            foreach (var t in _tasks)
            {
                Console.Out.WriteLine(t.Information());
            }
        }

        public void Done(string name)
        {
            foreach (var t in _tasks)
            {
                if (t.GetName() == name)
                {
                    t.DoneCondition();
                }
            }
        }

        public void AllDone()
        {
            foreach (var t in _tasks)
            {
                if (t.ConditionIsDone())
                {
                    Console.Out.WriteLine(t.Information());
                }
            }
        }

        public void CreateTaskWithDate(string name, string info, int day, int month, int year)
        {
            _tasks.Add(new Task(name, info, day, month, year));
        }

        public void TaskToday(int day, int month, int year)
        {
            foreach (var t in _tasks)
            {
                if (t.IsToday(day, month, year))
                {
                    Console.Out.WriteLine(t.Information());
                }
            }
        }

        public void AddSubtask(string name, string info, int subtaskId)
        {
            var subtask = new Subtask(name, info);
            foreach (var t in _tasks)
            {
                if (t.GetId().GetId() == subtaskId)
                {
                    t.AddSubtask(subtask);
                }
            }
        }

        public void DoneSubtask(int subtaskId)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                for (int j = 0; j < _tasks[i].GetCountSubtask(); i++)
                {
                    if (subtaskId == _tasks[i].GetSubtask(j).GetCount())
                    {
                        _tasks[i].GetSubtask(j).DoneCondition();
                    }
                }
            }
        }

        public void GetTaskWithSubtask(string name)
        {
            foreach (var t in _tasks)
            {
                if (name != t.GetName()) continue;
                Console.Out.WriteLine(t.Information());
                for (var j = 0; j < t.GetCountSubtask(); j++)
                {
                    Console.Out.WriteLine(t.GetSubtask(j).Print());
                }
            }
        }

        public void CreationGroup(string name, string info)
        {
            _groupTasks.Add(new GroupTask(name, info));
        }

        public void DeleteGroup(string name)
        {
            for (int i = 0; i < _groupTasks.Count; i++)
            {
                if (_groupTasks[i].GetName() == name)
                {
                    _groupTasks.RemoveAt(i);
                }
            }
        }

        public void AddTaskToGroup(string name)
        {
            foreach (var t in _groupTasks)
            {
                if (t.GetName() != name) continue;
                Console.Out.WriteLine("enter name of task");
                name = Console.In.ReadLine();
                t.Add(name);
                break;
            }
        }

        public void DeleteTaskInGroup(string name)
        {
            foreach (var t in _groupTasks)
            {
                if (t.GetName() != name) continue;
                Console.Out.WriteLine("enter name of task");
                name = Console.In.ReadLine();
                t.Delete(name);
                break;
            }
        }

        public void GetGroups()
        {
            foreach (var t in _groupTasks)
            {
                t.Print();
            }
        }

        public void DeleteTask(String name)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                if (_tasks[i].GetName() == name)
                {
                    _tasks.RemoveAt(i);
                }
            }
        }

        public void Import(string path)
        {
            var str = "";
            for (int i = 0; i < _tasks.Count; i++)
            {
                str += GetTextInTask(i);
            }

            for (int i = 0; i < _groupTasks.Count; i++)
            {
                str += GetTextInGroup(i);
            }

            File.WriteAllText(@path, str);
        }

        private string GetTextInTask(int index)
        {
            var str = "";
            str += "#2";
            str += _tasks[index].GetName();
            str += ",";
            str += _tasks[index].GetInfo();
            return GetTextInSubTask(str, index);
        }

        private string GetTextInSubTask(string str, int index)
        {
            for (var j = 0; j < _tasks[index].GetCountSubtask(); j++)
            {
                str += "#1";
                str += _tasks[index].GetSubtask(j).GetName();
                str += ",";
                str += _tasks[index].GetSubtask(j).GetInfo();
            }

            return str;
        }

        private string GetTextInGroup(int index)
        {
            String str = "";
            str += "#3";
            str += _groupTasks[index].GetName();
            str += ",";
            str += _groupTasks[index].GetInfo();

            return GetTextInTasksOfGroup(str, index);
        }

        private string GetTextInTasksOfGroup(string str, int index)
        {
            for (int j = 0; j < _groupTasks[index].CountTasks(); j++)
            {
                str += "#4";
                str += _groupTasks[index].GetTaskName(j);
            }

            return str;
        }

        public void Export(string path)
        {
            var answer = File.ReadAllText(@path);

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
                        i = GetTask(answer, i);
                        break;
                    case '2':
                        i = GetSubTask(answer, i);
                        break;
                    case '3':
                        i = GetGroup(answer, i);
                        break;
                    case '4':
                        i = GetTaskInGroup(answer, i);
                        break;
                }
            }
        }

        private int GetTaskInGroup(String answer, int i)
        {
            string str = "";

            while (i < answer.Length && answer[i] != '#')
            {
                str += answer[i].ToString();
                i++;
            }

            var name = str;

            _groupTasks[_groupTasks.Count - 1].Add(name);
            i--;

            return i;
        }

        private int GetGroup(String answer, int i)
        {
            var str = "";
            var name = "";
            
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

            var info = str;

            _groupTasks.Add(new GroupTask(name, info));
            i--;

            return i;
        }

        private int GetSubTask(String answer, int i)
        {
            string str = "";
            string name = "";
            
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

            var info = str;

            _tasks.Add(new Task(name, info));
            i--;

            return i;
        }

        private int GetTask(String answer, int i)
        {
            string str = "";
            string name = "";
            
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

            _tasks[_tasks.Count - 1].AddSubtask(new Subtask(name, answer));
            i--;

            return i;
        }
    }
}