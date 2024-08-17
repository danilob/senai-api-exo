using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;
        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }
        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        //POST
        public void Cadastrar(Projeto projeto){
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }    

        public Projeto BuscarporId(int id){
            return _context.Projetos.Find(id);
        }

        //PUT
        public void Atualizar(int id, Projeto projeto){
            Projeto projetoBuscado = this.BuscarporId(id);
            if (projetoBuscado != null){
                projetoBuscado.NomeDoProjeto = projeto.NomeDoProjeto;
                projetoBuscado.Area = projeto.Area;
                projetoBuscado.Status = projeto.Status;
            };

            _context.Projetos.Update(projetoBuscado);
            _context.SaveChanges();
        }

        //DELETE
        public void Deletar(int id){
            Projeto projetoBuscado = this.BuscarporId(id);
            _context.Projetos.Remove(projetoBuscado);
            _context.SaveChanges();

        }
  
    }
}
