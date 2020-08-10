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
                Console.WriteLine($"RemoveAttendeeFromEventTransaction");
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
                Console.WriteLine($"MoveAttendeeToEventTransaction");
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
                Console.WriteLine($"AddAttendeeToEventTransaction");
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
                Console.WriteLine($"AssignCredentialToAttendeeTransaction");
            }

            public string ProcessCode()
            {
                return "ACAT";
            }
        }

        public class AttendeeProcessor {

            Dictionary<string, IAttendeeProcessor> processors = new Dictionary<string, IAttendeeProcessor>();

            public AttendeeProcessor() {
                foreach (var processor in typeof(IAttendeeProcessor).Assembly.GetTypes()) 
                {
                    var processorInstance = (IAttendeeProcessor)Activator.CreateInstance(processor);

                    if (typeof(IAttendeeProcessor).IsAssignableFrom(processor) && !processor.IsInterface) {
                        processors.Add(processorInstance.ProcessCode(), processorInstance);

                    }
                }
            } 
        }

        static void Main(string[] args)
        {

        }
    }
}
