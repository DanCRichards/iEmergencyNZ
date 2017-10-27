using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Base
    {
      
    }
    public class user
    {
        public int id { get; set; }
        // NAME METHODS
        public String name { get; set; }
        public int active { get; set; }

        //EMAIL METHODS AND ATTRIBUTE
        public String email { get; set; }
        // PASSWORD METHODS AND ATTIRUBTE
        public String passwordHash { get; set; }
        public String salt { get; set; }
        public String disabilities { get; set; }

        public user() { }

        public user(String aEmail)
        {
            email = aEmail;
           
        }

        public user(String aName, String aEmail, String aPassword)
        {
            name = aName;
            email = aEmail;
            passwordHash = aPassword; // Current Stage not hashing. 
        }
    }
    public class nodes
    {
        public int Id { get; set; }
        public String title { get; set; }
        public int previousNode { get; set; }
        public String description { get; set; }

        public nodes(String aTitle, int aPreviousNode, String aDescription)
        {
            ///<summary>Nodes Constructor used to show the different tree path for emergency descriptions (Vague description)
            ///<para>String aTitle, int aPreviousNode, String aDescriptio</para>
            /// </summary>
            /// 
            title = aTitle;
            previousNode = aPreviousNode;
            description = aDescription;

        }

    }
    public class incident
    {
        public int Id { get; set; }
        public DateTime dateTimeStamp { get; set; }
        public String agency { get; set; }
        
        public double latitude { get; set; }
        public int user { get; set; }
        public String status { get; set; }
        public double longnitude { get; set; }
        public int priority { get; set; } // How am I going to set this? Nodes? Probably just use node tbh
        public int locationAccuracy { get; set; } // Add this into JS.
        public String description { get; set; }
        public String locationDescription { get; set; }

        public incident(String aAgencyId, double aLatitude, int aUser, String aStatus, double aLongnitude, int aPriority, int aLocationAccuracy, String aDescription, String aLocationDescription) // Make a constructor
        {
            /// <summary>Is the constructor for incident. Need to make sure that JS also gets locationAccuracy
            /// <para>int aAgencyId, double aLatitude, int aUser, String aStatus, double aLongnitude, int aPriority, int aLocationAccuracy</para>
            /// </summary>
            /// 

            dateTimeStamp = DateTime.Now; // Le works apparently.
            agency = aAgencyId;
            latitude = aLatitude;
            user = aUser;
            status = aStatus;
            longnitude = aLongnitude;
            priority = aPriority;
            locationAccuracy = aLocationAccuracy;
           
            description = aDescription;
            locationDescription = aLocationDescription;
        }
    }
    public class contacts
    {
        public int Id { get; set; }
        public String name { get; set; }
        public String mobile { get; set; }
        public String email { get; set; }
        public int parentContact { get; set; } // Foriegn Key to user
        public String relation { get; set; }

        public contacts(String aName, String aMobile, String aEmail, int aParentContact, String aRelation)
        {
            /// <summary> Contacts contructor, this class is used to email people who are related to someone in an emergnecy
            /// <para>String aName, String aMobile, String aEmail, int aparentContact, String aRealtion</para>
            /// 
            /// </summary>
            /// 
            name = aName;
            mobile = aMobile;
            email = aEmail;
            parentContact = aParentContact;
            relation = aRelation;


        }



    }
    public class agency
    {
        public int Id { get; set; }
        public String agencyName {get; set;}
        public String contactName { get; set; }
        public String contactNumber { get; set; } // Is a string because could have () + in field for area / country codes. 

        public agency(String aAgencyName, String aContactName, String aContactNumber)
        {

            ///<summary>Class to record Fire, Ambulance, Police Details
            ///<para>String aAgencyName, String aContactName, String aContactNumber</para>
            /// </summary>
            agencyName = aAgencyName;
            contactName = aContactName;
            contactNumber = aContactNumber;

        }
    }
    //Messages? - Maybe later

}
