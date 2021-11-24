﻿using Shop.ShopHttpServer.DAL;
using System;

namespace Shop.ShopModel.Models
{
    public class Showcase 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public double VolumeCount { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }
        public IUnitOfWork UnitOfWork { get; }
        
        public Showcase()
        {
            
        }

        public Showcase(string name, double volume)
        {
            Name = name;
            Volume = volume;
            TimeToCreate = DateTime.Now;
            UnitOfWork = new UnitOfWork();
        }

        public Product GetProduct(int productId) => UnitOfWork.ProductOnShowcaseRepository.GetById(productId);

        public int GetProductCount() => UnitOfWork.ProductOnShowcaseRepository.GetCount();
    }   
}
