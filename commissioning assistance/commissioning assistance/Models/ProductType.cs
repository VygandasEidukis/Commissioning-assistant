namespace commissioning_assistance.Models
{
    public class ProductType : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ProductType(string type)
        {
            Type = type;
        }

        public ProductType(){}

        public override string ToString()
        {
            return Type;
        }
    }
}
