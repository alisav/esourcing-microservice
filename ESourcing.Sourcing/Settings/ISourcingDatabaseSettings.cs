﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Sourcing.Settings
{
    public interface ISourcingDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
