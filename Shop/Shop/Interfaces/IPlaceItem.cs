﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface IPlaceItem<T>
    {
        void PlaceItem(T item);

    }
}