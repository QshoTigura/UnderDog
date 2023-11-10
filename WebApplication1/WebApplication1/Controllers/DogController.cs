﻿using DogsApp.Infrastrucure.Data.Domain;
using DogsApp.Infrastrucuture.Data;
using WebApplication1.Models.Dog;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.FileProviders;


namespace WebApplication1.Controllers
{
    public class DogController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DogController(ApplicationDbContext context)
        {
          _context= context;
        }
        // GET: DogController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog? item = _context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDetailsViewModel dog = new DogDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dogFromDb = new Dog
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture,
                };

                _context.Dogs.Add(dogFromDb);
                _context.SaveChanges();


                return this.RedirectToAction("Success");

            }
            return this.View();
        }
        public IActionResult Success()
        {
            return this.View();
        }
        public ActionResult Index(string searchStringBreed, string searchStringName)
        {
            List<DogAllViewModel> dogs = _context.Dogs
                    .Select(dogFromDb => new DogAllViewModel
                    {
                        Id = dogFromDb.Id,
                        Name = dogFromDb.Name,
                        Age = dogFromDb.Age,
                        Breed = dogFromDb.Breed,
                        Picture = dogFromDb.Picture
                    }).ToList();
            if (!string.IsNullOrEmpty(searchStringBreed) && !string.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed) && d.Name.Contains(searchStringName)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Name.Contains(searchStringName)).ToList();
            }
            return View(dogs);
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog? item = _context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogEditViewModel dog = new DogEditViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEditViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dog = new Dog
                {
                    Id = id,
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture
                };
                _context.Dogs.Update(dog);
                _context.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return View(bindingModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog? item = _context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogEditViewModel dog = new DogEditViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Dog? item = _context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Dogs.Remove(item);
            _context.SaveChanges();
            return this.RedirectToAction("Index", "Dog");
        }
    }
}
