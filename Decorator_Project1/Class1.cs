using System;

namespace DecoratorDesignPattern
{
    // Step 1: Create a Component Interface
    public interface ICar
    {
        double GetCost();
        string GetDescription();
    }

    // Step 2: Create Concrete Component
    public class HyundaiCar : ICar
    {
        public double GetCost()
        {
            return 800000;
        }

        public string GetDescription()
        {
            return "Hyundai Car";
        }
    }

    // Step 3: Create a Decorator Abstract Class
    public abstract class CarDecorator : ICar
    {
        protected ICar car;
        public CarDecorator(ICar car)
        {
            this.car = car;
        }

        public virtual double GetCost()
        {
            return car.GetCost();
        }

        public virtual string GetDescription()
        {
            return car.GetDescription();
        }
    }

    // Step 4: Create Concrete Decorators
    public class DieselCarDecorator : CarDecorator
    {
        public DieselCarDecorator(ICar car) : base(car)
        {
        }

        public override double GetCost()
        {
            return base.GetCost() + 100000;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Diesel Engine";
        }
    }

    public class PetrolCarDecorator : CarDecorator
    {
        public PetrolCarDecorator(ICar car) : base(car)
        {
        }

        public override double GetCost()
        {
            return base.GetCost() + 50000;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Petrol Engine";
        }
    }

    // Step 5: Client Code
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new HyundaiCar();
            Console.WriteLine($"Description: {car.GetDescription()}, Cost: {car.GetCost()}");

            ICar dieselCar = new DieselCarDecorator(car);
            Console.WriteLine($"Description: {dieselCar.GetDescription()}, Cost: {dieselCar.GetCost()}");

            ICar petrolCar = new PetrolCarDecorator(car);
            Console.WriteLine($"Description: {petrolCar.GetDescription()}, Cost: {petrolCar.GetCost()}");
        }
    }
}
