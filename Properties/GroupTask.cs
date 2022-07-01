using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Properties
{
    public class GroupTask : AbstractTask
    {
        private static int count = 0;
        private const int TASKID = 3;
        
        public GroupTask(String name, String info)
        {
            this.id.setTaskId(TASKID);
            this.id.setId(count);
            count++;
            this.info = info;
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public String getInfo()
        {
            return this.info;
        }

        public int countTasks()
        {
            return this._tasks.Count;
        }

        public void add(String name)
        {
            this._tasks.Add(name);
        }

        public String getTaskName(int index)
        {
            return this._tasks[index];
        }

        public void print()
        {
            Console.Out.WriteLine("Group");
            Console.Out.Write("name: " + this.name + "    info: " + this.info + "\n" + "Tasks:\n");
            for (int i = 0; i < this.countTasks(); i++)
            {
                Console.Out.WriteLine("     " + _tasks[i]);
            }
        }

        public void delete(String name)
        {
            for (int i = 0; i < this.countTasks(); i++)
            {
                if (this._tasks[i] == name)
                {
                    this._tasks.RemoveAt(i);
                }
            }
        }
        
        private List<String> _tasks = new List<String>();
    }
}