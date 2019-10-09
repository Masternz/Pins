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
        
        
        
        
        [Fact]
        //[ExpectedException(typeof(NotImplementedException))]
        public void GenerateBatch_WithCorrectCountAndPinWith_CorrectBatchZizeAndLenght()
        {
            const int width = 4;
            const int batchSize = 100;
            
            
            Pins.Lib.IPinsLibrary lib = new Pins.Lib.PinsLibrary();
            var x = lib.GenerateBatch(batchSize, width);


            Assert.True(x.Count == batchSize);
            foreach(string pin in x)
            {
                Assert.True(pin.Length == width);
            }
        
        }






    }
}
