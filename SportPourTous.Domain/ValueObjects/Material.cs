using System.ComponentModel.DataAnnotations.Schema;

namespace SportPourTous.Domain.ValueObjects
{
	public class Material
	{
		
		public string Name { get; }

		public decimal Cost { get; }

		public Material(string name, decimal cost)
		{
			Name = name;
			Cost = cost;
		}
	}
}
