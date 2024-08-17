using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo.WebApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoContext _context;
        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        public Usuario Login(string email, string senha){
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        //POST
        public void Cadastrar(Usuario usuario){
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }    

        public Usuario BuscarporId(int id){
            return _context.Usuarios.Find(id);
        }

        //PUT
        public void Atualizar(int id, Usuario usuario){
            Usuario usuarioBuscado = this.BuscarporId(id);
            if (usuarioBuscado != null){
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
            };

            _context.Usuarios.Update(usuarioBuscado);
            _context.SaveChanges();
        }

        //DELETE
        public void Deletar(int id){
            Usuario usuarioBuscado = this.BuscarporId(id);
            _context.Usuarios.Remove(usuarioBuscado);
            _context.SaveChanges();

        }
  
    }
}
