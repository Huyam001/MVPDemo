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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceLayer.Services.PlantServices
{
  public class PlantServces : IPlantServices, IPlantRepository
  {
    private IPlantRepository _plantRepository;

    BindingList<PlantModel> _plantModelBindingList;


    public PlantServces(IPlantRepository plantRepository)
    {
      _plantRepository = plantRepository;
    }

    public IEnumerable<PlantModel> GetAll()
    {
      return _plantRepository.GetAll();
    }

    public void BuildDatasourceForAllPlantsList(BindingSource plantListBindingSource)
    {
      IEnumerable<PlantModel> allDepartments = GetAll();

      _plantModelBindingList = new BindingList<PlantModel>();
      foreach (PlantModel plantModel in allDepartments)
      {
        _plantModelBindingList.Add(plantModel);
      };

      plantListBindingSource.DataSource = _plantModelBindingList;
    }


  }
}
