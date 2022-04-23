using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Dal.Abstract;
using Northwind.Entity.Base;
using Northwind.Entity.IBase;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.Bll
{
    public class GenericManager<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        //UnitOfWork
        //IServiceProvider
        //GenericRepository
        //Constructor

        #region Variables
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        #endregion

        #region Constructor
        public GenericManager(IServiceProvider service)
        {
            this.service = service;
            unitOfWork = service.GetService<IUnitOfWork>();
            repository = unitOfWork.GetRepository<T>();
        }
        #endregion

        #region Methods
        public IResponse<TDto> Add(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto verisi model(T) tipine dönüştürülüyor.
                //sebebi:dal T ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);
                // var resolvesResult = String.Join(',', model.GetType().GetProperties().Select(x => $" - {x.Name} : {x.GetValue(model) ?? ""} - "));
                var result = repository.Add(model);

                if (saveChanges)
                {
                    Save(); //kaydetme işlemi olduğundan transaction'ı commit'liyoruz.
                }
                //dönüş tipini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IResponse<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);
                if (saveChanges)
                {
                    Save();
                }
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message= $"Error:{ex.Message}",
                };
            }
        }

        public Task<IResponse<TDto>> DeleteByIdAsync(int id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Find(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse<List<TDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TDto> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }

        public IResponse<TDto> Update(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
