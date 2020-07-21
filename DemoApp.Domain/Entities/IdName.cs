namespace DemoApp.Domain.Entities
{
    public class IdName : BaseEntity
    {
        public string Name { get; set; }
        public string Discriminator { get; private set; }
    }
}
