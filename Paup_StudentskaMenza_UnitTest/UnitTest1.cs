using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paup_StudentskaMenza.Controllers;
using Paup_StudentskaMenza.Models;

namespace Paup_StudentskaMenza_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private int Zbroji(int a, int b)
        {
            return a + b;
        }
        [TestMethod]
        public void TestZbrajanje()
        {
            int x = 10;
            int y = 5;

            //Act
            int zbroj = Zbroji(x, y);

            //Assert
            Assert.AreEqual(15, zbroj);
        }
        [TestMethod]
        public void TestJelaIndexTitle()
        {
            //Arrange
            JelaController controller =
                new JelaController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Popis Jela", result.ViewBag.Title);
        }
        [TestMethod]
        public void Jela_KreiranjeBrisanje()
        {
            BazaDbContext db = new BazaDbContext();

            Jela jela = new Jela()
            {
                Id = 0,
                Naziv = "Pohano meso",
                Opis = "Pohano meso, piletina",
                Cijena = 20,
                Vege = false

            };

            db.PopisJela.Add(jela);
            db.SaveChanges();

            db.PopisJela.Remove(jela);
            int obrisano = db.SaveChanges();

            Assert.AreEqual(1, obrisano);
        }
    }
}
