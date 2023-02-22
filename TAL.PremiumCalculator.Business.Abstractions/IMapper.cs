﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Business.Abstractions
{
    public interface IMapper<TEntity, TResponse>
    {
        public TResponse ToResponse(TEntity entity);
    }
}
