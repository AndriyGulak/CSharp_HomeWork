namespace HW3_Patterns
{
    public class HouseBuilder : IBuilder
    {
        private House house = new House();

        public HouseBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.house = new House();
        }

        public void BuildSkylights()
        {
            this.house.Add("Skylights");
        }

        public void BuildWindow()
        {
            this.house.Add("Window");
        }

        public void BuildGarage()
        {
            this.house.Add("Garage");
        }

        public void BuildSwimmingPool()
        {
            this.house.Add("SwimmingPool");
        }
        public House GetHouse()
        {
            House result = this.house;
            this.Reset();
            return result;
        }
    }
}
