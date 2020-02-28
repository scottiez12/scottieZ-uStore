using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uStoreMVCconvert.Models;
using System.Net.Mail;
using System.Net;

namespace uStoreMVCconvert.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }


        public ActionResult Products()
        {
            ViewBag.Title = "Products";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contact)
        {
            //check the contact object for validity
            if (ModelState.IsValid)
            {
                //create a body for the email (these are words..)

                string body = string.Format($"Name: {contact.Name}<br/>Email: {contact.Email} <br/>Subject: {contact.Subject}<br/><br/>{contact.Message}");

                //create and configure the mail message (this is the letter)
                MailMessage msg = new MailMessage("Admin@scottiez.com", //where we are sending from
                    contact.Email,//where we are sending to
                    contact.Subject, //subject of the message
                    body);

                //configure the mail message object (envelope)
                msg.IsBodyHtml = true; //body of the message is HTML
                                       //msg.cc.Add("ziggish@att.net")  sends a carbon copy
                                       //msg.Bcc.Add("ziggish@att.net") send a blind carbon copy so that no one knows that you got a CC
                msg.Priority = MailPriority.High; //we want the email to end up in their mailbox, not some other folder or something


                //create and configure the SMTP client  ... Standard Mail Transfer Protocol (mail carrier)
                SmtpClient client = new SmtpClient("mail.scottiez.com");  //mail person
                client.Credentials = new NetworkCredential("Admin@scottiez.com", "P@ssw0rd"); //like a stamp
                                                                                              //this part just attaches the username/password to the client, so we can send the email
                                                                                              //client.Port = 8889; //the original is 25, but in case that port is being blocked, you can change the port number here
                                                                                              //send the email
                using (client)
                {

                    try
                    {
                        client.Send(msg); //sending the mail message object
                    }
                    catch
                    {
                        ViewBag.ErrorMessage = "There was an error sending your message, please email admin@scottiez.com";
                        return View();
                    }

                }//end using

                //send the user to the ContactConfirmationView
                //pass the contact object with it
                return View("ContactConfirmation", contact);
            }//end if
            else
            {
                return View(); //means the model isin't valid, return to form
            }//end else




        }//end ActionResultContact()




    }
}