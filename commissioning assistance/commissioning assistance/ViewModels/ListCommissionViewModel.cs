﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.ViewModels
{
    public class ListCommissionViewModel : Conductor<object>
    {
        public ListCommissionViewModel()
        {
            ActivateItem(new ProductViewModel());
        }
    }
}
