using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.Repository.EntityFramework
{
    public class FilmeRepository : IFilmeRepository
    {
        public Filme Get(int id)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = context.Filmes.Include(f => f.Genero)
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

        public Filme Create(Filme entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entity.Status = true;
                        context.Filmes.Add(entity);
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

        public Filme Update(Filme entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entity.Status = true;
                        context.Entry(entity).State = EntityState.Modified;
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

        public Filme Delete(Filme entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entity.Status = false;
                        context.Entry(entity).State = EntityState.Deleted;
                        context.Filmes.Remove(entity);
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

        public IEnumerable<Filme> GetByFilter(string nomeFilme, string nomeGenero, string status)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = context.Filmes.Include(f => f.Genero);
                        bool statusBool;
                        
                        if (!String.IsNullOrEmpty(nomeFilme))
                        {
                            result = result.Where(x => x.Nome.Contains(nomeFilme));
                        }
                        if (!String.IsNullOrEmpty(nomeGenero))
                        {
                            result = result.Where(x => x.Genero.Descricao == nomeGenero);
                        }
                        if (!String.IsNullOrEmpty(status))
                        {
                            if (status == "disponivel")
                            {
                                statusBool = true;
                            }
                            else
                            {
                                statusBool = false;
                            }
                            result = result.Where(x => x.Status == statusBool);
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

        public IEnumerable<Filme> GetAll()
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var filmes = context.Filmes.Include(f => f.Genero);

                        return filmes.ToList();
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
