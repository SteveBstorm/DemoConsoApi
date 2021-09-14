using System;

namespace ConsumeAPI
{
    class Program
    {
       

        static void Main(string[] args)
        {
            ContactRequester requester = new ContactRequester();

            ContactForm form = new ContactForm
            {
                LastName = "Console",
                FirstName = "Projet",
                Email = "consommation@api.com"
            };

            requester.Post(form);


            foreach (Contact contact in requester.GetAll())
            {
                Console.WriteLine(contact.completeName);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
