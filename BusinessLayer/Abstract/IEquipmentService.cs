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
<<<<<<< HEAD
        void CreateEquipment(Equipment Equipment);
        Task<List<Equipment>> GetAllEquipments();
        Task<Equipment> GetEquipmentById(int id);
        void UpdateEquipment(Equipment Equipment);
        void RemoveEquipment(Equipment Equipment);

=======
        void CreateEquipment(Equipment equipment);
        Task<List<Equipment>> GetAllEquipments();
        Task<Equipment> GetEquipmentById(int id);
        void UpdateEquipment(Equipment equipment);
        void RemoveEquipment(Equipment equipment);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
    }
}
