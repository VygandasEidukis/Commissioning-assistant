using System;

namespace commissioning_assistance.Models.Commission
{
    public interface IBaseCommission
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        float Money { get; set; }
        string CurrencyType { get; set; }
        int Quantity { get; set; }
        ProductType ProductType { get; set; }
        string Description { get; set; }
        DateTime OrderDate { get; set; }
        DateTime DueDate { get; set; }
        DateTime FinishedDate { get; set; }

        bool Verify();
        void Create();
        void Update();
        void Delete();

    }
}
