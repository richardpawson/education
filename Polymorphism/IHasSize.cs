﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public interface IHasSize
    {
        bool IsLargerThan(IHasSize other);
    }
}
