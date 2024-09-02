# Overview
The purpose of this project is to demonstrate the implementation of the Decorator Design Pattern in C#. This pattern is a structural design pattern that allows behavior to be added to individual objects, either statically or dynamically, without affecting the behavior of other objects from the same class. It is particularly useful for adhering to the Open/Closed Principle, which states that classes should be open for extension but closed for modification.

# Core Components:
1. ICar Interface:

    Defines the core functionality for all car objects.
    Methods:
    GetCost(): Returns the cost of the car.
    GetDescription(): Returns the description of the car.
    Concrete Component (HyundaiCar):

2. Implements the ICar interface.
    Represents a basic car model (e.g., Hyundai).
    Provides base implementation for GetCost() and GetDescription().
    Abstract Decorator (CarDecorator):

3. Implements the ICar interface.
    Holds a reference to an ICar object.
    Delegates the GetCost() and GetDescription() methods to the decorated ICar object.
    Serves as the base class for all concrete decorators.
    Concrete Decorators (DieselCarDecorator, PetrolCarDecorator):

4. Inherit from CarDecorator.
    Modify or extend the functionality of the base ICar object.
    DieselCarDecorator: Adds a diesel engine to the car, increasing its cost and modifying its description.
    PetrolCarDecorator: Adds a petrol engine to the car, similarly modifying its cost and description.
