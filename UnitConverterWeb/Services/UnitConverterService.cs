namespace UnitConverterWeb.Services
{
	public class UnitConverterService
	{
		public double ConvertLength(double length, string originalUnit, string resultUnit)
		{
			double result = 0;
			if (originalUnit == "feets" && resultUnit == "meters")
			{
				result = length * 0.3048;
			}
			else if (originalUnit == "meters" && resultUnit == "feets")
			{
				result = length / 0.3048;
			}
			return result;
		}
		public double ConvertWeight(double weight, string originalUnit, string resultUnit)
		{
			double result = 0;
			if (originalUnit == "pounds" && resultUnit == "kilograms")
			{
				result = weight * 0.453592;
			}
			else if (originalUnit == "kilograms" && resultUnit == "pounds")
			{
				result = weight / 0.453592;
			}
			return result;
		}
		public float ConvertTemperature(float temperature, string originalUnit, string resultUnit)
		{
			float result = 0;
			if (originalUnit == "celsius" && resultUnit == "fahrenheit")
			{
				result = (temperature * 9 / 5) + 32;
			}
			else if (originalUnit == "fahrenheit" && resultUnit == "celsius")
			{
				result = (temperature - 32) * 5 / 9;
			}
			return result;
		}
	}
}
