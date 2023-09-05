using Demo1;

namespace Tests
{
    public class ControllerTests
    {
        [Fact]
        public void GetNumbers_Returns_TheCorrectnumber()
        {
            var food = new Food("Test", 50, true);

            FoodService foodService = new FoodService();

            var result = foodService.IsFoodHot(food);

            Assert.Equal(food.isFoodHot,result);
        }
    }
}