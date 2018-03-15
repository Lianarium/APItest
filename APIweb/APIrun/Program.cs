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
	 	
}
	 
 
