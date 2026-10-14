namespace CRUDTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            /// -------------------------------- From 166. xUnit Test-----------------------------------
            // Arragne
            MyMath myMath = new MyMath();
            int additionOne = 10;
            int additionTwo = 20;
            int additionExpectedOutput = 30;

            // Act 
            int additionReturnedValue = myMath.Add(additionOne, additionTwo);

            // Assert 
            // The Equal takes Expected value then the actual value i.e. the value our method will return.
            Assert.Equal(additionExpectedOutput, additionReturnedValue);
            /// -------------------------------- End of 166. xUnit Test-----------------------------------
        }
    }
}