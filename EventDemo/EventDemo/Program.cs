namespace EventDemo
{
    internal class EventClass
    {
        //! Creating a delegate
        public delegate void MyDelegate();

        //! Creating an Event
        public event MyDelegate? MyEvent;
       
        //! Method which raise event
        public void RaiseMyEvent()
        {
            Console.WriteLine("Loading ....");
            Thread.Sleep(2000);
            //! Raise a Event
            //if (MyEvent != null ) { MyEvent(); }
            MyEvent?.Invoke();
            
        }
    }
    internal class Class1
    {
        public static void Main(string[] args)
        {
            EventClass ec = new EventClass();
            //! Subscribe Event-1
            ec.MyEvent += Class1.OnMyEventRaised1;
            //! Subscribe Event-2
            ec.MyEvent += Class2.OnMyEventRaised2;
            //! Calling EventRaise Method
            ec.RaiseMyEvent();
        }
        public static void OnMyEventRaised1()
        {
            Console.WriteLine("First Event Raised");
        }
    }
    internal class Class2
    {
        public static void OnMyEventRaised2()
        {
            Console.WriteLine("Second Event Raised");
        }
    }

}