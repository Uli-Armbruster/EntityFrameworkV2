using System.Linq;

using UAR.BusinessLogic.Contracts;
using UAR.Domain.AdventureWorks;
using UAR.Persistence.Contracts;

namespace UAR.BusinessLogic
{
    class BusinessLogic : IBusinessLogic
    {
        readonly IUnitOfWork _unitOfWork;

        public BusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetCustomer()
        {
            return _unitOfWork.Entities<Contact>().First().FirstName;
        }
    }
}