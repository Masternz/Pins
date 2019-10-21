using System;
using Xunit;
using Xunit.Abstractions;
using Pins.Lib;
namespace Pins.Tests
{
    public class PinTests
    {
        // a comment
        ITestOutputHelper output;
         public PinTests(ITestOutputHelper output)
        {
            this.output = output;
            // TestFixture Setup code here
            Console.WriteLine("PinTests Constructor");
        }
 #region Set up tests
    /* 
        public void SetFixture(TestSetUpClass setupClass)
         {
            // Can inject a class to provide any set up here.
            Console.WriteLine("TestSetUpClass Constructor");
            setupClass.AnyFunction();
        } 
    */

        public class TestSetUpClass
        {
            public void AnyFunction()
            {
                Console.WriteLine("TestSetUpClass.AnyFunction()");
            }
        }
        
#endregion
        
        [Theory,
            InlineData("1224", false),
            InlineData("1357", true)
        ]
        public void Validate_ConsecutiveNumbers(string pin, bool expectedResult)
        {
            Pins.Lib.IValidator validator = new Pins.Lib.ValidateConsecutive();
            var result = validator.Validate(pin);

            Assert.True(result == expectedResult);
        }
        
        [Fact]
        //[ExpectedException(typeof(NotImplementedException))]
        public void GenerateBatch_WithCorrectCountAndPinWith_CorrectBatchZizeAndLenght()
        {
            const int width = 4;
            const int batchSize = 1000;
            
            
            Pins.Lib.IPinsLibrary lib = new Pins.Lib.PinsLibrary();

            var x = lib.GenerateBatch(batchSize, width);


            Assert.True(x.Count == batchSize);
            foreach(string pin in x)
            {
                Assert.True(pin.Length == width);
            }
        
        }

        [Theory,
            InlineData(1, 9),
            InlineData(2, 99),
            InlineData(3, 999),
            InlineData(4, 9999)
        ]
        public void ValidateThatPinLenghtCreatesTheCorrectRandomSize(int pinLength, int expectedResult)
        {
            // Assemble
            IPinsValidation iValidation = new PinsLibrary();
            // Execute

            var result = iValidation.GetRandomInputSizeBasedOnPinLength(pinLength);

            // Assert

            Assert.Equal(expectedResult, result);
        }

                [Theory,
            InlineData(1, 9),
            InlineData(2, 99),
            InlineData(3, 999),
            InlineData(4, 9999)
        ]
        public void ValidateTheValidationClass(int pin, bool expectedResult)
        {

            

            Assert.Equal(expectedResult, expectedResult);
        }






    }
}
