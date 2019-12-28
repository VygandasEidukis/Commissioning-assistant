namespace commissioning_assistance.Models
{
    public class ProductType
    {
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
