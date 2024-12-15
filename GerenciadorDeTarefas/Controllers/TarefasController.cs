using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly AppDbContext _context;

        // Construtor com injeção do DbContext
        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        // Listar todas as tarefas
        public async Task<IActionResult> Index()
        {
            var tarefas = await _context.Tarefas.ToListAsync();
            return View(tarefas);
        }

        // ================================
        // Métodos de Adicionar
        // ================================

        // Exibir formulário para criar uma nova tarefa (via View padrão)
        public IActionResult Create()
        {
            return View();
        }

        // Adicionar uma nova tarefa via View padrão
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        // Adicionar uma nova tarefa (AJAX)
        [HttpPost]
        public async Task<IActionResult> Adicionar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();
                return Json(new { success = true, mensagem = "Tarefa adicionada com sucesso!" });
            }
            return Json(new { success = false, mensagem = "Erro ao adicionar tarefa." });
        }

        // ================================
        // Métodos de Editar
        // ================================

        // Exibir formulário para editar uma tarefa existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();

            return View(tarefa);
        }

        // Editar uma tarefa existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Tarefas.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaExists(tarefa.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        // ================================
        // Métodos de Alterar Status
        // ================================

        // Alterar o status de uma tarefa (AJAX)
        [HttpPost]
        public async Task<IActionResult> AlterarStatus(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();

            // Alterna o status
            tarefa.Status = tarefa.Status == "Pendente" ? "Concluída" : "Pendente";

            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();

            return Json(new { success = true, mensagem = "Status atualizado!", status = tarefa.Status });
        }

        // ================================
        // Métodos de Excluir
        // ================================

        // Exibir confirmação de exclusão
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(m => m.Id == id);
            if (tarefa == null) return NotFound();

            return View(tarefa);
        }

        // Confirmar exclusão de uma tarefa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // ================================
        // Métodos Auxiliares
        // ================================

        // Verifica se uma tarefa existe
        private bool TarefaExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
