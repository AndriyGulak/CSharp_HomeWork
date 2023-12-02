namespace HW3_Patterns
{
    public class House
    { 
        private List<object> parts = new List<object>();
        public void Add(string part)
        { 
            parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this.parts.Count; i++)
            {
                str += this.parts[i] + ", ";
            }

            if (string.IsNullOrEmpty(str))
                str = "Without additional parts";
            else str = str.Remove(str.Length - 2);

            return $"House parts: {str} \n";
        }
    }


}
