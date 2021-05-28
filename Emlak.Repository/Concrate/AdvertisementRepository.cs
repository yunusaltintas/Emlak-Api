using Emlak.Data;
using Emlak.Data.Entities;
using Emlak.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Repository.Concrate
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(EmlakDbContext Context) : base(Context)
        {
        }
    }
}
