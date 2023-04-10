namespace MangoRPG_APP.Class
{
    // 这个类用作背包调用
    public class Inventory
    {
        //
        public Guid ID { get; set; } = new Guid();

        public string Name { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }

        public int size { get; set; }

    }
}
