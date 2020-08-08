using AutofacHackService;
using AutofacHackService.Interfaces;

namespace AutofacHacks
{
    //it will have business logic
    //we are creating this class because we cannot inject container config in static
    //Main class constructor and then create business logic with injecting interfaces 
    public class StartApplication : IStartApplication
    {
        IBusinessLogic _businessLogic;

        public StartApplication(IBusinessLogic businessLogic)
        {
            this._businessLogic = businessLogic;
        }

        public void Run()
        {
            _businessLogic.Check();
        }
    }
}
