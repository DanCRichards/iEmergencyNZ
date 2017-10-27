using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using System.Net.Mail;

namespace BusinessLogicLayer
{
    public class BLL
    {


        private String systemEmail = "iEmergencyTesting@gmail.com";
        private String systemPassword = "HorseCallerYacht32"; // Go ahead and login if you want haha. It's a throw away. 
        // Also you should make your password a random collection of words like this. 

        public BLL() { }

        public string getCurrentNode(int value)
        {
            DAL objDAl = new DAL();
            return objDAl.getCurrentNode(value);

        }

        public int SignUpBLL(user objUserMaster)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.DALsignUp(objUserMaster);
            return output;
        }

        public bool signUpEmail(user objUserMaster) // Make a generic send EMAIL method and use that?
        {

            // This should actually call another function, that sends the data. 

            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(systemEmail, systemPassword);
            mail.From = new MailAddress(systemEmail);
            mail.To.Add(new MailAddress(objUserMaster.email));
            mail.Subject = "Welcome to iEmergency NZ";
            mail.Body = String.Format("Hi '{0}' and welcome to iEmergency New Zealand. '{1}' You will be able to use this website to contact Emergency Services in an emergency.", objUserMaster.name, Environment.NewLine);

           client.Send(mail);


            return true;
        }

        public int updateIncident(String statusValue, String description, int id)
        {

            DAL objDAL = new DAL();
            return objDAL.updateIncident(statusValue, description, id); // Too easy

        }


        public int deleteIncident(int id)
        {
            DAL objDAL = new DAL();
            return objDAL.deleteincident(id);
        }


        public void updateAccount(int id, string aName, string aEmail, string aDisability)
        {
            
          
      
            DAL objDAL = new DAL();
            objDAL.updateAccount(id, aName, aEmail, aDisability);
           

            
        }

        public DataSet getIncidentTypes(int node)
        {
            
            // Node is the previous node. If 1, shows all the emergnecy services
            DAL objDAL = new DAL();
            DataSet ds = objDAL.getIncidentTypeData(node);


            return ds; // Give data set to view.
        }

        public int updateContactRecord(string name, string email, string mobile, string relationTo, int id)
        {

            DAL objDAL = new DAL();
            return objDAL.updateContactRecord(name, email, mobile, relationTo, id);
            
        }

        public DataSet getAllIncidents()
        {
            DAL objDAL = new DAL();
            return objDAL.getAllIncidents();
        }

        public user signIn(user aUser, String password)
        {

            // need to pass a user into signIn DAL 

            DAL objDAL = new DAL();
            
           
            return objDAL.SignInDAL(aUser, password);
        }

        public int addContact(int userId)
        {
            DAL objDAL = new DAL();
            return objDAL.addContact(userId);
        }

        public DataSet getContactDetails(int userID)
        {
            DAL objDAL = new DAL();
            DataSet ds = objDAL.getContacts(userID);

            return ds;
        }


        public void emailContacts(int userId)
        {
            DAL objDAL = new DAL();
            DataSet ds = objDAL.emailContacts(userId);


            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {

                    String email = row[0] as String;
                    String name = row[1] as String;
                    String callerName = row[2] as String;

                    MailMessage mail = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Host = "smtp.gmail.com";
                    client.Timeout = 100000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(systemEmail, systemPassword);
                    mail.From = new MailAddress(systemEmail);
                    mail.To.Add(new MailAddress(email));
                    mail.Subject = "Emergency Declared by " + callerName;
                    mail.Body = String.Format("Hi {0} {1} {2} has contacted Emergency Services and you have been listed under his name as a person to contact in such an event.", name, Environment.NewLine, callerName);

                    client.Send(mail);


                   
                }
            }

        }


        public int deleteAccountContact(int Id)
        {

            DAL objDAL = new DAL();

            return objDAL.deleteAccount(Id);
            // Deletes Hopefully. 


        }


        public bool createIncident(incident aIncident) {
            
            DAL objDal = new DAL();
            objDal.createIncident(aIncident);
            objDal = null;  // Deletes reference and frees memory
            return false;
        }

       

    }
}
