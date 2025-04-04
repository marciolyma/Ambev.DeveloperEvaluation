
namespace Ambev.DeveloperEvaluation.Domain.Events
{
    /// <summary>
    /// Event triggered when a branch is deleted.
    /// </summary>
    public class BranchDeletedEvent
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchDeletedEvent"/> class.
        /// </summary>
        /// <param name="id"></param>
        public BranchDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
