namespace Demo1
{
    public record Food(string name, int temp, bool isGood)
    {
        public bool isFoodHot => temp > 10;
    }
}
