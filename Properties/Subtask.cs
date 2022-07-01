using System;

namespace ConsoleApplication1.Properties
{
    public class Subtask : AbstractTask
    {
        
        private static int count = 0;
        private const int TASKID = 2;
        
        public Subtask(String name, String info)
        {
            this.id.setTaskId(TASKID);
            this.id.setId(count);
            count++;
            this.info = info;
            this.name = name;
        }
        
        public void doneCondition()
        {
            this._condition = Condition.DONE;
        }

        public void notCompletedCondition()
        {
            this._condition = Condition.NOTCOMPLETED;
        }

        public String getName()
        {
            return this.name;
        }

        public String getInfo()
        {
            return this.info;
        }

        public int getCount()
        {
            return count;
        }

        public String print()
        {
            String str = "Subtask:\nname: " + this.name + "    info: " + this.info + "\nid:" + TASKID.ToString() + "." +
                   id.getId().ToString() + "\n";
            if (this._condition == Condition.DONE)
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