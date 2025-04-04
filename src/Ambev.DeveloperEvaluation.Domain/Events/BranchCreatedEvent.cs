namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class BranchCreatedEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public BranchCreatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
