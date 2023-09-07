using Demo1;

namespace Tests
{
    public class ControllerTests
    {
        [Fact]
        public void GetNumbers_Returns_TheCorrectNumber()
        { 

            bool result = new FoodService().IsFoodHot(new Food("Test", 50, true));
            Assert.Equal(new Food("Test", 50, true).isFoodHot,result);
        }
    }
}