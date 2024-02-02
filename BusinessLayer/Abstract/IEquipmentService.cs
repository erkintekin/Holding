using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEquipmentService
    {
        void CreateEquipment(Equipment equipment);
        Task<List<Equipment>> GetAllEquipments();
        Task<Equipment> GetEquipmentById(int id);
        void UpdateEquipment(Equipment equipment);
        void RemoveEquipment(Equipment equipment);
    }
}
