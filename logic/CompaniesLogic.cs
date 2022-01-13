using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic
{
    public class CompaniesLogic : BaseLogic, IABM<CompaniesDto>
    {
       
        public List<CompaniesDto> GetAll()
        {
            try
            {
                var companies = context.Companies.ToList();
                List<CompaniesDto> list = new List<CompaniesDto>();
                foreach (Companies c in companies)
                {
                    list.Add(c.MapToCompaniesDto());
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CompaniesDto GetById(int id)
        {
            try
            {
                var company = context.Companies.Single(x => x.id == id );
                return company.MapToCompaniesDto();
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void Insert(CompaniesDto companyDto)
        {
            try
            {
                var validar = new CompaniesValidator();
                validar.ValidateAndThrow(companyDto);
                Companies company = companyDto.MapToCompanies();
                context.Companies.Add(company);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, CompaniesDto companyDto)
        {
            try
            {
                var validar = new CompaniesValidator();
                validar.ValidateAndThrow(companyDto);
                Companies c = context.Companies.Single(x => x.id == id);
                c=companyDto.MapToCompanies(c);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, string state)
        {
            throw new NotImplementedException();
        }
    }
}
