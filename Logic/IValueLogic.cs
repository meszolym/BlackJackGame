﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IValueLogic
    {
        public int GetValue(Card card);
        public HandValue GetValue(Hand hand);
    }
}
