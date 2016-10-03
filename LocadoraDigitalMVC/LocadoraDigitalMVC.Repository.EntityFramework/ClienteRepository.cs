using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.Repository.EntityFramework
{
    public class ClienteRepository : IClientRepository
    {
        public Cliente Get(int id)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = context.Clientes
                            .AsNoTracking()
                            .FirstOrDefault(p => p.Id == id);

                        return result;
                    }
                    catch(Exception ex)
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

        public Cliente Create(Cliente entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Clientes.Add(entity);
                        context.Entry(entity).State = EntityState.Added;
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            return entity;
        }

        public Cliente Update(Cliente entity)
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
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            return entity;
        }

        public Cliente Delete(Cliente entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Entry(entity).State = EntityState.Deleted;
                        context.Clientes.Remove(entity);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            return entity;
        }

        public IEnumerable<Cliente> GetByFilter(string nome, string cpf)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = from x in context.Clientes
                                     select x;
                        if(!String.IsNullOrEmpty(nome))
                        {
                            result = result.Where(x => x.Nome.Contains(nome));
                        }
                        if(!String.IsNullOrEmpty(cpf))
                        {
                            result = result.Where(x => x.Cpf.Contains(cpf));
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

        public IEnumerable<Cliente> GetAll()
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        return context.Clientes.AsNoTracking().ToList().OrderBy(x => x.Nome);
                    }
                    catch(Exception ex)
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
