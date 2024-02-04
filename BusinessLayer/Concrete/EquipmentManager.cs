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
        }
    }
}
