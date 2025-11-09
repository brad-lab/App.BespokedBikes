using System;
using System.Collections.Generic;
using System.Linq;

namespace App.BespokedBikes.Application.Interfaces
{
    public interface IInventoryService
    {
        void NotifySaleOccurred(int productId, int quantity);
    }
}
