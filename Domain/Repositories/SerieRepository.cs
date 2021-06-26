using Domain.Context;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories
{
    public class SerieRepository : IRepositorio<Serie>
    {
        private readonly SerieContext _context;

        public SerieRepository(SerieContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Atualiza(Serie entidade)
        {
            _context.Update(entidade);
            _context.SaveChanges();
        }

        public void Exclui(Serie entidade)
        {
            _context.Remove(entidade);
            _context.SaveChanges();
        }

        public void Insere(Serie entidade)
        {
            _context.Add(entidade);
            _context.SaveChanges();            
        }

        public List<Serie> Lista()
        {
            return _context.Series.Where(c => c.Excluido == false).ToList();
        }

        public Serie RetornaPorId(int id)
        {
            return _context.Series.Where(c=>c.Excluido==false && c.Id == id).FirstOrDefault();
        }
    }
}
