/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using DomainLayer.Models.Department;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServiceLayer.Services.DepartmentServices
{
  public class DepartmentServices : IDepartmentServices
  {
    private IDepartmentRepository _departmenRepository;
    private IModelDataAnnotationCheck _modelDataAnnotationCheck;

    public DepartmentServices(IDepartmentRepository departmenRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
    {
      _departmenRepository = departmenRepository;
      _modelDataAnnotationCheck = modelDataAnnotationCheck;
    }

    public void Add(IDepartmentModel departmentModel)
    {
      ValidateModel(departmentModel);
      _departmenRepository.Add(departmentModel);
    }

    public void Update(IDepartmentModel departmentModel)
    {
      ValidateModel(departmentModel);
      _departmenRepository.Update(departmentModel);
    }

    public void Delete(IDepartmentModel departmentModel)
    {
      _departmenRepository.Delete(departmentModel);
    }
    public void DeleteById(int departmentModelId)
    {
      _departmenRepository.DeleteById(departmentModelId);
    }



    public IEnumerable<IDepartmentModel> GetAll()
    {
      return _departmenRepository.GetAll();
    }

    public DepartmentModel GetById(int id)
    {
      return _departmenRepository.GetById(id);
    }


    public List<DepartmentSelectDto> GetDepartmentSelectList()
    {
      List<DepartmentModel> AllDepartments = (List<DepartmentModel>)GetAll();
      List<DepartmentSelectDto> departmentMinimumDetailDtoList = new List<DepartmentSelectDto>();

      foreach (DepartmentModel departmentModel in AllDepartments)
      {
        DepartmentSelectDto departmentMinimumDetailDto = new DepartmentSelectDto();
        departmentMinimumDetailDto.DepartmentId = departmentModel.DepartmentId;
        departmentMinimumDetailDto.DepartmentName = departmentModel.DepartmentName;
        departmentMinimumDetailDto.CityLocation = departmentModel.CityLocation;
        departmentMinimumDetailDto.StateLocation = departmentModel.StateLocation;
        departmentMinimumDetailDtoList.Add(departmentMinimumDetailDto);
      }
      return departmentMinimumDetailDtoList;
    }



    public void ValidateModel(IDepartmentModel departmentModel)
    {
      _modelDataAnnotationCheck.ValidateModelDataAnnotations(departmentModel);
      ValidateDepartmentUrl(departmentModel);
    }

    public void ValidateModelDataAnnotations(IDepartmentModel departmentModel)
    {
      _modelDataAnnotationCheck.ValidateModelDataAnnotations(departmentModel);
    }

    public void ValidateDepartmentUrl(IDepartmentModel departmentModel)
    {
      StringBuilder errorsStringBuilder = new StringBuilder();

      Uri uriAddress = new Uri(departmentModel.DepartmentUrl);

      string domainExtension = (Path.GetExtension(uriAddress.Host.ToString())).Trim().ToLower();

      if (!".com .net".Contains(domainExtension))
      {
        errorsStringBuilder.Append("URL domain extension can only be .com or .net").AppendLine();
      }

      if (departmentModel.DepartmentUrl.Length < 7 || departmentModel.DepartmentUrl.Length > 60)
      {
        errorsStringBuilder.Append("Department URL must be from 7 to 30 characthers.").AppendLine();
      }

      if (uriAddress.GetLeftPart(UriPartial.Scheme) != "http://")
      {
        errorsStringBuilder.Append($"Department URL must start with http://").AppendLine();
      }

      if (errorsStringBuilder.Length > 0)
      {
        throw new ArgumentException($"{errorsStringBuilder.ToString()}");
      }

    }
  }
}
