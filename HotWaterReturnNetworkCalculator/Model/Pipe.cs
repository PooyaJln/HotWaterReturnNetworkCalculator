namespace HotWaterReturnNetworkCalculator.Model
{
    public class Pipe:PipeNetworkElement
    {
        private static int idSeed = 1;
        public int Length { get; set; }
        public int DN { get; set; }
        public int ExternalDiameter { get; set; }
        public int InternalDiameter { get; set; }
        public double HeatLossPerMeter { get; set; }

        public List<ReturnPoint> Children { get; set; } = new List<ReturnPoint>();

        public Pipe()
        {
            Id = idSeed; 
            HeatLossPerMeter = 10.0;
            Children = new List<ReturnPoint>();
            idSeed++;
        }

        public override double HeatLoss()
        {
            return this.HeatLossPerMeter * this.Length;
        }
    }
}
