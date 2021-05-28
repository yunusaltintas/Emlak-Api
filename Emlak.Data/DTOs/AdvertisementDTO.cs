using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.DTOs
{
    public class AdvertisementDTO 
    {
        public bool IsPublish { get; set; }
        public string Explanation { get; set; }
        public string AdvertisementTitle { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public string FilePictures { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public int SquareMeters { get; set; }
        public string Room { get; set; }
        public short BuildingAge { get; set; }
        public int UserId { get; set; }
    }
}
