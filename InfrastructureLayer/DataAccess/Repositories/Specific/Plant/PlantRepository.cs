/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using DomainLayer.Models.Plant;
using ServiceLayer.Services.PlantServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Plant
{
  public class PlantRepository : BaseSpecificRepository, IPlantRepository
  {
    public PlantRepository()
    { }

    public PlantRepository(string connectionString)
      {
      _connectionString = connectionString;
      }

    public IEnumerable<PlantModel> GetAll()
    {
      List<PlantModel> PlantList = new List<PlantModel>();

      using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
      {
        string sql = "SELECT PlantId, PlantType, PlantColor, ThumbImage FROM Plants";

        sqlLiteConnection.Open();

        using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
        {
          cmd.CommandText = sql;

          using (SQLiteDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              PlantModel plant = new PlantModel();
              plant.PlantId = Convert.ToInt32(reader["PlantId"]);
              plant.PlantType = reader["PlantType"].ToString();
              plant.PlantColor = reader["PlantColor"].ToString();
              plant.ThumbImage = (System.Byte[])reader["ThumbImage"];
              PlantList.Add(plant);
            }
          }
        }
      }
      return PlantList;
    }

  }
}
