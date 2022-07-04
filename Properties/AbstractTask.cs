namespace ConsoleApplication1.Properties
{
    public class AbstractTask
    {
        protected string Name;
        protected string Info;
        protected Id Id;
        protected Condition TaskCondition = Condition.Notcompleted;
        protected enum Condition
        {
            Done,
            Notcompleted
        }
    }
}