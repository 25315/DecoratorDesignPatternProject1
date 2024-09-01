using NUnit.Framework;

namespace DecoratorDesignPattern.Tests
{
    [TestFixture]
    public class CarDecoratorTests
    {
        [Test]
        public void HyundaiCar_ShouldReturnBaseCostAndDescription()
        {
            // Arrange
            ICar car = new HyundaiCar();

            // Act
            double cost = car.GetCost();
            string description = car.GetDescription();

            // Assert
            Assert.AreEqual(800000, cost);
            Assert.AreEqual("Hyundai Car", description);
        }

        [Test]
        public void DieselCarDecorator_ShouldIncreaseCostAndModifyDescription()
        {
            // Arrange
            ICar car = new HyundaiCar();
            ICar dieselCar = new DieselCarDecorator(car);

            // Act
            double cost = dieselCar.GetCost();
            string description = dieselCar.GetDescription();

            // Assert
            Assert.AreEqual(900000, cost);
            Assert.AreEqual("Hyundai Car, Diesel Engine", description);
        }

        [Test]
        public void PetrolCarDecorator_ShouldIncreaseCostAndModifyDescription()
        {
            // Arrange
            ICar car = new HyundaiCar();
            ICar petrolCar = new PetrolCarDecorator(car);

            // Act
            double cost = petrolCar.GetCost();
            string description = petrolCar.GetDescription();

            // Assert
            Assert.AreEqual(850000, cost);
            Assert.AreEqual("Hyundai Car, Petrol Engine", description);
        }

        [Test]
        public void MultipleDecorators_ShouldStackDecoratorsCorrectly()
        {
            // Arrange
            ICar car = new HyundaiCar();
            ICar dieselCar = new DieselCarDecorator(car);
            ICar petrolAndDieselCar = new PetrolCarDecorator(dieselCar);

            // Act
            double cost = petrolAndDieselCar.GetCost();
            string description = petrolAndDieselCar.GetDescription();

            // Assert
            Assert.AreEqual(950000, cost);
            Assert.AreEqual("Hyundai Car, Diesel Engine, Petrol Engine", description);
        }

        [Test]
        public void EmptyDecorator_ShouldNotAlterCostOrDescription()
        {
            // Arrange
            ICar car = new HyundaiCar();
            ICar emptyDecorator = new CarDecoratorStub(car);

            // Act
            double cost = emptyDecorator.GetCost();
            string description = emptyDecorator.GetDescription();

            // Assert
            Assert.AreEqual(800000, cost);
            Assert.AreEqual("Hyundai Car", description);
        }

        [Test]
        public void CombiningMultiplePetrolDecorators_ShouldStackCostCorrectly()
        {
            // Arrange
            ICar car = new HyundaiCar();
            ICar petrolCar1 = new PetrolCarDecorator(car);
            ICar petrolCar2 = new PetrolCarDecorator(petrolCar1);

            // Act
            double cost = petrolCar2.GetCost();
            string description = petrolCar2.GetDescription();

            // Assert
            Assert.AreEqual(900000, cost);
            Assert.AreEqual("Hyundai Car, Petrol Engine, Petrol Engine", description);
        }

        [Test]
        public void PetrolThenDiesel_ShouldCalculateCostAndDescriptionCorrectly()
        {
            // Arrange
            ICar car = new HyundaiCar();
            ICar petrolCar = new PetrolCarDecorator(car);
            ICar dieselAndPetrolCar = new DieselCarDecorator(petrolCar);

            // Act
            double cost = dieselAndPetrolCar.GetCost();
            string description = dieselAndPetrolCar.GetDescription();

            // Assert
            Assert.AreEqual(950000, cost);
            Assert.AreEqual("Hyundai Car, Petrol Engine, Diesel Engine", description);
        }

        // Stub decorator for testing purposes
        public class CarDecoratorStub : CarDecorator
        {
            public CarDecoratorStub(ICar car) : base(car)
            {
            }

            public override double GetCost()
            {
                return base.GetCost(); // No modification to cost
            }

            public override string GetDescription()
            {
                return base.GetDescription(); // No modification to description
            }
        }
    }
}
