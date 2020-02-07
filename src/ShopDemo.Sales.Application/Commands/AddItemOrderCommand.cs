using FluentValidation;
using ShopDemo.Core.Messages;
using ShopDemo.Sales.Domain;
using System;

namespace ShopDemo.Sales.Application.Commands
{
    public class AddItemOrderCommand : Command
    {
        public AddItemOrderCommand(Guid clientId, Guid productId, string name, int quantity, decimal unitValue)
        {
            ClientId = clientId;
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            UnitValue = unitValue;
        }

        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitValue { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new AddOrderItemCommand().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddOrderItemCommand : AbstractValidator<AddItemOrderCommand>
    {
        public static string IdClientErrorMsg => "Id do cliente inválido";
        public static string IdProductErrorMsg => "Id do produto inválido";
        public static string NameErrorMsg => "O nome do produto não foi informado";
        public static string QtyMaxErrorMsg => $"A quantidade máxima de um item é {Order.MAX_UNIT_ITEM}";
        public static string QtyMinErrorMsg => "A quantidade miníma de um item é 1";
        public static string ValueErrorMsg => "O valor do item precisa ser maior que 0";

        public AddOrderItemCommand()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage(IdClientErrorMsg);

            RuleFor(c => c.ProductId)
                .NotEqual(Guid.Empty)
                .WithMessage(IdProductErrorMsg);

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(NameErrorMsg);

            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage(QtyMinErrorMsg)
                .LessThanOrEqualTo(Order.MAX_UNIT_ITEM)
                .WithMessage(QtyMaxErrorMsg);

            RuleFor(c => c.UnitValue)
                .GreaterThan(0)
                .WithMessage(ValueErrorMsg);
        }
    }
}
