namespace WitnessReportsApi.Models
{
	public class WitnessReport
	{
		public string Name { get; set; }
		public string Phone { get; set; }
		public bool Valid { get; set; }
		public string Country { get; set; }

        public override string ToString()
        {
			return $"Name: {Name}, Phone: {Phone}, Valid: {Valid}, Country: {Country}";
        }
    }
}

