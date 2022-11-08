using System.Reflection;
using System.Text.Json;

namespace StartData
{
	class Program
	{
		public class CONF
		{
			public Dictionary<int, string> Techs { get; set; }
			public string COMP { get; set; }
			public string COMT { get; set; }
			public string ADP { get; set; }
		}
		static void Main(string[] args)
		{
			Dictionary<int, string> TEK = new Dictionary<int, string>();
			string COMP = "COM1";
			string COMT = "COM2";
			string ADP = "73738767793";
			TEK.Add(1, "Admin");
			TEK.Add(2, "DepNet");
			TEK.Add(3, "Tech1");
			TEK.Add(4, "Tech2");
			TEK.Add(5, "Tech3");

			var CONF = new CONF
			{
				Techs = TEK,
				COMP = COMP,
				COMT = COMT,
				ADP = ADP
			};

			string jsonString = JsonSerializer.Serialize(CONF);
			File.WriteAllText(@"X:\TekNET\TekNET\TekNET\bin\Debug\Conf.TNCONF", jsonString);
		}
	}
}