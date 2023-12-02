namespace HW3_Patterns
{
    public class Director
    {
        private IBuilder builder;

        public IBuilder Builder
        {
            set { builder = value; }
        }

        public void BuildMinimalHouse()
        {
            this.builder.BuildWindow();
        }

        public void BuildGorgeousHouse()
        {
            this.builder.BuildSkylights();
            this.builder.BuildGarage();
            this.builder.BuildSwimmingPool();
        }
    }
}
