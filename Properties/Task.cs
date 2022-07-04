using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Properties
{
    public class Task : AbstractTask
    {
        private static int _count;
        private const int Taskid = 1;

        private DateTime _date;
        private readonly bool _haveDate;

        private readonly List<Subtask> _subtasks = new List<Subtask>();

        public Task(string name, string info)
        {
            Id.SetTaskId(Taskid);
            Id.SetId(_count);
            _count++;
            Info = info;
            Name = name;
        }

        public Task(string name, string info, int day, int month, int year)
        {
            Id.SetTaskId(Taskid);
            Id.SetId(_count);
            _count++;
            Info = info;
            Name = name;
            _date = new DateTime(year, month, day);
            _haveDate = true;
        }

        public bool ConditionIsDone()
        {
            if (TaskCondition == Condition.Done)
            {
                return true;
            }

            return false;
        }

        public bool IsToday(int day, int month, int year)
        {
            if (!_haveDate)
            {
                return false;
            }

            return _date.Day == day && _date.Month == month && _date.Year == year;
        }

        public void DoneCondition()
        {
            TaskCondition = Condition.Done;
        }

        public Id GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetInfo()
        {
            return Info;
        }

        public string Information()
        {
            var str = "Task:\nname: " + this.Name + "    info: " + this.Info;
            var identification = "\nid: " + this.Id.GetTaskId().ToString() + "." + this.Id.GetId().ToString();
            const string completed = "\ncompleted";
            const string notCompleted = "\nnot completed";
            if (_haveDate)
            {
                if (ConditionIsDone())
                {
                    return str + identification + completed + "\n" + this._date.GetDate();
                }
                return str + identification + notCompleted + "\n" + this._date.GetDate();
            }
            if (this.ConditionIsDone())
            {
                return str + identification + completed + "\ndate: none";
            }
            return str + identification + notCompleted + "\ndate: none";
        }

        public void AddSubtask(Subtask temp)
        {
            _subtasks.Add(temp);
        }

        public int GetCountSubtask()
        {
            return _subtasks.Count;
        }

        public Subtask GetSubtask(int index)
        {
            return _subtasks[index];
        }
        
    }
}