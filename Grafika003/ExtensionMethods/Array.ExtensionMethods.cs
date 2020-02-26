namespace Grafika003.ExtensionMethods
{
    public static partial class ExtensionMethods
    {
        public static double Sum(this double[,] table)
        {
            double sum = 0.0;
            for(int i = 0; i < table.GetUpperBound(0); i++)
            {
                for(int j = 0; j < table.GetUpperBound(1); j++)
                {
                    sum += table[i, j];
                }
            }

            return sum;
        }
    }
}
