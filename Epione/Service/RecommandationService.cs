using Data;
using Data.Infrastructure;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RecommandationService : Service<recommandation>, IRecommandationService
    {

        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uof = new UnitOfWork(dbFactory);

        public RecommandationService(): base(uof)
        {



        }


        public void SupprimerRecommandation(int recommandation)
        {

            // dbFactory.DataContext.Database.ExecuteSqlCommand("delete from recommandation");


            dbFactory.DataContext.Database.ExecuteSqlCommand("delete from recommandation_user where Recommandation_id=" + recommandation);
            dbFactory.DataContext.Database.ExecuteSqlCommand("delete from recommandation where id="+recommandation);
           






        }


    }
}
