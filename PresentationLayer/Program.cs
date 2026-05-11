/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/
using CommonComponets;
using DomainLayer.Models.Department;
using InfrastructureLayer.DataAccess.Repositories.Specific;
using InfrastructureLayer.DataAccess.Repositories.Specific.Plant;
using PresentationLayer.Presenters;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.DepartmentServices;
using ServiceLayer.Services.PlantServices;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace PresentationLayer
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
     IUnityContainer UnityC;
    
      string _connectionString = "Data Source=" +
      Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\MVPDemo-UnitTest\MDIS.sqlite;Version = 3;";

      UnityC =
          new UnityContainer()
          .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
          .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())
          .RegisterType<INewsViewUC, NewsViewUC>(new ContainerControlledLifetimeManager())
          .RegisterType<INewsPresenter, NewsPresenter>(new ContainerControlledLifetimeManager())
          .RegisterType<IPlantListViewUC, PlantListViewUC>(new ContainerControlledLifetimeManager())
          .RegisterType<IPlantListPresenter, PlantListPresenter>(new ContainerControlledLifetimeManager())
          .RegisterType<IPlantServices, PlantServces>(new ContainerControlledLifetimeManager())
          .RegisterType<IPlantRepository, PlantRepository>(new InjectionConstructor(_connectionString))
          .RegisterType<IDepartmentListViewUC, DepartmentListViewUC>(new ContainerControlledLifetimeManager())
          .RegisterType<IDepartmentListPresenter, DepartmentListPresenter>(new ContainerControlledLifetimeManager())
          .RegisterType<IHelpAboutView, helpAboutView>(new ExternallyControlledLifetimeManager())
          .RegisterType<IHelpAboutPresenter, HelpAboutPresenter>(new ContainerControlledLifetimeManager())         
          .RegisterType<IDepartmentListDeleteView, DepartmentListDeleteView>(new ContainerControlledLifetimeManager())
         //.RegisterType<IAccessTypeEventArgs, AccessTypeEventArgs>(new ContainerControlledLifetimeManager())
          .RegisterType<IDepartmentModel, DepartmentModel>(new ContainerControlledLifetimeManager())
          .RegisterType<IDepartmentDetailPresenter, DepartmentDetailPresenter>(new ContainerControlledLifetimeManager())
          .RegisterType<IDepartmentDetailViewUC, DepartmentDetailViewUC>(new ContainerControlledLifetimeManager())
          .RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager())
          //.RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager())

          //BasePresenter : IBasePresenter
          .RegisterType<IDepartmentRepository, DepartmentRepository>(new InjectionConstructor(_connectionString))
          .RegisterType<IDepartmentServices, DepartmentServices>(new ContainerControlledLifetimeManager())
          .RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>(new ContainerControlledLifetimeManager());

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      IMainPresenter mainPresenter = UnityC.Resolve<MainPresenter>();

      IMainView mainView =mainPresenter.GetMainView();

      //Application.Run(UnityC.Resolve<MainView>());
      Application.Run((MainView)mainView);
    }
  }
}
