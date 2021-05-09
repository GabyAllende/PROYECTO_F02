using System;
using System.Collections.Generic;
using System.Text;
using UPB.FinalProject.Logic.Models;
using UPB.FinalProject.Data;

namespace UPB.FinalProject.Logic.Managers
{
    public class QuotationManager : IQuotationManager
    {
        private IDbContext _dbContext;
        public QuotationManager(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Quotation CreateQuotation(Quotation quo)
        {
            _dbContext.AddQuotation(DTOMappers.MapGroupLD(quo));
            return quo;
        }

        public Quotation DeleteQuotation(Quotation quo)
        {
            Data.Models.Quotation qu = _dbContext.DeleteQuotation(DTOMappers.MapGroupLD(quo));
            return DTOMappers.MapQuotationDL(qu);
        }

        public List<Quotation> GetAllQuotations()
        {
            List<Data.Models.Quotation> quo = _dbContext.GetAllQuotations();
            return DTOMappers.MapQuotations(quo);
        }

        public Quotation UpdateQuotation(Quotation quo)
        {
            Data.Models.Quotation qu = _dbContext.UpdateQuotation(DTOMappers.MapGroupLD(quo));
            return DTOMappers.MapQuotationDL(qu);
        }
    }
}
