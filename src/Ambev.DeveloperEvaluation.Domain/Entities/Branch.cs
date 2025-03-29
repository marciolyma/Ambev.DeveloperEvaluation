using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public BranchStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Branch()
        {
            CreatedAt = DateTime.Now;
        }

        public void Activate()
        {
            Status = BranchStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Status = BranchStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new BranchValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
