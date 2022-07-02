namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var snake = new Snake("Gosho");

            System.Console.WriteLine(snake.Name);
        }
    }
}