﻿using AlmoxarifadoDomain.NomeDaPasta;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public GrupoRepository(xAlmoxarifadoContext pContext)
        {
            _context = pContext;
        }

        public List<Grupo> ObterTodosGrupos()
        {
            return _context.Grupos
                    .Select(g => new Grupo
                    {
                        IdGru = g.IdGru,
                        NomeGru = g.NomeGru,
                         SugestaoGru = g.SugestaoGru ?? "" 
                    })
                    .ToList();
        }

        public Grupo ObterGrupoPorId(int id)
        {
            return _context.Grupos
                   .Select(g => new Grupo
                   {
                       IdGru = g.IdGru,
                       NomeGru = g.NomeGru,
                       SugestaoGru = g.SugestaoGru ?? ""
                   })
                   .ToList().First(x => x?.IdGru == id);
        }

        public Grupo CriarGrupo(Grupo grupo)
        {
            _context.Grupos.Add(grupo);
            _context.SaveChanges();

            return grupo;
        }
    }
}
