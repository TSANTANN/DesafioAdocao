using System;
using Core.Service;
using Infra.Context;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Model;
using System.Linq;

namespace TestUnit
{
    [TestClass]
    public class EspecieTest
    {
        EspecieService espec;
        
        [TestMethod]
        public void Addespecie()
        {
            DesafioDBContext db = new DesafioDBContext();
            Especie especieInserir = new Especie
            {
                Id = 1,
                Nome = "Cachorro"

            };

            espec.Add(especieInserir);
            var result = espec.GetAll();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(1, numberOfRecords);

        }


    }
}
