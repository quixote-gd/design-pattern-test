using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class AttendeeProcessFactory
    {
        public interface IAttendeeProcessor
        {
            void Proccess();
            string ProcessCode();
        }

        internal class RemoveAttendeeFromEventTransaction : IAttendeeProcessor
        {
            public void Proccess()
            {
                Console.WriteLine($"RemoveAttendeeFromEventTransaction  {ProcessCode()}");
            }

            public string ProcessCode()
            {
                return "RAET";
            }
        }

        internal class MoveAttendeeToEventTransaction : IAttendeeProcessor
        {
            public void Proccess()
            {
                Console.WriteLine($"MoveAttendeeToEventTransaction  {ProcessCode()}");
            }

            public string ProcessCode()
            {
                return "MAET";
            }
        }

        internal class AddAttendeeToEventTransaction : IAttendeeProcessor
        {
            public void Proccess()
            {
                Console.WriteLine($"AddAttendeeToEventTransaction  {ProcessCode()}");
            }

            public string ProcessCode()
            {
                return "AAET";
            }
        }

        internal class AssignCredentialToAttendeeTransaction : IAttendeeProcessor
        {
            public void Proccess()
            {
                Console.WriteLine($"AssignCredentialToAttendeeTransaction {ProcessCode()}");
            }

            public string ProcessCode()
            {
                return "ACAT";
            }
        }

        public class AttendeeProcessor
        {

            private Dictionary<string, IAttendeeProcessor> processors = new Dictionary<string, IAttendeeProcessor>();

            public AttendeeProcessor()
            {
                foreach (var processor in typeof(IAttendeeProcessor).Assembly.GetTypes())
                {
                    if (typeof(IAttendeeProcessor).IsAssignableFrom(processor) && !processor.IsInterface)
                    {
                        var processorInstance = (IAttendeeProcessor)Activator.CreateInstance(processor);
                        processors.Add(processorInstance.ProcessCode(), processorInstance);
                    }
                }
            }

            public void ProcessAttendeeTransaction(string key)
            {
                var attendeeTransactionToProcess = this.processors?[key];
                attendeeTransactionToProcess.Proccess();
            }
        }

        static void Main(string[] args)
        {
            // Process attendee transaction based on the code that comes in.
            var attendeeProcessor = new AttendeeProcessor();

            string processCodeToExecute = "ACAT";
            attendeeProcessor.ProcessAttendeeTransaction(processCodeToExecute);

            processCodeToExecute = "AAET";
            attendeeProcessor.ProcessAttendeeTransaction(processCodeToExecute);

        }
    }
}
