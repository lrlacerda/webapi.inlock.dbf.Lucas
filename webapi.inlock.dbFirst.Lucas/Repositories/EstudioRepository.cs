using Microsoft.EntityFrameworkCore;
using webapi.inlock.dbFirst.Lucas.Contexts;
using webapi.inlock.dbFirst.Lucas.Domains;
using webapi.inlock.dbFirst.Lucas.Interfaces;

namespace webapi.inlock.dbFirst.Lucas.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioAtualizado = ctx.Estudios.Find(id)!;
            if (estudioAtualizado != null)
            {
                estudioAtualizado.Nome = estudio.Nome;
            }
            ctx.Estudios.Update(estudioAtualizado);
            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id)!;
        }

        public void Cadastrar(Estudio estudio)
        {
            //estudio.IdEstudio = Guid.NewGuid(); esta feito no EstudioDomain mas pode deixar aqui tambem
            ctx.Estudios.Add(estudio);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;
            ctx.Estudios.Remove(estudioBuscado);
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
