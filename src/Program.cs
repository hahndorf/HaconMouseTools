namespace Hacon.MouseTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MouseMover movr = new MouseMover();

            movr.TryMouseRepositioning();
        }
    }
}