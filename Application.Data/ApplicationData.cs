using Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Application.Data
{
    public class ApplicationData
    {
        public static List<ApplicationModel> GetApplicationData()
        {
            try
            {

                List<ApplicationModel> appModelList = new List<ApplicationModel>();

                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-O734NVQ\\SQLEXPRESS;Database=Application;Trusted_Connection=True;"))
                {

                    SqlCommand command = new SqlCommand("dbo.Application_Get", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ApplicationModel appModel = new ApplicationModel()
                                {
                                    ApplicationId = reader.GetInt32(0),
                                    Url = reader.GetString(1),
                                    PathLocal = reader.GetString(2),
                                    DebuggingMode = reader.GetBoolean(3)
                                };
                                appModelList.Add(appModel);
                            }
                        }
                        else
                        {
                            throw new ApplicationException("Dados não encontrados.");
                        }
                    }
                }

                return appModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ApplicationModel GetApplicationDataById(int id)
        {
            try
            {

                ApplicationModel appModel = new ApplicationModel();

                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-O734NVQ\\SQLEXPRESS;Database=Application;Trusted_Connection=True;"))
                {

                    SqlCommand command = new SqlCommand("dbo.Application_GetById", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = id;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                appModel.ApplicationId = reader.GetInt32(0);
                                appModel.Url = reader.GetString(1);
                                appModel.PathLocal = reader.GetString(2);
                                appModel.DebuggingMode = reader.GetBoolean(3);
                            }
                        }
                        else
                        {
                            throw new ApplicationException("Dados não encontrados através do parâmetros informados.");
                        }
                    }
                }

                return appModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveData(ApplicationModel appModel)
        {
            bool saved = false;
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-O734NVQ\\SQLEXPRESS;Database=Application;Trusted_Connection=True;"))
                {

                    SqlCommand command = new SqlCommand("dbo.Application_Save", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Url", appModel.Url);
                    command.Parameters.AddWithValue("@PathLocal", appModel.PathLocal);
                    command.Parameters.AddWithValue("@DebuggingMode", appModel.DebuggingMode);

                    command.Parameters.Add("@Saved", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        saved = Convert.ToBoolean(command.Parameters["@Saved"].Value);

                        if (!saved)
                            throw new Exception("Não foi possível salvar os dados.");
                    }
                }
                return saved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateData(ApplicationModel appModel)
        {
            bool updated = false;
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-O734NVQ\\SQLEXPRESS;Database=Application;Trusted_Connection=True;"))
                {

                    SqlCommand command = new SqlCommand("dbo.Application_Update", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationId", appModel.ApplicationId);
                    command.Parameters.AddWithValue("@Url", appModel.Url);
                    command.Parameters.AddWithValue("@PathLocal", appModel.PathLocal);
                    command.Parameters.AddWithValue("@DebuggingMode", appModel.DebuggingMode);

                    command.Parameters.Add("@Updated", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        updated = Convert.ToBoolean(command.Parameters["@Updated"].Value);

                        if (!updated)
                            throw new Exception("Não foi possível atualizar os dados.");
                    }
                }
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteData(int id)
        {
            bool deleted = false;
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-O734NVQ\\SQLEXPRESS;Database=Application;Trusted_Connection=True;"))
                {

                    SqlCommand command = new SqlCommand("dbo.Application_Delete", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationId", id);
                    command.Parameters.Add("@Deleted", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        deleted = Convert.ToBoolean(command.Parameters["@Deleted"].Value);

                        if (!deleted)
                            throw new Exception("Não foi possível deletar os dados.");
                    }
                }
                return deleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

