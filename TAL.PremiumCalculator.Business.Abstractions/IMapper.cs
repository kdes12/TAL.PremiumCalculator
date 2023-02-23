using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Business.Abstractions
{
    /// <summary>
    /// Mapper interface
    /// </summary>
    /// <typeparam name="TEntity">Data model</typeparam>
    /// <typeparam name="TResponse">Business object</typeparam>
    public interface IMapper<TEntity, TResponse>
    {
        /// <summary>
        /// Map from data model to business object
        /// </summary>
        /// <param name="entity">Data model</param>
        /// <returns>Mapped business object</returns>
        public TResponse ToResponse(TEntity entity);
    }
}
