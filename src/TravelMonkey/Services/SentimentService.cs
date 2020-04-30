using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TravelMonkey.Services
{
    public class SentimentService 
    {
        public async Task<SentimentResult> sentimentAnalysis(ITextAnalyticsClient client, string text)
        {
            var result = await client.SentimentAsync(text, "en");
            return result;
        }

        public TextAnalyticsClient authenticateClient()
        {
            ApiKeySentimentServiceClientCredentials credentials = new ApiKeySentimentServiceClientCredentials();
            TextAnalyticsClient client = new TextAnalyticsClient(credentials)
            {
                Endpoint = ApiKeys.SentimentEndpoint
            };
            return client;
        }
    }
    public class ApiKeySentimentServiceClientCredentials : ServiceClientCredentials
    {
        private readonly string apiKey;

        public ApiKeySentimentServiceClientCredentials()
        {
            this.apiKey = ApiKeys.SentimentApiKey;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            request.Headers.Add("Ocp-Apim-Subscription-Key", this.apiKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
