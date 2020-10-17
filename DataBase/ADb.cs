using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Security;

namespace DataBase
{
    public abstract class ADb : IDbs
    {
        public const string STRING_CNN = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PROJETO_AVANADE;Data Source=DESKTOP-E7ICRAI\SQLEXPRESS";
        public virtual void Salvar()
        {
            foreach (var p in this.GetType().GetProperties())
            {
                ValidationAttribute columAttribute = p.GetCustomAttribute<ValidationAttribute>();
                if (columAttribute != null && columAttribute.Presence && p.GetValue(this) == null)
                {
                    throw new Exception("Nome é obrigatório");
                }
            }

            new Db().Salvar(this);
        }

        public virtual void Alterar()
        {
            new Db().Alterar(this);
        }

        public virtual void Deletar()
        {
            new Db().Deletar(this);
        }

        public virtual List<ADb> Todos()
        {
            return new Db().Todos(this);
        }
    }
}
