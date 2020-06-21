namespace WireMockPOC
{
    using System;
    using System.Collections.Generic;
    using WireMock.RequestBuilders;
    using WireMock.ResponseBuilders;
    using WireMock.Server;

    public class WireMockService : IWireMockService
    {
        private static Dictionary<string, string> data = new Dictionary<string, string>
        { 
            { "http://localhost:4090/v0/topstories.json", @"c:\temp\fbe5be1d-c3cc-402d-85c7-ea566578ba7a.json"},
            { "http://localhost:4090/v0/item/23565192.json", @"c:\temp\77e06b27-da6d-4a69-aeb2-84b4d3c409dd.json" },
            { "http://localhost:4090/v0/item/23567744.json", @"c:\temp\d5edddbc-297d-4d68-a96a-4d332a463357.json" },
            { "http://localhost:4090/v0/item/23563823.json", @"c:\temp\4ab23523-f430-4a5a-80b1-003d994db83c.json"},
            { "http://localhost:4090/v0/item/23565762.json", @"c:\temp\f3121919-0ae2-4bf2-b0ed-2677a112a557.json" },
            { "http://localhost:4090/v0/item/23565463.json", @"c:\temp\47fb234d-b9ec-4da4-ad99-1fc46864b951.json" },
            { "http://localhost:4090/v0/item/23565087.json", @"c:\temp\39d6f163-ca0c-4beb-bc93-e9ec357077f7.json" },
            { "http://localhost:4090/v0/item/23555224.json", @"c:\temp\cb1c9c7f-2206-42f7-afd3-3598b17b9e59.json" },
            { "http://localhost:4090/v0/item/23556831.json", @"c:\temp\0f71b5bd-3b69-4e1d-8a0a-ec0735f14457.json" },
            { "http://localhost:4090/v0/item/23560823.json", @"c:\temp\2336eb49-a15d-4643-ab0d-906c7af43af3.json" },
            { "http://localhost:4090/v0/item/23565105.json", @"c:\temp\c398b117-d5cf-454b-a42e-68e49a61ef6f.json" },
        };

        public void Run()
        {
            var server = WireMockServer.Start(4090);

            foreach (var item in data)
            {
                server.Given(Request.Create()
                                    .WithUrl(item.Key)
                                    .UsingGet())
                      .RespondWith(Response.Create()
                                           .WithBodyFromFile(item.Value, false)
                                           //.WithDelay(TimeSpan.FromSeconds(5))
                                           );
            }
        }
    }
}
