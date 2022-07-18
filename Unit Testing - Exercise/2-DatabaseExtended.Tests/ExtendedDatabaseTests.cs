namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCaseConstructorData")]
        public void Constructor_Should_Create_Database_Positive(Person[] people,
            int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddData")]
        public void Should_Add_Database_PositiveTest(
            Person[] ctorPeople,
            Person[] peopleAdd,
            int expectedCount)
        {
            Database database = new Database(ctorPeople);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddInvalidData")]
        public void Add_Should_ThrowException_WithInvalidData_NegativeTest(
            Person[] ctorPeople,
            Person[] peopleAdd,
            Person person
            )
        {
            Database database = new Database(ctorPeople);

            foreach (var item in peopleAdd)
            {
                database.Add(item);
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(person));
        }

        [TestCaseSource("TestCaseRemoveData")]
        public void Remove_Should_Remove_WithValidData_PositiveTest(
            Person[] peopleCtor,
            Person[] peopleAdd,
            int toRemove,
            int expectedCount
            )
        {
            Database database = new Database(peopleCtor);

            foreach (var item in peopleAdd)
            {
                database.Add(item);
            }

            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseFindDataNullOrEmpty")]
        public void FindUser_Should_ThrowException_NullOrEmptyData(
            Person[] peopleCtor,
            string username
            )
        {
            Database database = new Database(peopleCtor);


            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(username)
                );
        }

        [TestCaseSource("TestCaseFindDataNegative")]
        public void FindUser_Should_ThrowException_InvalidData(
            Person[] peopleCtor,
            string username
            )
        {
            Database database = new Database(peopleCtor);

            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername(username)
                );
        }

        [TestCaseSource("TestCaseFindDataPositive")]
        public void FindUser_Should_ReturnPerson_Positive(
            Person[] peopleCtor,
            Person personToReturn,
            string username
            )
        {
            Database database = new Database(peopleCtor);

            Assert.AreEqual(personToReturn.UserName, database.FindByUsername(username).UserName);
        }

        [TestCaseSource("TestCaseIDNegativeNum")]
        public void FindUserID_With_IDNegativeNum_Should_ThrowException(
            Person[] peopleCtor,
            long IDin
            )
        {
            Database database = new Database(peopleCtor);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => database.FindById(IDin)
                );
        }


        [TestCaseSource("TestCaseIDNegativeData")]
        public void FindUserID_ShouldThrowException_NegativeData(
            Person[] peopleCtor,
            long IDin
            )
        {
            Database database = new Database(peopleCtor);

            Assert.Throws<InvalidOperationException>(
                () => database.FindById(IDin)
                );
        }

        [TestCaseSource("TestCaseIDPositiveData")]
        public void FindUserID_ShouldReturnPerson_PositiveData(
            Person[] peopleCtor,
            Person expectedPerson,
            long IDin
            )
        {
            Database database = new Database(peopleCtor);

            Assert.AreEqual(expectedPerson.Id, database.FindById(IDin).Id);
        }

        public static IEnumerable<TestCaseData> TestCaseIDPositiveData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro")
                   },
                   new Person(3, "Kiro"),
                   3),
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Dankata"),
                       new Person(3, "Kir40")
                   },
                   new Person(1, "Ivan"),
                   1)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseIDNegativeData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro")
                   },
                   4),
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Dankata"),
                       new Person(3, "Kir40")
                   },
                    long.MaxValue)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseIDNegativeNum()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro")
                   },
                   -2),
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Dankata"),
                       new Person(3, "Kir40")
                   },
                    long.MinValue)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseFindDataPositive()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro")
                   },
                   new Person(3, "Kiro"),
                   "Kiro"),
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Dankata"),
                       new Person(3, "Kir40")
                   },
                    new Person(2, "Dankata"),
                   "Dankata")
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseFindDataNegative()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {


                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro")
                   },
                   "Topalski"),
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kir40")
                   },
                   "Dankata")
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseFindDataNullOrEmpty()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {


                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro")
                   },
                   ""),
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kir40")
                   },
                   null)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {


                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro")
                   },
                   new Person[]
                   {
                       new Person(4, "Ivansd"),
                       new Person(5, "Peshosdd"),
                       new Person(6, "Kirosdsaa")
                   },
                   3,
                   3)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAddInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro2"),
                       new Person(4, "Kiro3"),
                       new Person(5, "Kiro4"),
                       new Person(6, "Kiro5"),
                       new Person(7, "Kiro6"),
                       new Person(8, "Kiro7"),
                       new Person(9, "Kiro8"),
                       new Person(10, "Kiro8ass"),
                       new Person(11, "Kiro8dddd"),
                       new Person(12, "Kiro8dfffg"),
                       new Person(13, "Kiro8ggdf"),
                   },
                   new Person[]
                   {
                       new Person(14, "DASD"),
                       new Person(15, "SSSS"),
                       new Person(16, "Dikoff"),
                   },
                   new Person(17, "dragan")),

                new TestCaseData(
                   new Person[]
                   {
                   },
                   new Person[]
                   {
                       new Person(4, "DASD"),
                       new Person(5, "SSSS"),
                       new Person(6, "Dikoff"),
                   },
                   new Person(7, "Dikoff")
                   ),

                 new TestCaseData(
                   new Person[]
                   {
                   },
                   new Person[]
                   {
                       new Person(4, "DASD"),
                       new Person(5, "SSSS"),
                       new Person(6, "Dikoff")
                   },
                   new Person(6, "Dikoffs")
                   ),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro"),
                   },
                   new Person[]
                   {
                       new Person(4, "DASD"),
                       new Person(5, "SSSS"),
                       new Person(6, "Dikoff"),
                   },
                   6),
                new TestCaseData(
                   new Person[]
                   {
                   },
                   new Person[]
                   {
                       new Person(4, "DASD"),
                       new Person(5, "SSSS"),
                       new Person(6, "Dikoff"),
                   },
                   3)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {


                new TestCaseData(
                   new Person[]
                   {
                       new Person(1, "Ivan"),
                       new Person(2, "Pesho"),
                       new Person(3, "Kiro")

                   },
                   3),
                new TestCaseData(
                   new Person[]
                   {

                   },
                   0)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }
    }
}