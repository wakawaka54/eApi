using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;

namespace eApi.Domain.Integrations.eBay
{
    public class eBayApi
    {
        //Sandbox credits
        string endpoint = "https://api.sandbox.ebay.com/wsapi";
        string apiToken = "AgAAAA**AQAAAA**aAAAAA**E1lwVw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4GhDpWKpQ2dj6x9nY+seQ**xKkDAA**AAMAAA**oOmUkPCbTtWMC6OnRlaUv0J8rpraMkAH8D+kiKYN7BhY7YFCSt0HX6juHalUB+dzYddvFb21KedCwmxy/mB07TlGaCCvzH3H6c3PmEeo5rp66vdeNexT0s2fWeJ1M3MPHxFYgBpE1JSvgIZxlzTIiIg49rPZu+WvpKFOfGLDBHkWT45yhCYowteUHHNeX5S8QRYcEaqge5yZ68PLWKdWjbt04yRQioS5rFJT6viws9Dt0tN7sQSuw/Uc+FZRdjmagu+AKl91/3SxOSZYBQwq1yxRaKFbBaDFL8a0TxcCgyveRcmOfCQ8YIwTGEi9MQ+RMygTTYEcS1CpjfGfEDYO1BFwCfV1QpmZgXuEF9pJSzlwm65mhQsGL4o57LRF4z9bTEM8RdQNjT0bAUQJ+16JWLvhwnx8rRqnI58aIU2BwG1SNHTXbGuFRCMNIdgyeYWNAVAs294ZAgZ4ALrOlJy0oti/MPnRYexp5E5u11nOCGWeTRHajnm8FCwGhM6Wgz4SO0rBMa9cG5rvKbTCyZBLvvRkv2CYcg/Qnt+yIHQM82wYLjhoC6BFABO4//oG5NqNS1K7I8MEd4396du9fFaaz+R8M54EW0j56Lqq0PxuTydBEoPpjiPPYCcLDvLNFkho3IiTnGXtQ+J5APPr10Yi5gITLGruHZ/rBHFuZZC2ioOvFkRyUp+vJMwYVNfI34hTGdMyJTDVOlCEj48nq/C4CCtdeweJJFsjIm7eNM6pWT8SG6Zj10jaqK3beH8uZQY/";

        //string endpoint = "https://api.ebay.com/wsapi";
        //string apiToken = "AgAAAA** AQAAAA**aAAAAA** N3OHVg**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wNmYakAJGApgSdj6x9nY+seQ** ph8DAA**AAMAAA**0KV7hjwMKVArWCxs7f1AO+IQ7t26MGGrqD8a0WmzZ/n+85Igjz2vEDxI5BmHwbNWepjGqt9Sn/oOagNn+j05dbU7DOmyYaBjwOC4QGijjG8vDNBW/IMwBTXBIiU0T1Aq8K71cwfjI9EHtL16NR1Wme4TzlF+p7PbOKMQHFDzpNJXjYY7Htru83vF7R0HgAww4WxjKOLxDKluejSWu1uetN+erav/wo/xyqJIIxb/IGXLKx7IqbTyrMD9GG7ZwSZLzevq1S3egulQKRElfM9PZttyQzXsvrrctr7NDisWOB27vK3/Dj3w+3HnjVKSKnPXP635CmyMUD9kDcRo/i3bxRZNOjxJCntpEwg3EVnAV/s3HT3H53Cr6CO6SR74Lj2yoBUOW2pg/jshiKb/Td2gF5cZT536S9lQabs7gLVx90gNyVzNzLT9FiFc/7d/K9IHae/181OSyFmqIzjMr91ELAvnZRPOhJrlWjHhkc3FLHfzJbgoTsg2gXUtgv1VOWNVRLY9mOLDWMMzSzHQh0AzLcsQN4lU+/H+DAgRl0RQpo79tjm0v7aARQVNqXGh4f/oME6k6oLSqndMnpsZrpLpY6NcYgwZcx5ZRQrXeDl5QHRmRHIiB3u/+EcuzNWdvUDDQBRKaThJtfhcTLtykERigAVtn2x0hsKQNcCi6k7sqznHgaHX7d0FUwI3gvLzmZHr9g99lsZtrxs9mtmgCTNTW11s6eDbcFt5eF4391vxU+dN5tjrB49HfaMZCdjJsG5g";

        public ApiContext GetContext()
        {
            ApiContext context = new ApiContext();

            context.SoapApiServerUrl = endpoint;

            context.ApiCredential = new ApiCredential(apiToken);

            context.Site = SiteCodeType.US;

            return context;
        }
    }
}