﻿using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace Holding.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        private readonly Context _context;

        public EquipmentsController(IEquipmentService equipmentService, Context? context)
        {
            _equipmentService = equipmentService;
            _context = context;

            if (!_context.Equipments.Any())
            {
                _context.Equipments.AddRange(
                    new Equipment {EquipmentName = "Lenovo Laptop" },
                    new Equipment {EquipmentName = "Mouse" },
                    new Equipment {EquipmentName = "Laptop Case" }
                    );
                _context.SaveChanges();
            }
        }



        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public async Task<ActionResult> Index()
        {

            var equipments = await _equipmentService.GetAllEquipments();
            return View(equipments);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipment equipment)
        {
            try
            {
                _equipmentService.CreateEquipment(equipment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(equipment);
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            var equipment = await _equipmentService.GetEquipmentById(id);

            if (equipment == null)
            {
                return NotFound("Lütfen geçerli bir ID giriniz");
            }
            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Equipment equipment)
        {
            if (id != equipment.EquipmentID)
            {
                return NotFound();
            }
            try
            {
                _equipmentService.UpdateEquipment(equipment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(equipment);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var equipment = await _equipmentService.GetEquipmentById(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Equipment equipment)
        {

            try
            {
                var deleteEquipment = await _equipmentService.GetEquipmentById(id);
                if (deleteEquipment == null)
                {
                    return NotFound();
                }

                _equipmentService.RemoveEquipment(deleteEquipment);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                {
                    return NotFound(ex);
                }
            }
        }
    }
}
