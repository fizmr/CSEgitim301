using CSEgitim301_DataAccessLayer.Abstract;
using CSEgitim301_DataAccessLayer.Repositories;
using CSEgitim301_entityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEgitim301_DataAccessLayer.EntityFramework
{
    public class EFadminDal: GenericRepo<Admin>, IAdminDal
    {

    }
}
