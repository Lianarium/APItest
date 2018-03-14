using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIrun
{
	public enum Verb
	{
		GET,
		POST,
		PUT,
		DELETE
	}

	class Program
	{
		static void Main(string[] args)
		{
			var client = new Client();
			client.EndPoint = @"http://icerow.com/";
			client.Method = Verb.GET;
			var pdata = client.PostData;
			var response = client.Request("");
		}
	}
	public class Client
	{
		public string EndPoint { get; set; }
		public Verb Method { get; set; }
		public string ContentType { get; set; }
		public string PostData { get; set; }

		public Client()
		{
			EndPoint = "";
			Method = Verb.GET;
			ContentType = "application/JSON";
			PostData = "";
		}

		public Client(string endpoint, Verb method, string postData)
		{
			EndPoint = endpoint;
			Method = method;
			ContentType = "text/json";
			PostData = postData;
		}

		public string Request()
		{
			return Request("");
		}

		public string Request(string parameters)
		{
			var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
			request.Method = Method.ToString();
			request.ContentLength = 0;
			request.ContentType = ContentType;

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				var responseValue = string.Empty;

				if (response.StatusCode != HttpStatusCode.OK)
				{
					var message = String.Format("Faile: Received HTTP {0}", response.StatusCode);
					throw new ApplicationException(message);
				}

				using (var responseStream = response.GetResponseStream())
				{
					if (responseStream != null)
						using (var reader = new StreamReader(responseStream))
						{
							responseValue = reader.ReadToEnd();
						}
				}

				Console.WriteLine(responseValue);
				return responseValue;
			}
		}

	}
}
	 
 
