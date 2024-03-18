namespace TestConsoleApp.Model
{
    public class Pipe : PipeNetworkElement
    {
        private static int idSeed = 1;

        public static event Action<Pipe> PipeCreated;
        public double Length { get; set; }
        public int DN { get; set; }
        public int ExternalDiameter { get; set; }
        public int InternalDiameter { get; set; }

        private double heatLossPerMeter;

        public double HeatLossPerMeter
        {
            get { return heatLossPerMeter; }
            set { heatLossPerMeter = value; }
        }


        public List<ReturnPoint> ChildrenList { get; set; }
        public List<int> ChildrenIdList { get; set; }

        public Pipe()
        {
            //Id = idSeed;
            heatLossPerMeter = 5;
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
