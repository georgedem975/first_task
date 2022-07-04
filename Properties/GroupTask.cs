using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Properties
{
    public class GroupTask : AbstractTask
    {
        private static int s_Count;
        private const int Taskid = 3;
        
        public GroupTask(string name, string info)
        {
            Id.SetTaskId(Taskid);
            Id.SetId(s_Count);
            s_Count++;
            Info = info;
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetInfo()
        {
            return Info;
        }

        public int CountTasks()
        {
            return _tasks.Count;
        }

        public void Add(string name)
        {
            _tasks.Add(name);
        }

        public string GetTaskName(int index)
        {
            return _tasks[index];
        }

        public void Print()
        {
            Console.Out.WriteLine("Group");
            Console.Out.Write($"name: {this.Name}    info: {this.Info}\nTasks:\n");
            for (int i = 0; i < CountTasks(); i++)
            {
                Console.Out.WriteLine($"     {_tasks[i]}");
            }
        }

        public void Delete(string name)
        {
            for (int i = 0; i < CountTasks(); i++)
            {
                if (_tasks[i] == name)
                {
                    _tasks.RemoveAt(i);
                }
            }
        }
        
        private List<String> _tasks = new List<String>();
    }
}