//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Domain;
//using logic.Utils;

//namespace logic
//{
//    public class CompaniesLogic: BaseLogic, IABM<CompaniesDto>
//    {
//        public List<CompaniesDto> GetAll()
//        {
//            try
//            {
//                var companies = context.Companies.ToList();
//                List<CompaniesDto> list = new List<CompaniesDto>();
//                foreach (Companies c in companies)
//                {
//                    list.Add(c.MapToCompaniesDto());
//                }
//                return list;
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

       
//    }
//}

