using System;
using System.Collections.Generic;
using System.Linq;

namespace App.BespokedBikes.Infrastructure.Network
{
    public interface IHttpClientWrapper
    {
        void Post(string address, string json);
    }
}