﻿using System.Collections.Generic;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public interface IPodRepository
    {
        List<Pod> ReadPodList();
    }
}