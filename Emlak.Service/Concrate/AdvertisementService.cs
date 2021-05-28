using Emlak.Data.Entities;
using Emlak.Repository;
using Emlak.Service.Abstract;
using Emlak.Service.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Service.Concrate
{
    public class AdvertisementService : BaseService<Advertisement>, IAdvertisementService
    {
        public AdvertisementService(IUnitOfWork unitOfWork, IBaseRepository<Advertisement> baseRepository) : base(unitOfWork, baseRepository)
        {
        }

        
    }
}
