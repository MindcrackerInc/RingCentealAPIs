﻿using RingCentral.Reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Data.Repository.Interfaces
{
    public interface IInterventionCommentRepo:IgetCount
    {
        public Task<SyncStatuts> SyncInterventionComment(string interventionCommentJson);
    }
}
