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

        }
    }
}
