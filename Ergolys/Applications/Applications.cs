using Ergolys.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Ergolys.Applications {
    class InputFromConsole {
        public InputFromConsole() {
            Program p = new Program();
            p.InputFromConsole();
            Console.Read();
        }
    }

    class InterfaceWithAnotherObject {
        public InterfaceWithAnotherObject() {
            Service s = new Service();
            s.ServiceWriteLine();
        }
    }

    class Enums {
        public Enums() {
            int[] i = new int[] { 1, 2, 3, 4 };
            foreach (int item in i) {
                Console.WriteLine(item.ToString());
            }
            Console.Read();
        }
    }

    class ThreadPooling {
        public ThreadPooling() {

        }
    }

    class AccessModifiers {
        public AccessModifiers() {
        
        }
    }

    class SMTPOutgoing {
        //TODO: Create inputs for FROM, TO, SUBJECT, BODY -- Already setup with predefined predicates.
        public void SMTP(string from, string to, string subject, string body) {
            MailMessage mm = new MailMessage(from, to, subject, body);
            
            SmtpClient mailer = new SmtpClient() { 
                Host = "smtp.gmail.com",
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential() {
                        UserName = "klaus.andrew@gmail.com",
                        Password = "K34rt6Ba"
                    },
                Port = 587,
            };

            mailer.Send(mm);
        }
    }
}
