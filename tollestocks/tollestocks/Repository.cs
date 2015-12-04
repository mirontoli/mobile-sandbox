using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace tollestocks
{
	public class Repository
	{
		public Repository ()
		{
		}
		public static async Task<List<Quote>> GetQuotesAsync() {
			var client = new HttpClient ();
			var response = await client.GetAsync ("http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22YHOO%22%2C%22AAPL%22)%0A%09%09&env=http%3A%2F%2Fdatatables.org%2Falltables.env&format=json");
			var jsonString = response.Content.ReadAsStringAsync ().Result;
			var rootObject =   JsonConvert.DeserializeObject<RootObject> (jsonString);
			return rootObject.query.results.quote;
		}
	}
}

