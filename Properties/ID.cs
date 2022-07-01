namespace ConsoleApplication1.Properties
{
    public struct ID
    {
        public ID(int id, int taskId)
        {
            this.id = id;
            this.taskId = taskId;
        }

        public int getId()
        {
            return this.id;
        }

        public int getTaskId()
        {
            return this.taskId;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }
        
        private int id;
        private int taskId;
    }
}