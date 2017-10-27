using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography; // Some NSA stuff right there. 

namespace DataAccessLayer
{
    public class DAL
    {
        private String ConnectionString = null;

        //CONSTRUCTOR
        public DAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["iEmergency"].ConnectionString;
        }

        public DataSet getContacts(int userID)
        {
            DataSet incidentTypeData = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString);

            string cmd = String.Format(@"SELECT * FROM [contacts] WHERE userID ='{0}'", userID);
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);// Used to execute the select command.
                adapter.Fill(incidentTypeData);// Fill the dataset  from the sql adapter.
            }
            catch (Exception ex)
            {
                throw ex;
            }




            return incidentTypeData; // Just to stop the precompiler thingy. 
        }

        public string hash(string password, byte[] saltyBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltyBytes, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(saltyBytes, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            String savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public DataSet emailContacts(int userID)
        {

            DataSet incidentTypeData = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString);

            string cmd = String.Format(@"SELECT [contacts].email, [contacts].name as ContactName, [users].name as UserName
FROM [contacts] JOIN [users]
ON ([contacts].userID = [users].Id)
 WHERE userID ='{0}'", userID);
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);// Used to execute the select command.
                adapter.Fill(incidentTypeData);// Fill the dataset  from the sql adapter.
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return incidentTypeData; // return the entire dataset.

        }

        public void updateAccount(int id, string aName, string aEmail, string aDisability)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            String sql = String.Format(@"UPDATE [users] SET name = '{0}', email = '{1}', disabilities = '{2}' WHERE Id = {3}", aName, aEmail, aDisability, id);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                // Used to execute the query to validate the entered details (email and password) and returns a corresponding row if user is valid and present in DB.
                SqlDataReader dr = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }


        }




        public int updateContactRecord(string name, string email, string mobile, string relationTo, int id)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            String sql = String.Format(@"UPDATE [contacts] SET name = '{0}', email = '{1}', mobile = '{2}', relationTo = '{3}'", name, email, mobile, relationTo);
            SqlCommand command = new SqlCommand(sql, connection);



            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return output;


       
        }

        public int addContact(int userId)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            String sql = String.Format(@"INSERT INTO [contacts]  VALUES(' ', ' ', ' ', ' ',{0})",userId);
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return output;


        }

        //Delete incident

        public int deleteincident(int id)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            String sql = String.Format(@"DELETE FROM [incident] WHERE id = {0}", id);

            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }



            return output;
        }

        //Update

        public int updateIncident(String statusValue, String description, int id)
        {


            int output = 0;

            SqlConnection connection = new SqlConnection(ConnectionString);
            String sql = String.Format(@"UPDATE [incident] SET statusValue = '{0}', description = '{1}' WHERE Id = {2}", statusValue, description, id);
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {

                connection.Open();
                output = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        public int DALsignUp(user aUser)
        {
            int output = 0;
            // Basically connect to the SQL db and stuff like that. 
            SqlConnection connection = new SqlConnection(ConnectionString);

            // SALT HASHING HERE PLZ
            Random random = new Random();
            int saltSize = random.Next(4, 8);

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            aUser.passwordHash = hash(aUser.passwordHash, salt);
            aUser.salt = Convert.ToBase64String(salt);

            String sql = String.Format(@"INSERT INTO [users] (name, email, passwordhash, salt, active) VALUES('{0}','{1}', '{2}', '{3}', '1');", aUser.name, aUser.email, aUser.passwordHash, aUser.salt);
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();
                // aUser.id = (int)command.ExecuteScalar(); // This has error

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        public int deleteAccount(int id)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            String sql = String.Format(@"DELETE FROM [contacts] WHERE Id = {0}", id);
            SqlCommand cmd = new SqlCommand(sql, connection);


            try
            {
                connection.Open();
                output = cmd.ExecuteNonQuery();

                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return output;
            
        }

        public string getCurrentNode(int aValue)
        {
            String output = string.Empty;
            SqlConnection connection = new SqlConnection(ConnectionString);

            string cmd = String.Format(@"SELECT title  FROM [nodes] WHERE Id ='{0}'", aValue);
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                output = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output; // return the entire dataset.
        }

        public DataSet getIncidentTypeData(int previousNode) //  USE AS GENERIC SQL FORMAT
        {
            DataSet incidentTypeData = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString);

            string cmd = String.Format(@"SELECT Id, title, branchEnd FROM [nodes] WHERE previousNode ='{0}'", previousNode);
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);// Used to execute the select command.
                adapter.Fill(incidentTypeData);// Fill the dataset  from the sql adapter.
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return incidentTypeData; // return the entire dataset.
        }

        public bool createIncident(incident aIncident)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            String sql = String.Format("INSERT INTO [incident]( agency, latitude, userID, statusValue, longnitude, priorityValue, locationAccuracy, description, locationDescription) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", aIncident.agency, aIncident.latitude, aIncident.user, aIncident.status, aIncident.longnitude, aIncident.priority, aIncident.locationAccuracy, aIncident.description, aIncident.locationDescription); // INSERT INTO INCDIENT DATA 
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();
                // aUser.id = (int)command.ExecuteScalar(); // This has error

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public string GetColumnValue(SqlDataReader dr, string columnName)
        {
            string columnValue = string.Empty;
            if (dr[columnName] != null && dr[columnName] != DBNull.Value)
            {
                columnValue = dr[columnName].ToString();
            }
            return columnValue;
        }

        public user SignInDAL(user aObjUser, String password)
        {

            user objUser = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            String sql = String.Format(@"SELECT * FROM [users] WHERE email='{0}' AND active = 1;", aObjUser.email);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                // Used to execute the query to validate the entered details (email and password) and returns a corresponding row if user is valid and present in DB.
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    objUser = new user();
                    if (dr.Read())
                    {
                        // Calling GetColumnValue method to handle null values and retrieve the data from dr object and assign it to objUser variables without exceptions.
                        objUser.salt = GetColumnValue(dr, "salt");
                        objUser.passwordHash = GetColumnValue(dr, "passwordHash");
                        objUser.id = Convert.ToInt32(GetColumnValue(dr, "Id"));
                        objUser.disabilities = GetColumnValue(dr, "disabilities");
                        objUser.active = Convert.ToInt32(GetColumnValue(dr, "active"));
                        objUser.name = GetColumnValue(dr, "name");
                        objUser.email = GetColumnValue(dr, "email");


                        // objUser.Active = Convert.ToInt16(GetColumnValue(dr, "Active"));
                    }

                    // Hash the salt with the inserted password here

                    byte[] saltyBytes = Convert.FromBase64String(objUser.salt); // Appropriate variable name

                    String hashValue = hash(password, saltyBytes);


                    if (objUser.passwordHash.Equals(hashValue, StringComparison.Ordinal))
                    {
                        // LOGIN PLEASE

                        return objUser;

                    }
                    else
                    {
                        // Password WONG
                        return aObjUser;
                    }

                }
                else
                {
                    // email not in there
                    return aObjUser;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataSet getAllIncidents()
        {

            DataSet incidentTypeData = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString);

            string cmd = String.Format(@"SELECT *, (latitude + ',' + longnitude) as location FROM [incident] ");
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);// Used to execute the select command.
                adapter.Fill(incidentTypeData);// Fill the dataset  from the sql adapter.
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return incidentTypeData; // return the entire dataset.
        }
    }
}