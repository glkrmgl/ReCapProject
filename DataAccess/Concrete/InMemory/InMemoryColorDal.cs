﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {

        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ ColorId=1, ColorName="kırmızı"},
                new Color{ ColorId=2, ColorName="turuncu"},
                new Color { ColorId = 3, ColorName = "sarı" },
                new Color { ColorId = 4, ColorName = "yeşil" },
                new Color { ColorId = 5, ColorName = "Mavi" },
                new Color { ColorId = 6, ColorName = "mor" }
            };
        }
       
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(cl => cl.ColorId == color.ColorId);
            _colors.Remove(color);
        }

        public List<Color> GetAll()
        {
            return _colors;

        }

        public List<Color> GetById(int ColorId)
        {
            return _colors.Where(cl => cl.ColorId == ColorId).ToList();

        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(cl => cl.ColorId == color.ColorId);
            colorToUpdate.ColorId = color.ColorId;
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}