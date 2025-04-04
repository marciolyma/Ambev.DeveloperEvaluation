
namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class CustomerCreatedEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CustomerCreatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
