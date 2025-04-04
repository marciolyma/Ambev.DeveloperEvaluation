using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranch
{
    /// <summary>
    /// Represents the result of a branch retrieval operation.
    /// </summary>
    public class GetBranchResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the branch.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status of the branch.
        /// </summary>
        public BranchStatus Status { get; set; }
    }
}
