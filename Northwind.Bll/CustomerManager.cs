﻿using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class CustomerManager<T, TDto> : GenericManager<Customer, DtoCustomer>, ICustomerService
    {
        //ICustomerRepository
        public IQueryable<DtoCustomer> GetTotalReport()
        {
            throw new NotImplementedException();
        }
    }
}
