using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Properties
{
    public class Task : AbstractTask
    {
        private static int count = 0;
        private const int TASKID = 1;

        private Date _date;
        private bool haveDate = false;

        private List<Subtask> _subtasks = new List<Subtask>();

        public Task(String name, String info)
        {
            this.id.setTaskId(TASKID);
            this.id.setId(count);
            count++;
            this.info = info;
            this.name = name;
        }

        public Task(String name, String info, int day, int month, int year)
        {
            this.id.setTaskId(TASKID);
            this.id.setId(count);
            count++;
            this.info = info;
            this.name = name;
            this._date = new Date(day, month, year);
            this.haveDate = true;
        }

        public bool conditionIsDone()
        {
            if (this._condition == Condition.DONE)
            {
                return true;
            }

            return false;
        }

        public bool isToday(int day, int month, int year)
        {
            if (!haveDate)
            {
                return false;
            }

            if (this._date.getDay() == day && this._date.getMonth() == month && this._date.getYear() == year)
            {
                return true;
            }

            return false;
        }

        public void doneCondition()
        {
            this._condition = Condition.DONE;
        }

        public void notCompletedCondition()
        {
            this._condition = Condition.NOTCOMPLETED;
        }

        public ID GetId()
        {
            return this.id;
        }

        public String getName()
        {
            return this.name;
        }

        public String getInfo()
        {
            return this.info;
        }

        public String information()
        {
            String str = "Task:\nname: " + this.name + "    info: " + this.info;
            String identificator = "\nid: " + this.id.getTaskId().ToString() + "." + this.id.getId().ToString();
            String completed = "\ncompleted";
            String notCompleted = "\nnot completed";
            if (haveDate)
            {
                if (this.conditionIsDone())
                {
                    return str + identificator + completed + "\n" + this._date.getDate();
                }
                else
                {
                    return str + identificator + notCompleted + "\n" + this._date.getDate();
                }
            }
            else
            {
                if (this.conditionIsDone())
                {
                    return str + identificator + completed + "\ndate: none";
                }
                else
                {
                    return str + identificator + notCompleted + "\ndate: none";
                }
            }
        }

        public void addSubtask(Subtask temp)
        {
            this._subtasks.Add(temp);
        }

        public int getCountSubtask()
        {
            return this._subtasks.Count;
        }

        public Subtask GetSubtask(int index)
        {
            return this._subtasks[index];
        }
        
    }
}