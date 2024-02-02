using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EquipmentManager : IEquipmentService
    {
<<<<<<< HEAD
        private readonly IRepository<Equipment> _EquipmentRepository;
        public EquipmentManager(IRepository<Equipment> EquipmentRepository)
        {
            _EquipmentRepository = EquipmentRepository;
        }
        public void CreateEquipment(Equipment Equipment)
        {
            _EquipmentRepository.Create(Equipment);
        }

        public async Task<List<Equipment>>? GetAllEquipments() => await _EquipmentRepository.List.ToListAsync();
        public async Task<Equipment>? GetEquipmentById(int id) => await _EquipmentRepository.List.FirstOrDefaultAsync(s => s.EquipmentID == id);
        public void RemoveEquipment(Equipment Equipment)
        {
            _EquipmentRepository.Delete(Equipment);
        }
        public void UpdateEquipment(Equipment Equipment)
        {
            _EquipmentRepository.Update(Equipment);
=======
        private readonly IRepository<Equipment> _equipmentRepository;
        public EquipmentManager(IRepository<Equipment> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public void CreateEquipment(Equipment equipment)
        {
            _equipmentRepository.Create(equipment);
        }

        public async Task<List<Equipment>> GetAllEquipments() => await _equipmentRepository.List.ToListAsync();
        public async Task<Equipment> GetEquipmentById(int id) => await _equipmentRepository.List.FirstOrDefaultAsync(s => s.EquipmentID == id);
        public void RemoveEquipment(Equipment equipment)
        {
            _equipmentRepository.Delete(equipment);
        }
        public void UpdateEquipment(Equipment equipment)
        {
            _equipmentRepository.Update(equipment);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
        }
    }
}
