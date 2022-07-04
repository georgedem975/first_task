namespace ConsoleApplication1.Properties
{
    public struct Id
    {
        public Id(int id, int taskId)
        {
            _id = id;
            _taskId = taskId;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetTaskId()
        {
            return _taskId;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public void SetTaskId(int taskId)
        {
            _taskId = taskId;
        }
        
        private int _id;
        private int _taskId;
    }
}