using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CarController : Controller
    {
        public IActionResult List()
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }
            ViewBag.cars = Car.getList();
            return View();
        }

        public IActionResult Delete(int id)
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }
            Car.Delete(id);
            return RedirectToAction("List", "Car");
        }

        public IActionResult CalcPrice()
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }
            return View();
        }

        public IActionResult CalcPriceResult(int price)
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }
            ViewBag.Price = price;
            return View();
        }

        [HttpPost]
        public IActionResult CalcPrice(CarForm carForm)
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }

            if (ModelState.IsValid)
            {
                //string login = HttpContext.Session.GetString("Email");
                Car car = new Car()
                {
                    Name = carForm.Name,
                    Type = carForm.Type,
                    Consumption = carForm.Consumption,
                    Fuel = carForm.Fuel,
                    IsOnMarket = false,

                    Tachometer = carForm.Tachometer,
                    YearOfManufacture = carForm.YearOfManufacture,
                    user = Lib.DomainLayer.User.GetByEmail(login)
                };
                car.Price = car.calcCarPrice();
                ViewData["Message"] = "Hodnota auta: " + car.Price.ToString() + " Kč";
                //return RedirectToAction("CalcPrice", "Car");
            }

            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }
            AuctionForm form = new AuctionForm();
           
            Car car = Car.getCarByID(id);
            form.id = car.ID;
            ViewBag.car = car;
            ViewBag.hasCarAuction = car.hasCarAuction();
            return View(form);
        }

        public IActionResult Add()
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Detail(AuctionForm form)
        {
            if (ModelState.IsValid)
            {
                Auction auction = Auction.GetByCarID(form.id);
                string login = HttpContext.Session.GetString("Email");
                User user = Lib.DomainLayer.User.GetByEmail(login);
                auction.increaseBid(user, form.bid);
           
            }
            return RedirectToAction("Detail", "Car", form.id);
        }

        public IActionResult Update(int id)
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }
            Car car = Car.getCarByID(id);
            CarForm carForm = new CarForm();
            carForm.ID = car.ID;
            carForm.Name = car.Name;
            carForm.Type = car.Type;
            carForm.Consumption = car.Consumption;
            carForm.Fuel = car.Fuel;
            carForm.Price = car.Price;
            carForm.Tachometer = car.Tachometer;
            carForm.YearOfManufacture = car.YearOfManufacture;


            return View(carForm);
        }

        [HttpPost]
        public IActionResult Update(CarForm carForm)
        {
            if (ModelState.IsValid)
            {
                string login = HttpContext.Session.GetString("Email");
                Car car = Car.getCarByID(carForm.ID);

                car.Name = carForm.Name;
                car.Type = carForm.Type;
                car.Consumption = carForm.Consumption;
                car.Fuel = carForm.Fuel;
                car.Price = carForm.Price;
                car.Tachometer = carForm.Tachometer;
                car.YearOfManufacture = carForm.YearOfManufacture;

                car.Update();
                return RedirectToAction("Index", "Home");
            }


            return View();
        }

        [HttpPost]
        public IActionResult Add(CarForm carForm)
        {      
            if (ModelState.IsValid)
            {
                string login = HttpContext.Session.GetString("Email");
                Car car = new Car()
                {
                    Name = carForm.Name,
                    Type = carForm.Type,
                    Consumption = carForm.Consumption,
                    Fuel = carForm.Fuel,
                    IsOnMarket = true,
                    Price = carForm.Price,
                    Tachometer = carForm.Tachometer,
                    YearOfManufacture = carForm.YearOfManufacture,
                    user = Lib.DomainLayer.User.GetByEmail(login)
                };
                car.Insert();
                return RedirectToAction("Index", "Home");
            }

            
            return View();
        }

    }
}