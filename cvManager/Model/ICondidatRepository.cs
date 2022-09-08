using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cvManager.Model
{
    public interface ICondidatRepository
    {
        
        void Add(CondidatModel condidatModel);
        void Edit(CondidatModel condidatModel);
        void Remove(int id);

        List<CondidatModel> GetByWhatever(string searchString);
        List<CondidatModel> GetById(int id);
        List<CondidatModel> GetAll();
        List<CondidatModel> GetByUsername(string name);
        List<CondidatModel> GetByLevel(string level);

        List<CondidatModel> GetByProfession(string profession);
        
        


    }
}
