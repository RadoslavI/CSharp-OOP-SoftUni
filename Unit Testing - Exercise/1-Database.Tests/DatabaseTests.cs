namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 4, 17, 18, 20, 1000 })]
        [TestCase(new[] { int.MaxValue, int.MinValue })]
        [TestCase(new int[0])]
        public void Constructor_With_Valid_Data_Pass(int[] parameters)
        {
            //Arrange and Act
            Database database = new Database(parameters);

            //Assert
            Assert.AreEqual(parameters.Length, database.Count);
        }


        [TestCase(
            new[] { 1, 2 },
            new[] { 3, 4 },
            4)]
        [TestCase(
            new int[0],
            new[] { int.MaxValue, int.MinValue, 334455 },
            3)]
        [TestCase(
            new int[0],
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            16)]
        public void Add_ValidData_PositiveTest(int[] ctorParams,
            int[] paramsToAdd, int expectedCount)
        {
            //Arrange
            Database database = new Database(ctorParams);

            //Act
            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            //Assert
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(
            new[] { 10, 10 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
            1)]
        public void AddWith_InvalidData_NegativeTest(int[] ctorParams, int[] paramsToAdd, int errorParam)
        {
            //Arrange
            Database database = new Database(ctorParams);

            //Act
            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => database.Add(errorParam));
        }

        [TestCase(
           new[] { 3, 4, 5 },
           new[] { 11, 12, 13, 14, 15 },
           3,
           5)]
        [TestCase(
           new int[0],
           new[] { 11, 12, 13, 14, 15 },
           5,
           0)]
        [TestCase(
           new[] { 1 },
           new[] { 15 },
           1,
           1)]
        public void RemoveWith_ValidData_PositiveTest(int[] ctorParams,
            int[] paramsToAdd,
            int removeCount,
            int expectedCount)
        {
            //Arrange
            Database database = new Database(ctorParams);

            foreach (var item in paramsToAdd)
            {
                database.Add(item);
            }

            //Act
            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            //Assert
            Assert.AreEqual(expectedCount, database.Count);
        }


        [TestCase(
           new[] { 1 },
           1)]
        [TestCase(
           new[] { 1, 2, 3, 4, 5 },
           5)]
        [TestCase(
           new int[0],
           0)]
        public void Remove_With_ValidData_NegativeTest(int[] ctorParams, int removeCount)
        {
            //Arrange
            Database database = new Database(ctorParams);

            //Act
            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        [TestCase(
            new int[] { 10, 10, 20 },
            new int[] { 22, 33, 44 },
            2,
            new int[] { 10, 10, 20, 22 })]
        public void Fetch_With_Valid_Data_PositiveTest(int[] ctorParams, int[] paramsToAdd,
            int removeCount, int[] expectedArray)
        {
            //Arrange
            Database database = new Database(ctorParams);

            //Act
            foreach (var item in paramsToAdd)
            {
                database.Add(item);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            int[] actualData = database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedArray, actualData);
            
        }
    }
}
