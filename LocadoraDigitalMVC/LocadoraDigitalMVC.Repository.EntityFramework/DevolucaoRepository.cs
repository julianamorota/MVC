using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.Repository.EntityFramework
{
    public class DevolucaoRepository : IDevolucaoRepository
    {
        public Devolucao Get(int id)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = context.Devolucoes.Include(d => d.Locacao).Include(c => c.Locacao.Cliente).Include(f => f.Locacao.Filme)
                            .AsNoTracking()
                            .FirstOrDefault(p => p.Id == id);

                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        transaction.Commit();
                    }
                }
            }
        }

        public Devolucao Create(Devolucao entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entity.dtDev = DateTime.Now;
                        context.Entry(entity).State = EntityState.Added;
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            return entity;
        }

        public IEnumerable<Devolucao> GetByFilter(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        
                        var result = context.Devolucoes.Include(d => d.Locacao).Include(c => c.Locacao.Cliente).Include(f => f.Locacao.Filme);

                        if (!String.IsNullOrEmpty(nomeCliente))
                        {
                            result = result.Where(x => x.Locacao.Cliente.Nome.Contains(nomeCliente));
                        }
                        if (!String.IsNullOrEmpty(nomeFilme))
                        {
                            result = result.Where(x => x.Locacao.Filme.Nome.Contains(nomeFilme));
                        }
                        
                        if (dtLocacao.HasValue)
                        {
                            //dtLocacao = Convert.ToDateTime(dtLocacao.ToString("dd/MM/yyyy"));
                            DateTime dataLoc = Convert.ToDateTime(dtLocacao);
                            dataLoc.ToString("dd/MM/yyyy");
                            result = result.Where(x => x.Locacao.dtLocacao.Equals(dataLoc));
                        }
                        if (dtDevolucao.HasValue)
                        {
                            //dtDevolucao = Convert.ToDateTime(dtDevolucao.ToString("dd/MM/yyyy"));
                            DateTime dataDev = Convert.ToDateTime(dtDevolucao);
                            dataDev.ToString("dd/MM/yyyy");
                            result = result.Where(x => x.dtDev.Equals(dataDev));
                        }

                        return result.ToList();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        transaction.Commit();
                    }
                }

            }
        }

        public IEnumerable<Devolucao> GetAll()
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var Devolucoes = context.Devolucoes.Include(d => d.Locacao).Include(c => c.Locacao.Cliente).Include(f => f.Locacao.Filme);
                        return Devolucoes.ToList();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        transaction.Commit();
                    }
                }
            }
        }

    }
}
