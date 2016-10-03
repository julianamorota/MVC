using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.Repository.EntityFramework
{
    public class GeneroRepository : IGeneroRepository
    {
        public Genero Get(int id)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = context.Generos
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

        public Genero Create(Genero entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Generos.Add(entity);
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

        public Genero Update(Genero entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
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

        public Genero Delete(Genero entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Entry(entity).State = EntityState.Deleted;
                        context.Generos.Remove(entity);
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

        public IEnumerable<Genero> GetByFilter(string descricao)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = from x in context.Generos
                                     select x;
                        if (!String.IsNullOrEmpty(descricao))
                        {
                            result = result.Where(x => x.Descricao.Contains(descricao));
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
        public IEnumerable<Genero> GetAll()
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        return context.Generos.AsNoTracking().ToList().OrderBy(x => x.Descricao);
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
