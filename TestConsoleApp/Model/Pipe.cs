namespace TestConsoleApp.Model
{
    public class Pipe : PipeNetworkElement
    {
        private static int idSeed = 1;

        public static event Action<Pipe> PipeCreated;
        public int Length { get; set; }
        public int DN { get; set; }
        public int ExternalDiameter { get; set; }
        public int InternalDiameter { get; set; }
        public double HeatLossPerMeter { get; set; }

        public List<ReturnPoint> ChildrenList { get; set; }
        public List<int> ChildrenIdList { get; set; }

        public Pipe()
        {
            //Id = idSeed;
            HeatLossPerMeter = 10.0;
            ChildrenList = new List<ReturnPoint>();
            ChildrenIdList = new List<int>();
            ParentsList = new List<Pipe>();
            PipeCreated?.Invoke(this);
            //idSeed++;
        }

        public override double HeatLoss()
        {
            return this.HeatLossPerMeter * this.Length;
        }
    }
}
