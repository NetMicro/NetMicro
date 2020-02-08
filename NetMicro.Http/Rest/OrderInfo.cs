namespace NetMicro.Http.Rest
{
    public class OrderInfo
    {
        public OrderInfo(string field, Order order)
        {
            Field = field;
            Order = order;
        }

        public string Field { get; }
        public Order Order { get; }
    }
}