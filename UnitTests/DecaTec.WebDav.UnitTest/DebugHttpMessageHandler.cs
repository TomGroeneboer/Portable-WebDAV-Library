﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DecaTec.WebDav.UnitTest
{
    public class DebugHttpMessageHandler : DelegatingHandler
    {
        public DebugHttpMessageHandler()
            : base()
        {

        }

        public DebugHttpMessageHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {

        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder();
            sb.Append("========");
            sb.Append(Environment.NewLine);
            sb.Append("REQUEST:");
            sb.Append(Environment.NewLine);
            sb.Append(request.ToString());           

            if (request.Content != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append("REQUEST CONTENT:");
                sb.Append(Environment.NewLine);
                sb.Append(await request.Content.ReadAsStringAsync());
            }

            sb.Append(Environment.NewLine);
            sb.Append("========");

            Debug.WriteLine(sb.ToString());
            sb.Clear();

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
