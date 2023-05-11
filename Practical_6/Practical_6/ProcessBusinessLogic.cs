
namespace Practical_6
{
    public delegate void EventHandler();
    internal class ProcessBusinessLogic
    {
        public event EventHandler ProcessCompleted;
        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            OnProcessCompleted();
        }
        protected virtual void OnProcessCompleted()
        { 
            //protected virtual method      
            //if ProcessCompleted is not null then call delegate
            ProcessCompleted?.Invoke();
        }
    }
}
