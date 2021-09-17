using System;
using System.Net.Http;

namespace ConsumeAPI
{
    class Program
    {
       

        static void Main(string[] args)
        {

            UserRequester _requester = new UserRequester();

            User currentUser = _requester.Login("test@test.com", "test1234");

            Console.WriteLine(currentUser.Token);
            Console.WriteLine(currentUser.Email);

                foreach (User item in _requester.GetAll(currentUser.Token))
                {
                    Console.WriteLine(item.Email);
                }

            

            //string texte = "Salut tout le monde !!!";

            //texte.AfficherString();

            //ContactRequester requester = new ContactRequester();

            //ContactForm form = new ContactForm
            //{
            //    LastName = "Console",
            //    FirstName = "Projet",
            //    Email = "consommation@api.com"
            //};

            //requester.Post(form);


            //foreach (Contact contact in requester.GetAll())
            //{
            //    Console.WriteLine(contact.completeName);
            //}

            Console.WriteLine("Hello World!");
        }
    }
}
