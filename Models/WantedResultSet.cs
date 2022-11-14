using System;
namespace WitnessReportsApi.Models
{
	public class WantedResultSet
	{
		public int? Total { get; set; }
		public int? Page { get; set; }
		public IEnumerable<WantedPerson>? Items { get; set; }
	}
}

