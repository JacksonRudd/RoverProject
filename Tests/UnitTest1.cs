using System.Collections.Generic;
using Business;
using NUnit.Framework;

namespace Tests
{
    //these tests should be broken up to be more specific so it is easier to find exactly what went wrong
    public class BusinessTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimpleMovement()
        {
            Simulation _simulation = new Simulation(new Coordinate(5, 5));

            var a = _simulation.AddRover(new NewRoverInput(Direction.North, new Coordinate(1, 2)));
            var directions = new List<Movement>() { Movement.Left, Movement.Move, Movement.Left, Movement.Move, Movement.Left, Movement.Move, Movement.Left, Movement.Move, Movement.Move };
            var result = _simulation.TryMoveRover(directions, a.Rover);
            Assert.AreEqual(result._finalCord , new Coordinate(1 ,3));
            Assert.AreEqual(result._rover.CurrentDirection , Direction.North);
            Assert.Pass();
        }

        [Test]
        public void SimpleMovement2()

        {
            Simulation _simulation = new Simulation(new Coordinate(5, 5));

            var a = _simulation.AddRover(new NewRoverInput(Direction.East, new Coordinate(3, 3)));
            var directions = new List<Movement>() {Movement.Move, Movement.Move, Movement.Right, Movement.Move, Movement.Move, Movement.Right, Movement.Move, Movement.Right, Movement.Right, Movement.Move };
            var result = _simulation.TryMoveRover(directions, a.Rover);
            Assert.AreEqual(result._finalCord, new Coordinate(5, 1));
            Assert.AreEqual(result._rover.CurrentDirection, Direction.East);
            Assert.Pass();
        }
        public void MovingOffGridResultsInCorrectError()
        {
            Simulation _simulation = new Simulation(new Coordinate(5, 5));

            var a = _simulation.AddRover(new NewRoverInput(Direction.North, new Coordinate(3, 3)));
            var directions = new List<Movement>() { Movement.Move, Movement.Move, Movement.Move};
            var result = _simulation.TryMoveRover(directions, a.Rover);
            Assert.AreEqual(result._finalCord, new Coordinate(3, 3));
            Assert.AreEqual(result.IsSuccess(), false);
            Assert.AreEqual(result._legalityOfMove.CantMoveBecauseOffscreen, true);
            Assert.AreEqual(result._legalityOfMove.CantMoveBecauseRoverInWay, false);
            Assert.AreEqual(result._rover.CurrentDirection, Direction.North);
            Assert.Pass();
        }


    }
}