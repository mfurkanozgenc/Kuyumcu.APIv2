using FluentValidation;

namespace Kuyumcu.API.Application.Features.StockMovements.CreateStockMovement
{
    public sealed class CreateStockMovementCommandValidator : AbstractValidator<CreateStockMovementCommand>
    {
        public CreateStockMovementCommandValidator()
        {
            RuleFor(s => s.Price)
                   .GreaterThanOrEqualTo(0);

            RuleFor(s => s.Quantity)
                   .GreaterThan(0);

            RuleFor(s => s.TypeValue)
                   .GreaterThan(0);
        }
    }
}
