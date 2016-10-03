using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.Repository.EntityFramework
{
    public class LocacaoRepository : ILocacaoRepository
    {
        public Locacao Get(int id)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = context.Locacoes.Where(x => x.Devolvido == false).Include(c => c.Cliente).Include(f => f.Filme)
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

        public Locacao Create(Locacao entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int filmeId = entity.FilmeId;
                        var filme = (from f in context.Filmes
                                    where f.Id == filmeId
                                    select f).FirstOrDefault();

                        filme.Status = false;
                        context.SaveChanges();

                        entity.Devolvido = false;
                        context.Locacoes.Add(entity);
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

        public Locacao Update(Locacao entity)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int filmeId = entity.FilmeId;
                        var filme = (from f in context.Filmes
                                     where f.Id == filmeId
                                     select f).FirstOrDefault();

                        filme.Status = false;
                        entity.Devolvido = false;
                        context.SaveChanges();
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

        public Locacao Devolucao(Locacao locacao)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Devolucao devolucao = new Devolucao();

                        //muda para devolvido na locação
                        locacao.Devolvido = true;
                        context.Entry(locacao).State = EntityState.Modified;
                        

                        //inserir na devolução
                        devolucao.LocacaoId = locacao.Id;
                        devolucao.dtDev = DateTime.Now.Date;

                        //multa
                        DateTime dataHoje = DateTime.Now.Date;
                        DateTime dataPrevista = Convert.ToDateTime(locacao.dtDevolucao.ToString("dd/MM/yyyy"));
                        if (dataPrevista < dataHoje)
                        {
                            TimeSpan data = DateTime.Now - Convert.ToDateTime(locacao.dtDevolucao);

                            int totalDias = data.Days;

                            devolucao.Multa = Convert.ToString(totalDias) + " dias";
                        }
                        else
                        {
                            devolucao.Multa = "Não";
                        }
                        //multa

                        context.Devolucoes.Add(devolucao);
                        context.Entry(devolucao).State = EntityState.Added;
                        

                        //inserido

                        //trocar status do filme (para disponível)
                        int filmeId = locacao.FilmeId;
                        var filme = (from f in context.Filmes
                                     where f.Id == filmeId
                                     select f).FirstOrDefault();
                        filme.Status = true;
                        context.SaveChanges();
                        //salva


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            return locacao;
        }

        public IEnumerable<Locacao> GetByFilter(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao)
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var result = context.Locacoes.Where(x => x.Devolvido == false).Include(c => c.Cliente).Include(f => f.Filme);

                        if (!String.IsNullOrEmpty(nomeCliente))
                        {
                            result = result.Where(x => x.Cliente.Nome.Contains(nomeCliente));
                        }
                        if (!String.IsNullOrEmpty(nomeFilme))
                        {
                            result = result.Where(x => x.Filme.Nome.Contains(nomeFilme));
                        }
                        if (dtLocacao.HasValue)
                        {
                            
                        }
                        if (dtDevolucao.HasValue)
                        {
                            DateTime dataDev = Convert.ToDateTime(dtDevolucao);
                            dataDev.ToString("dd/MM/yyyy");
                            result = result.Where(x => x.dtDevolucao.Equals(dataDev));
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

        public IEnumerable<Locacao> GetAll()
        {
            using (LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext())
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var Locacoes = context.Locacoes.Where(x => x.Devolvido == false).Include(c => c.Cliente).Include(f => f.Filme);

                        return Locacoes.ToList();
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
