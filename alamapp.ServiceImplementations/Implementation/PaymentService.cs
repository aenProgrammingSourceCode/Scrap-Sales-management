using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.RepositoryInterface;
using alamapp.Model.Payments;
using alamapp.ServiceImplementations.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.ServiceImplementations.Messaging.Payments;
using alamapp.ServiceImplementations.Mapping;
using alamapp.Model;

namespace alamapp.ServiceImplementations.Implementation
{
   public class PaymentService:IPaymentService
    {
       private readonly ICompanyRepository _companyRepository;
       private readonly IPaymentRepository _paymentRepository;
       private readonly IUnitOfWork _uow;
       private readonly IGlobalUserRepository _glubalUserRepository;
       public PaymentService(IPaymentRepository paymentRepository, 
           ICompanyRepository companyRepository,
           IUnitOfWork uow,
           IGlobalUserRepository glubalUserRepository)
       {
           _companyRepository = companyRepository;
           _paymentRepository = paymentRepository;
           _glubalUserRepository=glubalUserRepository;
           _uow = uow;
       }
       public void CreatePayment(CreatePaymentRequest request)
        {
           Payment payment = new Payment();
           payment.Id = request.PaymentId;
           AddToCompany(request.CompanyToAdd, payment, request.Amount);
           _paymentRepository.Add(payment);
          _uow.Commit();
        }
        public GetAllPaymentResponse GetAllPayments()
        {
            GetAllPaymentResponse response = new GetAllPaymentResponse();
            IEnumerable<Payment> payment = _paymentRepository.FindAll();
            response.Payments = payment.ConvertToPaymentViews();

            return response;
        }
        public void ModifyPayment(ModifyPaymentRequest request)
        {
            Payment payment = _paymentRepository.FindBy(request.PaymentId);
            AddToCompany(request.CompanyToAdd, payment, request.Amount);
            _paymentRepository.Save(payment);
            _uow.Commit();
        }

        public GetPaymentResponse GetPayment(GetPaymentRequest request)
        {
            GetPaymentResponse response = new GetPaymentResponse();
            Payment payment = _paymentRepository.FindBy(request.PaymentId);
            response.Payment = payment.ConvertToPaymentView();

            return response;
        }
        private void AddToCompany(IList<int> companyToAdd, Payment payment, int amount)
        {
            Company company;
            if (companyToAdd.Count() > 0)
            {
                foreach (int companyId in companyToAdd)
                {
                    company = _companyRepository.FindBy(companyId);
                    payment.AddToPayment(company, amount);
                }
            }
        }

       
    }
}
