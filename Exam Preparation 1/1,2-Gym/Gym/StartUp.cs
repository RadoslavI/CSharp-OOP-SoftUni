namespace Gym
{
    using Gym.Core;
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Equipment;
    using Gym.Models.Gyms;

    public class StartUp
    {
        public static void Main()
        {
            //BoxingGym gym = new BoxingGym("Boxing gym");
            //gym.AddAthlete(new Boxer("Joro", "dokrai", 1));
            //gym.Exercise();
            //gym.AddEquipment(new BoxingGloves());
            //System.Console.WriteLine(gym.GymInfo());

            //// Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
