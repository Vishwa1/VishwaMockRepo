using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHGolfStore.Domain.Abstract;
using SHGolfStore.Domain.Entities;

namespace SHGolfStore.WebUI.Controllers
{
    public class ItemController : Controller
    {
        private IItemRepository repository;

        public ItemController(IItemRepository itemRepository)
        {
            this.repository = itemRepository;
        }

        public ViewResult  Index()
        {
            return View(repository.Items);
        }

        public ViewResult Admin()
        {
            return View(repository.Items);
        }

        public ActionResult Edit(int id)
        {
            Item item = repository.Items.SingleOrDefault(x => x.ItemId == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                repository.SaveItem(item);
                return RedirectToAction("Index");
            }

            else
            {
                return View(item);
            }
        }

        public ActionResult Details(int id)
        {
            Item item = repository.Items.SingleOrDefault(x => x.ItemId == id);
            return View(item);
        }

        public ActionResult Create()
        {
            return View("Edit", new Item());
        }

        public ActionResult Delete (int id)
        {
            Item i = repository.DeleteItem(id);
            if (i != null)
            {
                //Display a message
            }

            return RedirectToAction("Admin");
        }
    }
}
