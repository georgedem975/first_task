using System;

namespace ConsoleApplication1.Properties
{
    public class Subtask : AbstractTask
    {
        
        private static int s_count = 0;
        private const int Taskid = 2;
        
        public Subtask(String name, String info)
        {
            this.Id.SetTaskId(Taskid);
            this.Id.SetId(s_count);
            s_count++;
            this.Info = info;
            this.Name = name;
        }
        
        public void DoneCondition()
        {
            this.TaskCondition = Condition.Done;
        }

        public String GetName()
        {
            return this.Name;
        }

        public String GetInfo()
        {
            return this.Info;
        }

        public int GetCount()
        {
            return s_count;
        }

        public String Print()
        {
            String str = "Subtask:\nname: " + this.Name + "    info: " + this.Info + "\nid:" + Taskid.ToString() + "." +
                   Id.GetId().ToString() + "\n";
            if (this.TaskCondition == Condition.Done)
            {
                return str + "done";
            }
            else
            {
                return str + "not completed";
            }
        }
    }
}