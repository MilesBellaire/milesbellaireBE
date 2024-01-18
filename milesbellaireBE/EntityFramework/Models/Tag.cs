namespace MbCore.EntityFramework.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public Experience Experience { get; set; }

        public Tag() { }

        public Tag(string name)
        {
            Name = name;
        }
    }
}
