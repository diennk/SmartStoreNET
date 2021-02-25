using SmartStore.LMS.Services;
using SmartStore.Services;
using SmartStore.Services.Tasks;

namespace SmartStore.LMS
{
    public class MyFirstTask : ITask
    {
        private readonly ICommonServices _services;
        private readonly ILMSService _LMSService;

        public MyFirstTask(
            ICommonServices services,
            ILMSService LMSService)
        {
            _services = services;
            _LMSService = LMSService;
        }

        public void Execute(TaskExecutionContext context)
        {
            // Do something
        }
    }
}