namespace TestConsoleApp.Model
{
    public abstract class PipeNetworkElement
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        public List<Pipe>? ParentsList { get; set; }


        public abstract double HeatLoss();
    }
}
