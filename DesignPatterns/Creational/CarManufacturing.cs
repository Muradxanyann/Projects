/* Task 6:
Design a car manufacturing system where different factories produce ElectricCarParts 
and DieselCarParts, like engines and fuel systems. */

namespace Task6
{
    public interface IEngine
    {
        void CreateEngine();
    }

    public interface IFuelSystem
    {
        void CreateFuelSystem();
    }

    class ElectricEngine : IEngine
    {
        public void CreateEngine()
        {
            Console.WriteLine($"The Engine was created by {nameof(ElectricEngine)}.");
        }
    }

    class ElectricFuelSystem : IFuelSystem
    {
        public void CreateFuelSystem()
        {
            Console.WriteLine($"The FUel System was created by {nameof(ElectricEngine)}.");
        }
    }
    class DieselEngine : IEngine
    {
        public void CreateEngine()
        {
            Console.WriteLine($"The Engine was created by {nameof(DieselEngine)}.");
        }
    }

    class DieselFuelSystem : IFuelSystem
    {
        public void CreateFuelSystem()
        {
            Console.WriteLine($"The FUel System was created by {nameof(DieselFuelSystem)}.");
        }
    }
    interface ICarPartFactory 
    {
        IEngine CreateEngine();
        IFuelSystem CreateFuelSystem();
    }



    class ElectricCarPartsCreator : ICarPartFactory
    {
        public IEngine CreateEngine() => new ElectricEngine();
        public IFuelSystem CreateFuelSystem() => new ElectricFuelSystem();
       
    }

    class DieselCarPartsCreator : ICarPartFactory
    {
        public IEngine CreateEngine() => new DieselEngine();
        public IFuelSystem CreateFuelSystem() => new DieselFuelSystem();
        
    }


    class Factory
    {
        private readonly ICarPartFactory _carPartsCreator;
        public Factory (ICarPartFactory carPartsCreator) => _carPartsCreator = carPartsCreator;

        public void ShowCreation()
        {
            var engine = _carPartsCreator.CreateEngine();
            var fuelSystem = _carPartsCreator.CreateFuelSystem();
            engine.CreateEngine();
            fuelSystem.CreateFuelSystem();
        }
    
    }
}



