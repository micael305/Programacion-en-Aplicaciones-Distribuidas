using FarmaciaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicamentosController : ControllerBase
    {
        // --- SIMULACIÓN DE DATOS  ---
        private static readonly List<Medicamento> _medicamentos = new List<Medicamento>
        {
            new Medicamento { Id = 1, Nombre = "Paracetamol 500mg", Laboratorio = "Generico Labs", Precio = 5.50m, Stock = 150 },
            new Medicamento { Id = 2, Nombre = "Ibuprofeno 400mg", Laboratorio = "Farmaco S.A.", Precio = 8.25m, Stock = 80 },
            new Medicamento { Id = 3, Nombre = "Amoxicilina 250mg", Laboratorio = "Antibioticos SRL", Precio = 12.00m, Stock = 45 },
            new Medicamento { Id = 4, Nombre = "Omeprazol 20mg", Laboratorio = "Digest Pharma", Precio = 7.10m, Stock = 200 },
            new Medicamento { Id = 5, Nombre = "Loratadina 10mg", Laboratorio = "Alergia Pharma", Precio = 6.00m, Stock = 100 }
        };

        // Endpoints

        [HttpGet]
        public IEnumerable<Medicamento> GetListadoCompleto()
        {
            return _medicamentos;
        }

        [HttpGet("{id:int}/precio")]
        public IActionResult GetPrecioPorId(int id)
        {
            var medicamento = _medicamentos.FirstOrDefault(m => m.Id == id);

            if (medicamento == null)
            {
                return NotFound($"Medicamento con ID {id} no encontrado.");
            }
            return Ok(new { MedicamentoId = medicamento.Id, Nombre = medicamento.Nombre, Precio = medicamento.Precio });
        }

        // GET: /Medicamentos/1
        [HttpGet("{id:int}")]
        public IActionResult GetMedicamentoPorId(int id)
        {
            var medicamento = _medicamentos.FirstOrDefault(m => m.Id == id);

            if (medicamento == null)
            {
                return NotFound(); // 404
            }

            return Ok(medicamento); // 200
        }
    }
}