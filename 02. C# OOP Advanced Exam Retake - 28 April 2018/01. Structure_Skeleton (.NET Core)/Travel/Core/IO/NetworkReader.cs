namespace Travel.Core.IO
{
	using System.Net;
	using Contracts;
	public class NetworkReader : IReader
	{
		public string ReadLine()
		{
			using (var client = new WebClient())
			{
				var result = client.DownloadString("http://tekstpesme.com/tekstovi/ceca/trepni/");
				return result;
			}
		}
	}
}
