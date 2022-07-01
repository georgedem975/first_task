using System;

namespace ConsoleApplication1.Properties
{
    public abstract class AbstractTask
    {
        protected String name;
        protected String info;
        protected ID id;
        protected Condition _condition = Condition.NOTCOMPLETED;
        protected enum Condition
        {
            DONE,
            NOTCOMPLETED
        }
    }
}