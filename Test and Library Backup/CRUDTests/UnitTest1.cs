namespace CRUDTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arragne
            MyMath myMath = new MyMath();
            int additionOne = 10;
            int additionTwo = 20;
            int additionExpectedOutput = 30;

            // Act 
            int additionReturnedValue = myMath.Add(additionOne, additionTwo);

            // Assert 
            Assert.Equal(additionExpectedOutput, additionReturnedValue);
        }
    }
}