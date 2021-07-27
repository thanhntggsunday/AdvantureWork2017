using AdvantureWork.Common.Constant;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Model.Entities;
using System;
using System.Linq;

namespace AdvantureWork.BusinessService.ServiceImp
{
    public class EFDatabaseLogService
    {
        public DataTableViewModel<DatabaseLog> GetAllDataLogs()
        {
            DataTableViewModel<DatabaseLog> viewModel = new DataTableViewModel<DatabaseLog>();
            try
            {
                var service = new AdventureWorksDW2017Context();

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = service.DatabaseLogs.ToList().ToArray();
                viewModel.recordsTotal = service.DatabaseLogs.Count();

                // Log4NetLogger.log.Info("OK");
                service.Dispose();

                return viewModel;
            }
            catch (Exception ex)
            {                
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);

                return viewModel;
            }
        }
    }
}