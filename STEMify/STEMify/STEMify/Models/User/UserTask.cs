namespace STEMify.Models.User
{
    public class UserTask
    {
        public int id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public string UserId { get; set; }  
    }

}
