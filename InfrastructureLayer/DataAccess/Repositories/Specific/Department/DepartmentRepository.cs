/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Department;
using ServiceLayer.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAccess.Repositories.Specific
{
  public class DepartmentRepository : BaseSpecificRepository, IDepartmentRepository
  {

    public DepartmentRepository()
    {
    }
    public DepartmentRepository(string connectionString)
    {
      _connectionString = connectionString;
    }
    public IEnumerable<IDepartmentModel> GetAll()
    {
      List<DepartmentModel> departmentModelList = new List<DepartmentModel>();
      DataAccessStatus dataAccessStatus = new DataAccessStatus();

      using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
      {
        try
        {
        string sql = "SELECT * FROM Departments";

          sqlLiteConnection.Open();

          using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
        {
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                DepartmentModel departmentModel = new DepartmentModel();
                departmentModel.DepartmentId = Int32.Parse(reader["DepartmentId"].ToString());
                departmentModel.DepartmentName = reader["DepartmentName"].ToString();
                departmentModel.DepartmentUrl = reader["DepartmentUrl"].ToString();
                departmentModel.PhoneNumber = reader["PhoneNumber"].ToString();
                departmentModel.Email = reader["Email"].ToString();
                departmentModel.CityLocation = reader["CityLocation"].ToString();
                departmentModel.StateLocation = reader["StateLocation"].ToString();
                departmentModelList.Add(departmentModel);
              }
            }
            sqlLiteConnection.Close();
          }
        }
        catch (SQLiteException e)
        {
          dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to get Department Model list from database", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

          throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
        }
        return departmentModelList;
      }
    }

    public DepartmentModel GetById(int departmentId)
    {
      DepartmentModel departmentModel = new DepartmentModel();
      DataAccessStatus dataAccessStatus = new DataAccessStatus();
      bool MatchingRecordFound = false;
      string sql = "SELECT DepartmentId, DepartmentName, DepartmentUrl, PhoneNumber, Email, CityLocation, StateLocation " +
                   "FROM Departments WHERE DepartmentId = @DepartmentId";

      using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
      {
        try
        {
          sqlLiteConnection.Open();

          using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
          {
            cmd.CommandText = sql;
            cmd.Prepare();
            cmd.Parameters.Add(new SQLiteParameter("@DepartmentId", departmentId));

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
              MatchingRecordFound = reader.HasRows;
              while (reader.Read())
              {
                
                departmentModel.DepartmentId = Int32.Parse(reader["DepartmentId"].ToString());
                departmentModel.DepartmentName = reader["DepartmentName"].ToString();
                departmentModel.DepartmentUrl = reader["DepartmentUrl"].ToString();
                departmentModel.PhoneNumber = reader["PhoneNumber"].ToString();
                departmentModel.Email = reader["Email"].ToString();
                departmentModel.CityLocation = reader["CityLocation"].ToString();
                departmentModel.StateLocation = reader["StateLocation"].ToString();
              }
            }
            sqlLiteConnection.Close();
          }
        }
        catch (SQLiteException e)
        {
          dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to get Department Model for requested ID", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

          throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
          //throw e;
        }

        if (!MatchingRecordFound)
        {
          dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "", customMessage: $"Record not found. Unable to get Department Model for Department ID {departmentId}. Id {departmentId} does not exist in the database.", helpLink: "", errorCode: 0, stackTrace: "");

          throw new DataAccessException(dataAccessStatus);
          //throw e;
        }

        return departmentModel;
      }
    }


    public void Add(IDepartmentModel departmentModel)
    {
      DataAccessStatus dataAccessStatus = new DataAccessStatus();

      using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
      {
        try
        {
          sqlLiteConnection.Open();
        }
        catch (SQLiteException e)
        {
          dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to add DepartmentModel. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

          throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
        }

        string SqlText =
               "INSERT INTO Departments (DepartmentName, DepartmentUrl, PhoneNumber, Email, CityLocation, StateLocation) " +
               "VALUES (@DepartmentName, @DepartmentUrl, @PhoneNumber, @Email, @CityLocation, @StateLocation) ";

        using (SQLiteCommand cmd = new SQLiteCommand(sqlLiteConnection))
        {
          try
          {
            RecordExistsCheck(cmd, departmentModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.Add);
          }
          catch (DataAccessException ex)
          {
            ex.DataAccessStatusInfo.CustomMessage = "Department model could not be added because it is already in the database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);
            throw ex;
          }

          cmd.CommandText = SqlText;

          cmd.Prepare();
          cmd.Parameters.AddWithValue("@DepartmentName", departmentModel.DepartmentName);
          cmd.Parameters.AddWithValue("@DepartmentUrl", departmentModel.DepartmentUrl);
          cmd.Parameters.AddWithValue("@PhoneNumber", departmentModel.PhoneNumber);
          cmd.Parameters.AddWithValue("@Email", departmentModel.Email);
          cmd.Parameters.AddWithValue("@CityLocation", departmentModel.CityLocation);
          cmd.Parameters.AddWithValue("@StateLocation", departmentModel.StateLocation);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch (SQLiteException e)
          {
            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to add DepartmentModel", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
          }


          try //Confirm the Department Model was added to the database
          {
            RecordExistsCheck(cmd, departmentModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmAdd);
          }
          catch (DataAccessException ex)
          {
            ex.DataAccessStatusInfo.Status = "Error";
            ex.DataAccessStatusInfo.OperationSucceeded = false;
            ex.DataAccessStatusInfo.CustomMessage = "Failed to find department model in database after add operation completed.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
          }
          sqlLiteConnection.Close();
        }
      }
    }


    public void Update(IDepartmentModel departmentModel)
    {
      int result = -1;
      DataAccessStatus dataAccessStatus = new DataAccessStatus();

      using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
      {
        try
        {
          sqlLiteConnection.Open();
        }
        catch (SQLiteException e)
        {
          dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to update DepartmentModel. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

          throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
        }

        string updateSql =
               "UPDATE Departments "
             + "SET DepartmentName = @DepartmentName, "
             + "DepartmentUrl = @DepartmentUrl, "
             + "PhoneNumber = @PhoneNumber, "
             + "Email = @Email, "
             + "CityLocation = @CityLocation, "
             + "StateLocation = @StateLocation "
             + "WHERE DepartmentId = @DepartmentId";

        using (SQLiteCommand cmd = new SQLiteCommand(sqlLiteConnection))
        {
          try
          {
            RecordExistsCheck(cmd, departmentModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
          }
          catch (DataAccessException ex)
          {
            ex.DataAccessStatusInfo.CustomMessage = "Department Model could not be updated because it is not in the database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);
            throw ex;
          }

          cmd.CommandText = updateSql;

          cmd.Prepare();
          cmd.Parameters.AddWithValue("@DepartmentName", departmentModel.DepartmentName);
          cmd.Parameters.AddWithValue("@DepartmentUrl", departmentModel.DepartmentUrl);
          cmd.Parameters.AddWithValue("@PhoneNumber", departmentModel.PhoneNumber);
          cmd.Parameters.AddWithValue("@Email", departmentModel.Email);
          cmd.Parameters.AddWithValue("@CityLocation", departmentModel.CityLocation);
          cmd.Parameters.AddWithValue("@StateLocation", departmentModel.StateLocation);
          cmd.Parameters.AddWithValue("@DepartmentId", departmentModel.DepartmentId);
          try
          {
            result = cmd.ExecuteNonQuery();
          }
          catch (SQLiteException e)
          {
            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: String.Copy(e.Message), customMessage: "Unable to update Department Model", helpLink: String.Copy(e.HelpLink), errorCode: e.ErrorCode, stackTrace: String.Copy(e.StackTrace));

            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
          }
        }
        sqlLiteConnection.Close();
      }
    }


    public void DeleteById(int departmentModelId)
    {
      DepartmentModel departmentModel = new DepartmentModel();
      departmentModel.DepartmentId = departmentModelId;
      Delete(departmentModel);
    }

    public void Delete(IDepartmentModel departmentModel)
    {
      DataAccessStatus dataAccessStatus = new DataAccessStatus();

      using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
      {
        try
        {
          sqlLiteConnection.Open();
        }
        catch (SQLiteException e)
        {
          dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to Delete DepartmentModel. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

          throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
        }

        string SqlText = "Delete from Departments where DepartmentId=@DepartmentId";

        using (SQLiteCommand cmd = new SQLiteCommand(sqlLiteConnection))
        {
          try
          {
            RecordExistsCheck(cmd, departmentModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete);
          }
          catch (DataAccessException ex)
          {
            ex.DataAccessStatusInfo.CustomMessage = "Department model could not be deleted because it could not be found in the database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);
            throw ex;
          }

          cmd.CommandText = SqlText;

          cmd.Prepare();
          cmd.Parameters.AddWithValue("@DepartmentId", departmentModel.DepartmentId);

          try
          {
            cmd.ExecuteNonQuery();
          }
          catch (SQLiteException e)
          {
            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to delete DepartmentModel", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
          }


          try //Confirm the Department Model was deleted from the database
          {
            RecordExistsCheck(cmd, departmentModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.ConfirmDelete);
          }
          catch (DataAccessException ex)
          {
            ex.DataAccessStatusInfo.Status = "Error";
            ex.DataAccessStatusInfo.OperationSucceeded = false;
            ex.DataAccessStatusInfo.CustomMessage = "Failed to delete Department Model in database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
          }
          sqlLiteConnection.Close();
        }
      }
    }


    private bool RecordExistsCheck(SQLiteCommand cmd, IDepartmentModel departmentModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
    {
      Int32 countOfRecsFound = 0;
      bool RecordExistsCheckPassed = true;

      DataAccessStatus dataAccessStatus = new DataAccessStatus();

      cmd.Prepare();

      if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
      {
        cmd.CommandText = "Select count(*) from Departments where DepartmentName=@DepartmentName AND PhoneNumber=@PhoneNumber";
        cmd.Parameters.AddWithValue("@DepartmentName", departmentModel.DepartmentName);
        cmd.Parameters.AddWithValue("@PhoneNumber", departmentModel.PhoneNumber);
      }
      else if ((requestType == RequestType.Update) || (requestType == RequestType.ConfirmDelete) || (requestType == RequestType.Delete))
      {
        cmd.CommandText = "Select count(*) from Departments where DepartmentId=@DepartmentId";
        cmd.Parameters.AddWithValue("@DepartmentId", departmentModel.DepartmentId);
      }

      try
      {
        countOfRecsFound = Convert.ToInt32(cmd.ExecuteScalar());
      }
      catch (SQLiteException e)
      {
        string msg = e.Message;
        throw;
      }

      if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExistInDB) && (countOfRecsFound > 0))
      {
        dataAccessStatus.Status = "Error";
        RecordExistsCheckPassed = false;

        throw new DataAccessException(dataAccessStatus);
      }
      else if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesExistInDB) && (countOfRecsFound == 0))
      {
        dataAccessStatus.Status = "Error";
        RecordExistsCheckPassed = false;
        throw new DataAccessException(dataAccessStatus);
      }
      return RecordExistsCheckPassed;
    }

  }
}
