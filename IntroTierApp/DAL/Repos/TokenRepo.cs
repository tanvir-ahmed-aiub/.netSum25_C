using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        UMSContext db;
        internal TokenRepo() {
            db = new UMSContext();
        }
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            var tk = (from t in db.Tokens
                      where t.Key.Equals(id)
                      select t).SingleOrDefault();
            return tk;
        }

        public Token Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}
