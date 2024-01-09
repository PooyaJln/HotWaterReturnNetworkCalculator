
namespace HotWaterReturnNetworkCalculator.Model
{
    public class ReturnPoint:PipeNetworkElement
    {
        private static int idSeed = 1001;
        public List<Pipe> ParentsTree = new List<Pipe>();

        public ReturnPoint()
        {
            Id = idSeed;
            ParentsTree = new List<Pipe>();
            idSeed++;
        }
        public override double HeatLoss()
        {
            double TotalHeatLoss = 0.0;
            foreach (Pipe pipe in ParentsTree)
            {
                TotalHeatLoss += pipe.HeatLossPerMeter/pipe.Children.Count;
            }
            return TotalHeatLoss;
        }
    }
}
