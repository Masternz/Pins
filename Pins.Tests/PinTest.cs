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

        [Theory,
            InlineData("0123", false),
            InlineData("1357", true),
            InlineData("123", false),
            InlineData("4569", false),
            InlineData("12457", true),
            InlineData("8345", false),
            InlineData("13", true)
        ]
        public void Validate_SequentialNumbers(string pin, bool expectedResult)
        {
            Pins.Lib.IValidator validator = new Pins.Lib.ValidateSequential();
            var result = validator.Validate(pin);

            Assert.True(result == expectedResult);
        }


        
        [Fact]
        //[ExpectedException(typeof(NotImplementedException))]
        public void GenerateBatch_WithCorrectCountAndPinWith_CorrectBatchZizeAndLenght()
        {
            const int width = 4;
            const int batchSize = 1000;
            
            IValidation val = new Validation();

            IPinsLibrary lib = new PinsLibrary(val);

            lib.Validation.Add(new ValidateConsecutive());
            lib.Validation.Add(new ValidateSequential());

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

            IValidation val = new Validation();

            // Assemble
            IPinsValidation iValidation = new PinsLibrary(val);
            // Execute

            var result = iValidation.GetRandomInputSizeBasedOnPinLength(pinLength);

            // Assert

            Assert.Equal(expectedResult, result);
            // do some more stuff
        }


        [Fact]
        public void ValidateTheValidationClass()
        {
            const int expectedValue = 1;
            
            IValidation val = new Validation();

            IPinsLibrary lib = new PinsLibrary(val);

            IValidator validation = new ValidateConsecutive();
            
            // Add a validator
            lib.Validation.Add(validation);

            // get the validation object back and do a count on it.

            int validatorCount = lib.Validation.Validators.Count;
            // we should have a validator count of 1
            Assert.Equal(validatorCount, expectedValue);

        }






    }
}
